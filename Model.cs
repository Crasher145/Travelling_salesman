using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Travelling_salesman
{
    public class Model : IModel
    {
        private IGraph _graph;

        public Model() {
            _graph = new Graph();
        }
        public void AddTown()
        {
            _graph.AddNode();
        }
        public void AddPath(int[] towns, int cost)
        {
            _graph.AddPath(towns, cost);
        }
        public void DeleteTown(int id)
        {
            _graph.DeleteNode(id);
        }
        public void DeletePath(int[] towns)
        {
            _graph.DeletePath(towns);
        }
        public void Calculate()
        {
            List<List<int>> connectivity_matrix = _graph.GetAllNodes();
            for (int i = 0; i< connectivity_matrix.Count; i++)
            {
                int result = Iteration(connectivity_matrix, i, i);
            }
        }

        private int Iteration(List<List<int>> nodes, int ignore, int curr_town)
        {
            return 1;
        }
        public void ClearModel()
        {
            _graph.Clear();
        }
        public IGraph GetGraph()
        {
            return _graph;
        }

    }
}
