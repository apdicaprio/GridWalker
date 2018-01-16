using Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridWalker
{
    public abstract class GridSolver
    {

        public virtual void Solve(Position position, out int height, out int width)
        {
            FindCorner(position);
            WalkGrid(position, out height, out width);
        }

        private void WalkToWall(Position position)
        {
            while (!position.IsWall)
            {
                position.StepForward();
            }
            position.TurnRight();
        }

        protected void FindCorner(Position position)
        {
            WalkToWall(position);
            WalkToWall(position);
        }

        protected abstract void WalkGrid(Position position, out int height, out int width);
    }
}
