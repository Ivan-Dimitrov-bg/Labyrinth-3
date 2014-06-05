using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.GameEngine
{
    public struct GameConstants
    {
        public const bool PLAYING = true; //game in progress.      
        public const int PLAYER_INITIAL = 3;
        public const int LAB_DIMENSIONS = 7;
        public const char EMPTY_CELL = '-';
        public const char PLAYER_VALUE = '*';
        public const char WALL = 'x';
        public const char VISITED_CELL_MARKER = '0';
        public const int MAX_SCORELIST_SIZE = 5;
        public const string NEW_LINE = "\n";
        public const string NICKNAME_INPUT_MESSAGE = "Please enter your nickname";
        public const string TOP_FIVE_MESSAGE = "Top 5: \n";
        public const string EMPTY_SCOREBOARD_MESSAGE = "The scoreboard is empty! ";
        public const string WELCOME_MESSAGE = "Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n ";
        public const string INPUT_MESSAGE = "\nEnter your move (L=left, R=right, D=down, U=up): ";
        public const string INVALID_MOVE_MESSAGE = "\nInvalid move! \n ";
        public const string INVALID_COMMAND_MESSAGE = "Invalid command!";
        public const string GOODBYE_MESSAGE = "Good bye!";
        public const string CONGRATULATIONS_MESSAGE = "\nCongratulations you escaped with {0} moves.\n";
    }
}