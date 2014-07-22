﻿namespace Labyrinth.GameEngine
{
    using Labyrinth.Commands;
    using Labyrinth.Factories;
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;
    using System;

    /// <summary>
    /// LabyrinthGame class
    /// </summary>
    public class LabyrinthGame
    {
        private enum MoveCommands
        {
            u, d, l, r
        }

        private enum CreationCommands
        {
            small, medium, large
        }

        private const string WELCOME_MESSAGE = "Welcome to \"Labyrinth\" game. \n";
        private const string CHOOSE_LAB_MESAGE = "Please enter what kind of labyrinth you want to play in: 'small', 'medium' or 'large':";
        private const string IN_GAME_MESSAGE = "Try to escape! Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n";
        private const string INPUT_MESSAGE = "\nEnter your move (L=left, R=right, D=down, U=up): ";
        private const string NICKNAME_INPUT_MESSAGE = "Please enter your nickname: ";
        private const string CONGRATULATIONS_MESSAGE = "\nCongratulations you escaped with {0} moves.\n";
        private readonly string[] Commands = new string[] { "u", "d", "l", "r", "small", "medium", "large" };
        private readonly IMaze Maze;
        private readonly IRenderer Renderer;
        private readonly IPlayer Player;
        private readonly IScoreBoard Scores;
        private Commander commander;
        private MazeCreator mazeFactory;

        /// <summary>
        /// LabyrinthGame consturctor
        /// <remarks>
        /// Will initiate the console renderer and all other required classes
        /// </remarks>
        /// </summary>
        public LabyrinthGame()
        {
            this.Renderer = new ConsoleRenderer();
            this.Scores = new ScoreBoard();
            this.commander = new Commander();
            this.Player = PlayerCreator.CreatePlayer();
            this.Maze = this.InitMaze();
        }

        /// <summary>
        /// Start the game
        /// <remarks>
        /// Will initiate all required classes and loop until forced to exit or player wins
        /// </remarks>
        /// </summary>
        public void Start()
        {
            while (!this.commander.IsExitCommandEntered)
            {
                this.commander = new Commander();
                this.mazeFactory.GenerateMaze();
                this.Player.Score = new PlayerScore();
                this.Player.Maze = this.Maze;
                this.TypeCommand();
            }
        }

        /// <summary>
        /// Command pattern and maze initialization after valid maze choice
        /// <remarks>
        /// Choice must be between the allowed maze size enumerations
        /// </remarks>
        /// </summary>
        private IMaze InitMaze()
        {
            string labSizeChoice = string.Empty;

            this.Renderer.Render(WELCOME_MESSAGE);
            this.Renderer.Render(CHOOSE_LAB_MESAGE);

            //while (labSizeChoice != this.Commands[4] && labSizeChoice != this.Commands[5] && labSizeChoice != this.Commands[6])
            while (!IsCreationCommand(labSizeChoice))
            {
                // Command pattern...
                labSizeChoice = this.Renderer.ReadCommand().ToLower();
                this.commander.SetCommand(new MazeCreateCommand(this.Player, labSizeChoice));
                this.commander.ExecuteCommand();
                this.mazeFactory = this.commander.GetMaze(this.Renderer, this.mazeFactory);
            }

            return this.mazeFactory.CreateMaze();
        }

        /// <summary>
        /// More command pattern
        /// <remarks>
        /// Utilize the command pattern for correct game progress and evaluation
        /// </remarks>
        /// </summary>
        private void TypeCommand()
        {
            while (true)
            {
                this.Renderer.Render(IN_GAME_MESSAGE);
                this.Maze.Render(this.Renderer);

                if (this.Player.IsOutOfTheMaze())
                {
                    this.Renderer.Render(CONGRATULATIONS_MESSAGE, this.Player.Score.Moves);
                    this.Renderer.Render(NICKNAME_INPUT_MESSAGE);
                    this.Player.Score.Name = this.Renderer.ReadCommand();
                    this.Renderer.Clear();
                    this.Scores.AddScore(this.Player.Score);
                    this.Scores.Render(this.Renderer);
                    return;
                }

                this.commander.ParseCommand(this.Renderer, this.Scores);

                if (this.commander.IsExitCommandEntered || this.commander.IsRestartCommandEntered)
                {
                    return;
                }

                this.Renderer.Render(INPUT_MESSAGE);
                string command = this.Renderer.ReadCommand().ToLower();

                // Command pattern...
                //if (command == this.Commands[0] || command == this.Commands[1] || command == this.Commands[2] || command == this.Commands[3])
                if (IsMoveCommand(command))
                {
                    this.commander.SetCommand(new MoveCommand(this.Player, command));
                    this.commander.ExecuteCommand();

                    if (!this.Player.PlayerMoved)
                    {
                        this.commander.SetCommand(new PrintCommand(this.Player, command));
                    }
                }
                else
                {
                    this.commander.SetCommand(new PrintCommand(this.Player, command));
                    this.commander.ExecuteCommand();
                }

                this.Renderer.Clear();
            }
        }

        private bool IsMoveCommand(string command)
        {
            bool isMoveCommand = false;

            if (Enum.IsDefined(typeof(MoveCommands), command))
            {
                isMoveCommand = true;
            }

            return isMoveCommand;
        }

        private bool IsCreationCommand(string command)
        {
            bool isCreationCommand = false;

            if (Enum.IsDefined(typeof(CreationCommands), command))
            {
                isCreationCommand = true;
            }

            return isCreationCommand;
        }
    }
}