using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Travelling_salesman
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IVew
    {
        private List<Coordinates> AllTowns;
        public event EventHandler<ClickArgs> AddTown;
        public event EventHandler<ClickArgs> DeleteTown;
        public event EventHandler<ClickArgs> AddPath;
        public event EventHandler<ClickArgs> Clear;
        public event EventHandler<ClickArgs> Calculate;

        private ImageSource _image;
        private ImageBrush _brush;
        private double _size = 20;

        private int AddPathMode = -1;

        public MainWindow()
        {
            InitializeComponent();
            AllTowns = new List<Coordinates>();

            _image = new BitmapImage(new Uri("..\\img.png", UriKind.Relative));
            _brush = new ImageBrush(_image);
        }

        private void canvas_LeftMouseDown(object sender, MouseButtonEventArgs e)
        {

            var c = CheckTown(e);
            if(c == -1)
            {
                AddTown?.Invoke(this, new ClickArgs(e.GetPosition(towns_canvas).X, e.GetPosition(towns_canvas).Y));
            }

        }
        private void canvas_RightMouseDown(object sender, MouseButtonEventArgs e)
        {
            var c = CheckTown(e);
            if (c != -1)
            {
                DeleteTown?.Invoke(this, new ClickArgs(c));
            }
        }

        public void DrawTown(ClickArgs e)
        {
            Label n = new Label();
            n.Content = AllTowns.Count+1;
            n.Margin = new Thickness(e.X - _size / 2, e.Y - _size / 2 - 20, 0, 0);
            Canvas c = new Canvas();
            c.Width = _size;
            c.Height = _size;
            c.Background = _brush;
            Canvas.SetLeft(c, e.X - _size / 2);
            Canvas.SetTop(c, e.Y - _size / 2);
            towns_canvas.Children.Add(c);
            towns_canvas.Children.Add(n);
            AllTowns.Add(new Coordinates(e.X - _size / 2, e.Y - _size / 2, c));
        }

        private int CheckTown(MouseEventArgs e)
        {
            var x = e.GetPosition(towns_canvas).X;
            var y = e.GetPosition(towns_canvas).Y;
            for (int i = 0; i < AllTowns.Count; i++)
            {
                if (AllTowns[i].X - _size < x && AllTowns[i].X + _size > x && AllTowns[i].Y - _size < y && AllTowns[i].Y + _size > y)
                    return i;
            }
            return -1;
        }

        public void DrawPath(int[] nums, int cost)
        {
            Label c = new Label();
            c.Content = cost.ToString();
            c.Margin = new Thickness((AllTowns[nums[0]].X + AllTowns[nums[1]].X) / 2, (AllTowns[nums[0]].Y + AllTowns[nums[1]].Y) / 2-20, 0, 0);
            Line newPath = new Line();
            newPath.X1 = AllTowns[nums[0]].X + _size / 2;
            newPath.Y1 = AllTowns[nums[0]].Y + _size / 2;
            newPath.X2 = AllTowns[nums[1]].X + _size / 2;
            newPath.Y2 = AllTowns[nums[1]].Y + _size / 2;
            newPath.Stroke=Brushes.Black;
            newPath.StrokeThickness = 2;
            towns_canvas.Children.Add(newPath);
            towns_canvas.Children.Add(c);
        }
        public void DrawResult(int[] nums, int cost)
        {

        }
        public void ClearView()
        {
            towns_canvas.Children.Clear();
        }
        public void AddPathClick(object sender, RoutedEventArgs e)
        {
            int first = int.Parse(First_city_text.Text);
            int second = int.Parse(Second_city_text.Text);
            int cost = int.Parse(Cost_text.Text);
            AddPath?.Invoke(this, new ClickArgs(first, second, cost));
            First_city_text.Clear();
            Second_city_text.Clear();
            Cost_text.Clear();
        }
        public void ClearClick(object sender, RoutedEventArgs e)
        {
            Clear?.Invoke(this, null);
        }
        public void CalculatePathClick(object sender, RoutedEventArgs e)
        {
            Calculate?.Invoke(this, null);
        }

        public void OutputHint(string hint)
        {
            Output_label.Content = hint;
        }
    }
}
