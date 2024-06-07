using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Travelling_salesman
{
    public struct minPath
    {
        public int cost;
        public List<int> nums;
    }
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
        public int AddPath(int[] towns, int cost)
        {
            if (_graph.AddPath(towns, cost) == 0)
            {
                return 0;
            }
            else return -1;
        }
        public void DeleteTown(int id)
        {
            _graph.DeleteNode(id);
        }
        public void DeletePath(int[] towns)
        {
            _graph.DeletePath(towns);
        }

        private int minPath = 10000;
        private int minCounter;
        //Список всех перестановок городов
        static List<List<int>> results = new List<List<int>>();
        //Длина пути 
        private int path;
        //Вспомогательные переменные
        private int p1, p2;

        public minPath Calculate()
        {
            minPath = 10000;
            results.Clear();
            List<List<int>> towns = _graph.GetAllNodes();

            //Список всех городов
            List<int> cities = new List<int> ();
            for(int i = 0; i < towns.Count; i++)
            {
                cities.Add(i+1);
            }
            Permute(cities);

            for (int i = 0; i < results.Count; i++)
            {
                bool isValid = true;
                path = 0;
                for (int j = 1; j < results[i].Count; j++)
                {
                    p1 = results[i][j - 1] - 1;
                    p2 = results[i][j] - 1;
                    if (towns[p1][p2] == -1)
                    {
                        isValid = false;
                        break;
                    }
                    path += towns[p1][p2];
                }

                if (path < minPath && isValid)
                {
                    minCounter = i;
                    minPath = path;
                }
            }

            //Вывод порядка прохождения городов и длины этого пути
            minPath p = new minPath(); 
            p.nums = results[minCounter];
            p.cost = minPath;
            return p;
        }

        //Функция по перебору всех перестановок
        static void Permute(List<int> arr, List<int> memo = null)
        {
            memo = memo ?? new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                int cur = arr[i];
                arr.RemoveAt(i);
                if (arr.Count == 0)
                {
                    results.Add(new List<int>(memo) { cur, memo[0] });
                }

                Permute(new List<int>(arr), new List<int>(memo) { cur });
                arr.Insert(i, cur);
            }
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
