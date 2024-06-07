using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_salesman
{
    public class Graph : IGraph
    {
        List<List<int>> _nodes;

        public Graph()
        {
            _nodes = new List<List<int>>();
        }
        public void AddNode()
        {
            int length = _nodes.Count > 0 ? _nodes[0].Count : 0;
            List<int> new_n = Enumerable.Repeat(-1, length).ToList();
            _nodes.Add(new_n);

            foreach (var node in _nodes)
            {
                node.Add(-1);
            }
        }
        public void DeleteNode(int id)
        {
            _nodes.RemoveAt(id);
            foreach (var node in _nodes)
            {
                node.RemoveAt(id);
            }
        }
        public List<List<int>> GetAllNodes()
        {
            return _nodes;
        }
        public int AddPath(int[] nums, int cost)
        {
            if (nums[0] < _nodes.Count && nums[1] < _nodes.Count)
            {
                if (_nodes[nums[0]][nums[1]] == -1 && _nodes[nums[1]][nums[0]] == -1)
                {
                    _nodes[nums[0]][nums[1]] = cost;
                    _nodes[nums[1]][nums[0]] = cost;
                    return 0;
                }
            }
            return -1;
        }
        public void DeletePath(int[] nums)
        {
            _nodes[nums[0]][nums[1]] = -1;
            _nodes[nums[1]][nums[0]] = -1;
        }
        public void Clear()
        {
            _nodes.Clear();
        }
    }
}
