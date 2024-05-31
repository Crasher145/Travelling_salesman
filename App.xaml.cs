using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Travelling_salesman
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            
        }

        [STAThread] static void Main(string[] args)
        {
            IModel model = new Model();
            MainWindow view = new MainWindow();
            IPresentor presentor = new Presentor(view, model);

            App app = new App();
            app.Run(view);
        }
    }
}
