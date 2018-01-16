using Grid.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid
{
    public class Grid
    {
        private readonly int _Width;
        private readonly int _Height;

        internal int Width
        {
            get { return _Width; }
        }

        internal int Height
        {
            get { return _Height; }
        }

        public Grid(int height, int width)
        {
            if (height < 1)
            {
                throw new GridSizeException("Grid height must be greater than or equal to 1");
            }
            if (width < 1)
            {
                throw new GridSizeException("Grid width must be greater than or equal to 1");
            }
            _Width = width;
            _Height = height;
        }
    }
}
