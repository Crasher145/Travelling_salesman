using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_salesman
{
    public class ClickArgs : EventArgs
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public int number { get; private set; }

        public ClickArgs(double x, double y) {
            X = x;
            Y= y;
        }

        public ClickArgs(double x, double y, int n)
        {
            X = x;
            Y = y;
            number = n;
        }
        public ClickArgs(int n) {
            number = n; 
        }
    }
}
