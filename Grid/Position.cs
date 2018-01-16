using Grid.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid
{
    public class Position
    {
        private Grid _Grid;
        private Direction _Direction;
        private int _X = -1;
        private int _Y = -1;

        public int StepsTaken
        {
            get;
            private set;
        }

        public int TurnsMade
        {
            get;
            private set;
        }

        public int WallChecksMade
        {
            get;
            private set;
        }

        public Position(Grid grid)
        {
            StepsTaken = 0;
            TurnsMade = 0;
            WallChecksMade = 0;

            _Grid = grid;
            Random rand = new Random(DateTime.Now.Millisecond);
            switch (rand.Next(1, 4))
            {
                case 1:
                    _Direction = Direction.East;
                    break;
                case 2:
                    _Direction = Direction.North;
                    break;
                case 3:
                    _Direction = Direction.South;
                    break;
                case 4:
                    _Direction = Direction.West;
                    break;
            }

            _X = rand.Next(1, grid.Width);
            _Y = rand.Next(1, grid.Height);
        }

        public bool IsWall
        {
            get
            {
                WallChecksMade++;

                switch (_Direction)
                {
                    case Direction.East: //-->
                        return _X >= _Grid?.Width;
                    case Direction.West: //<--
                        return _X <= 1;
                    case Direction.North://^
                        return _Y >= _Grid?.Height;
                    case Direction.South://v
                        return _Y <= 1;
                }

                return false; //TODO: invalid direction, throw exception
            }
        }

        public void TurnLeft()
        {
            TurnsMade++;

            switch (_Direction)
            {
                case Direction.East: //-->
                    _Direction = Direction.North;
                    break;
                case Direction.West: //<--
                    _Direction = Direction.South;
                    break;
                case Direction.North://^
                    _Direction = Direction.West;
                    break;
                case Direction.South://v
                    _Direction = Direction.East;
                    break;
            }
        }

        public void TurnRight()
        {
            TurnsMade++;

            switch (_Direction)
            {
                case Direction.East: //-->
                    _Direction = Direction.South;
                    break;
                case Direction.West: //<--
                    _Direction = Direction.North;
                    break;
                case Direction.North://^
                    _Direction = Direction.East;
                    break;
                case Direction.South://v
                    _Direction = Direction.West;
                    break;
            }
        }

        public void StepForward()
        {
            StepsTaken++;

            switch (_Direction)
            {
                case Direction.East: //-->
                    if (IsWall)
                    {
                        throw new WallException("You've exceeded the width of the grid");
                    }

                    _X++;
                    break;
                case Direction.West: //<--
                    if (IsWall)
                    {
                        throw new WallException("You've reached the side of the grid");
                    }

                    _X--;
                    break;
                case Direction.North://^
                    if (IsWall)
                    {
                        throw new WallException("You've exceeded the height of the grid");
                    }

                    _Y++;
                    break;
                case Direction.South://v
                    if (IsWall)
                    {
                        throw new WallException("You've reached the bottom of the grid");
                    }

                    _Y--;
                    break;
            }
        }
    }
}
