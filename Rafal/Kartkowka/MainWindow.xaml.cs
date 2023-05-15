using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Kartkowka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            (sender as Button).Background = Brushes.Red;
            (sender as Button).IsHitTestVisible = false;
            //          (sender as Button).Content = "Kliknąłeś na przycisk numer " + (sender as Button).Name[1];
            
            (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(@"C:\\Users\\4p - gr2\\Desktop\\ApWpf\\Kartkowka\\papa.png")));

            
        }
        private void Reset()
        {
            b1.Background = Brushes.White;
            b2.Background = Brushes.White;
            b3.Background = Brushes.White;

            b1.IsHitTestVisible = true;
            b2.IsHitTestVisible = true;
            b3.IsHitTestVisible = true;
            b1.Content = "1";
            b2.Content = "2";
            b3.Content = "3";
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
