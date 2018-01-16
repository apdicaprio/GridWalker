using GridWalker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Grid.Grid(1, 1);
            var circGridSolver = new GridSolverCircular();
            var upNbackGridSolver = new GridSolverUpAndBack();

            Solve(g, circGridSolver);
            Solve(g, upNbackGridSolver);
            
            g = new Grid.Grid(5, 9);
            Solve(g, circGridSolver);
            Solve(g, upNbackGridSolver);

            g = new Grid.Grid(9, 5);
            Solve(g, circGridSolver);
            Solve(g, upNbackGridSolver);

            g = new Grid.Grid(22, 5);
            Solve(g, circGridSolver);
            Solve(g, upNbackGridSolver);
            Console.Read();
        }

        private static void Solve(Grid.Grid grid, GridWalker.GridSolver solver)
        {
            int height;
            int width;
            var position = new Grid.Position(grid);
            solver.Solve(position, out height, out width);
            Console.WriteLine("Solved [{0}x{1}] using {2} with {3} wall checks, {4} steps, and {5} turns", height, width, solver.GetType()
                , position.WallChecksMade, position.StepsTaken, position.TurnsMade);
        }
    }
}
