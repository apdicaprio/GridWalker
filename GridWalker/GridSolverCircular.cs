using Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridWalker
{
    public class GridSolverCircular
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
            int tempHeight = 1;
            while (!position.IsWall)
            {
                tempHeight++;
                position.StepForward();
            }
            height = tempHeight;

            position.TurnRight();
            int tempWidth = 1;
            while (!position.IsWall)
            {
                tempWidth++;
                position.StepForward();
            }
            width = tempWidth;
            position.TurnRight();

            WalkInnerCircle(position, height.Value - 1, width.Value - 1);
        }

        private void WalkInnerCircle(Position position, int height, int width)
        {
            //fully walked
            if (height < 0 && width < 0)
            {
                return;
            }

            for (int i = height; i > 0; i--)
            {
                position.StepForward();
            }
            position.TurnRight();
            for (int i = width; i > 0; i--)
            {
                position.StepForward();
            }
            position.TurnRight();

            WalkInnerCircle(position, height - 1, width - 1);
        }
    }
}
