using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Exceptions
{
    public class GridSizeException
        : Exception
    {
        public GridSizeException(string msg)
            : base(msg)
        {
        }
    }
}
