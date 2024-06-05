using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_salesman
{
    public interface IModel
    {
        void AddTown();
        void AddPath(int[] towns, int cost);
        void DeleteTown(int id);
        void DeletePath(int[] towns);
        minPath Calculate();
        void ClearModel();
        IGraph GetGraph();
    }
}
