using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Travelling_salesman
{
    public interface IPresentor
    {
        void AddTownEventHandler(object sender, ClickArgs e);
        void ClearEventHandler(object sender, ClickArgs e);
        void CalculatePathEventHandler(object sender, EventArgs e);
        void AddPathEventHandler(object sender, ClickArgs e);
    }
}
