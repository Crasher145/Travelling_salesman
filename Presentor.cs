using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_salesman
{
    public class Presentor : IPresentor 
    {
        private IVew view;
        private IModel model;

        public Presentor(IVew v, IModel m)
        {
            view = v;
            model = m;

            view.AddTown += AddTownEventHandler;
            view.Clear += ClearEventHandler;
            view.AddPath += AddPathEventHandler;
            view.Calculate += CalculatePathEventHandler;
        }

        //для  отладки
        void UpdateHint()
        {
            string hint = " ";
            List<List<int>> matrix = model.GetGraph().GetAllNodes();
            foreach (List<int> row in matrix)
            {
                foreach (int i in row)
                {
                    hint += i.ToString();
                    hint += " ";
                }
                hint += "\n ";
            }
            view.OutputHint(hint);
        }
        public void AddTownEventHandler(object sender, ClickArgs e)
        {
            view.DrawTown(e);
            model.AddTown();
            UpdateHint();
        }
        public void ClearEventHandler(object sender, ClickArgs e)
        {
            view.ClearView();
            model.ClearModel();
            UpdateHint();
        }
        public void CalculatePathEventHandler(object sender, EventArgs e)
        {
            minPath p = model.Calculate();
            view.OutputHint(p.cost.ToString());
        }
        public void AddPathEventHandler(object sender, ClickArgs e)
        {
            view.DrawPath(new int[2] { (int)e.X-1, (int)e.Y-1}, e.number);
            model.AddPath(new int[2] { (int)e.X - 1, (int)e.Y - 1 }, e.number);

            UpdateHint();
        }
    }
}
