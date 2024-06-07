using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_salesman
{
    public interface IGraph
    {
        void AddNode();
        void DeleteNode(int id);
        List<List<int>> GetAllNodes();
        int AddPath(int[] nums, int cost);
        void DeletePath(int[] nums);
        void Clear();
    }
}
