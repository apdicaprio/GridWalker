using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grid;

namespace GridWalker
{
    public class GridSolverUpAndBack
        : GridSolver
    {
        protected override void WalkGrid(Position position, out int height, out int width)
        {
            int? walkedHeight = null;
            int? walkedWidth = null;

            Walk(position, ref walkedHeight, ref walkedWidth);

            height = walkedHeight.Value;
            width = walkedWidth.Value;
        }

        private void Walk(Position position, ref int? height, ref int? width)
        {
            Walk(position, ref height, ref width, false);
        }

        private void Walk(Position position, ref int? height, ref int? width, bool flip)
        {
            if (height == null)
            {
                int tmpHeight = 1;
                while (!position.IsWall)
                {
                    tmpHeight++;
                    position.StepForward();
                }
                height = tmpHeight;
            }
            else
            {
                for (int i = 1; i < height.Value; i++)
                {
                    position.StepForward();
                }
            }

            if (width == null)
            {
                width = 1;
            }
            else
            {
                width++;
            }

            if (flip)
            {
                position.TurnLeft();
            }
            else
            {
                position.TurnRight();
            }

            if (position.IsWall)
            {
                return;
            }

            position.StepForward();
            if (flip)
            {
                position.TurnLeft();
            }
            else
            {
                position.TurnRight();
            }
            //turning right, then left as we snake across
            Walk(position, ref height, ref width, !flip);
        }
    }
}
