﻿namespace Labyrinth.GameEngine
{
    using Labyrinth.GameObjects;
    using System;
    using System.Linq;

    class LargeLabCreator : LabCreator
    {
        private const int LARGE_LAB_SIZE = 30;

        public override Maze CreateLabyrinth()
        {
            return new Maze(new Position (LARGE_LAB_SIZE/2, LARGE_LAB_SIZE/2) ,LARGE_LAB_SIZE, LARGE_LAB_SIZE);
        }
    }
}
