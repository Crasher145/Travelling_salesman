using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Travelling_salesman
{
    public interface IVew
    {
        event EventHandler<ClickArgs> AddTown;
        event EventHandler<ClickArgs> AddPath;
        event EventHandler<ClickArgs> Clear;
        event EventHandler<ClickArgs> Calculate;

        void DrawTown(ClickArgs e);
        void DrawPath(int[] nums, int cost);
        void DrawResult(int[] nums, int cost);
        void ClearView();
        void OutputHint(string hint);
    }
}
