using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Travelling_salesman
{
    public struct Coordinates
    {
        public double X;
        public double Y;

        public Canvas img;

        public Coordinates(double x, double y, Canvas i)
        {
            X = x;
            Y = y;
            img = i;
        }
    }
}
