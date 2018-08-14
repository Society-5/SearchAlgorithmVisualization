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
using System.Text.RegularExpressions;
using MahApps.Metro.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ViewModel _control;
        
        LabyrinthSquare[,] _environment;
        public MainWindow()
        {
            InitializeComponent();
            _control = new ViewModel();            
            _environment = _control.GenerateMaze(Convert.ToUInt32(xSquares.Text), Convert.ToUInt32(ySquares.Text));
            UpdateCanvas();
        }

        private void GenerateMazeClick(object sender, RoutedEventArgs e)
        {
            _environment = _control.GenerateMaze(Convert.ToUInt32(xSquares.Text), Convert.ToUInt32(ySquares.Text));
            UpdateCanvas();
        }

        private void UpdateCanvas()
        {
            int largerDimension;
            double sizeOfSquare;
            var parentCanvas = new Canvas();
            parentCanvas.Width = 500;
            parentCanvas.Height = 500;

            if (Convert.ToInt32(xSquares.Text) >= Convert.ToInt32(ySquares.Text))
            {
                largerDimension = Convert.ToInt32(xSquares.Text);
            }
            else
            {
                largerDimension = Convert.ToInt32(ySquares.Text);
            }
            sizeOfSquare = (parentCanvas.Width - (2 * (largerDimension + 1))) / largerDimension;

            var grey = new SolidColorBrush();
            var blue = new SolidColorBrush();
            grey.Color = Color.FromRgb(66, 66, 72);
            blue.Color = Color.FromRgb(45, 137, 239);

            foreach (var square in _environment)
            {
                var drawnSquare = new Canvas();
                double _distanceLeft = ((sizeOfSquare + 2) * square.x);
                double _distanceTop = ((sizeOfSquare + 2) * square.y);
                drawnSquare.Width = sizeOfSquare;
                drawnSquare.Height = sizeOfSquare;
                drawnSquare.Background = grey;
                Canvas.SetLeft(drawnSquare, _distanceLeft);
                Canvas.SetTop(drawnSquare, _distanceTop);
                parentCanvas.Children.Add(drawnSquare);

                if (square.Walls[(int)LabyrinthSquare.Dir.Up])
                {
                    var _wall = new Canvas();
                    _wall.Width = sizeOfSquare;
                    _wall.Height = 1;
                    _wall.Background = blue;
                    Canvas.SetLeft(_wall, _distanceLeft);
                    Canvas.SetTop(_wall, _distanceTop - 1);
                    parentCanvas.Children.Add(_wall);
                }

                if (square.Walls[(int)LabyrinthSquare.Dir.Right])
                {
                    var _wall = new Canvas();
                    _wall.Width = 1;
                    _wall.Height = sizeOfSquare;
                    _wall.Background = blue;
                    Canvas.SetLeft(_wall, _distanceLeft + sizeOfSquare);
                    Canvas.SetTop(_wall, _distanceTop);
                    parentCanvas.Children.Add(_wall);
                }

                if (square.Walls[(int)LabyrinthSquare.Dir.Down])
                {
                    var _wall = new Canvas();
                    _wall.Width = sizeOfSquare;
                    _wall.Height = 1;
                    _wall.Background = blue;
                    Canvas.SetLeft(_wall, _distanceLeft);
                    Canvas.SetTop(_wall, _distanceTop + sizeOfSquare);
                    parentCanvas.Children.Add(_wall);
                }

                if (square.Walls[(int)LabyrinthSquare.Dir.Left])
                {
                    var _wall = new Canvas();
                    _wall.Width = 1;
                    _wall.Height = sizeOfSquare;
                    _wall.Background = blue;
                    Canvas.SetLeft(_wall, _distanceLeft - 1);
                    Canvas.SetTop(_wall, _distanceTop);
                    parentCanvas.Children.Add(_wall);
                }
            }

            canvas.Children.Clear();
            canvas.Children.Add(parentCanvas);

        }

        private void IsInputNumber(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(xSquares.Text);
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            PathFindingSquare[,] environmentModel;
            environmentModel = _control.FindPath(selectAlgorithm.SelectionBoxItem.ToString());
        }
    }
}
