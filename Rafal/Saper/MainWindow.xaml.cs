using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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

namespace Saper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timerus.Content = 0;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();


            


            Button[] child = gridboi.Children.OfType<Button>().ToArray<Button>();
            int[] bomby = new int[8];
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {

                bomby = generateUniqueNumbers(0, 25);
                

            }



            for (int i = 0; i < 5; i++)
            {
                try
                {
                    gridboi.Children.OfType<Button>().ToArray<Button>()[bomby[i]].Tag = "Bomba";

                }
                catch { }

            }
            for (int i = 0; i < 25; i++)
            {
                if (child[i].Content == null && child[i].Tag != "Bomba")
                {
                    child[i].Content = 0;
                }
                //                gridboi.Children.OfType<Button>().ToArray<Button>()[i].Content = gridboi.Children.OfType<Button>().ToArray<Button>()[i].Tag;
            }
            numberAssign();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
                timerus.Content =(int)timerus.Content + 1;
            
        }

        public static int[] generateUniqueNumbers(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentException("Minimal value cannot be bigger than maximal value.");

            int[] values = new int[maxValue - minValue + 1];

            for (int i = 0; i < values.Length; ++i)
                values[i] = minValue + i;

            Random random = new Random();

            Array.Sort(values, (a, b) => random.Next(-1, 2));

            return values;
        }

        private void numberAssign()
        {

            Button[] child = gridboi.Children.OfType<Button>().ToArray<Button>();


            for (int i = 0; i < 25; i++)
            {
                if (child[i].Tag == "Bomba")
                {
                    if (i == 0)
                    {
                        if (child[i + 1].Tag != "Bomba")
                        {

                            child[i + 1].Content = (int)child[i + 1].Content + 1;
                        }
                        if (child[i + 5].Tag != "Bomba")
                        {
                            child[i + 5].Content = (int)child[i + 5].Content + 1;

                        }
                        if (child[i + 6].Tag != "Bomba")
                        {
                            child[i + 6].Content = (int)child[i + 6].Content + 1;

                        }
                    }
                    else if (i == 4)
                    {
                        if (child[i - 1].Tag != "Bomba")
                        {
                            child[i - 1].Content = (int)child[i - 1].Content + 1;

                        }
                        if (child[i + 4].Tag != "Bomba")
                        {
                            child[i + 4].Content = (int)child[i + 4].Content + 1;
                        }
                        if (child[i + 5].Tag != "Bomba")
                        {
                            child[i + 5].Content = (int)child[i + 5].Content + 1;
                        }
                    }
                    else if (i == 20)
                    {
                        if (child[i + 1].Tag != "Bomba")
                        {
                            child[i + 1].Content = (int)child[i + 1].Content + 1;
                        }
                        if (child[i - 5].Tag != "Bomba")
                        {
                            child[i - 5].Content = (int)child[i - 5].Content + 1;
                        }
                        if (child[i - 4].Tag != "Bomba")
                        {

                            child[i - 4].Content = (int)child[i - 4].Content + 1;
                        }
                    }
                    else if (i == 19)
                    {
                        if (child[i - 1].Tag != "Bomba")
                        {
                            child[i - 1].Content = (int)child[i - 1].Content + 1;
                        }
                        if (child[i - 5].Tag != "Bomba")
                        {
                            child[i - 5].Content = (int)child[i - 5].Content + 1;
                        }
                        if (child[i - 4].Tag != "Bomba")
                        {

                            child[i - 4].Content = (int)child[i - 4].Content + 1;
                        }
                        if (child[i + 5].Tag != "Bomba")
                        {
                            child[i + 5].Content = (int)child[i + 5].Content + 1;
                        }
                        if (child[i + 4].Tag != "Bomba")
                        {

                            child[i + 4].Content = (int)child[i + 4].Content + 1;
                        }
                    }
                    else if (i == 24)
                    {
                        if (child[i - 1].Tag != "Bomba")
                        {
                            child[i - 1].Content = (int)child[i - 1].Content + 1;
                        }
                        if (child[i - 5].Tag != "Bomba")
                        {

                            child[i - 5].Content = (int)child[i - 5].Content + 1;
                        }
                        if (child[i - 6].Tag != "Bomba")
                        {
                            child[i - 6].Content = (int)child[i - 6].Content + 1;

                        }
                    }
                    else if (i == 10)
                    {
                        if (child[i - 1].Tag != "Bomba")
                        {
                            child[i - 1].Content = (int)child[i - 1].Content + 1;
                        }
                        if (child[i - 5].Tag != "Bomba")
                        {
                            child[i - 5].Content = (int)child[i - 5].Content + 1;
                        }
                        if (child[i - 4].Tag != "Bomba")
                        {

                            child[i - 4].Content = (int)child[i - 4].Content + 1;
                        }
                        if (child[i + 5].Tag != "Bomba")
                        {
                            child[i + 5].Content = (int)child[i + 5].Content + 1;
                        }
                        if (child[i + 4].Tag != "Bomba")
                        {

                            child[i + 4].Content = (int)child[i + 4].Content + 1;
                        }
                    }
                    else if (i > 0 && i < 5)
                    {
                        if (child[i + 1].Tag != "Bomba")
                        {
                            child[i + 1].Content = (int)child[i + 1].Content + 1;
                        }
                        if (child[i - 1].Tag != "Bomba")
                        {
                            child[i - 1].Content = (int)child[i - 1].Content + 1;

                        }
                        if (child[i + 4].Tag != "Bomba")
                        {
                            child[i + 4].Content = (int)child[i + 4].Content + 1;

                        }
                        if (child[i + 5].Tag != "Bomba")
                        {
                            child[i + 5].Content = (int)child[i + 5].Content + 1;
                        }
                        if (child[i + 6].Tag != "Bomba")
                        {
                            child[i + 6].Content = (int)child[i + 6].Content + 1;
                        }
                    }
                    else if ((i > 5 && i < 10) || (i > 10 && i < 15) || (i > 15 && i < 20))
                    {
                        if (child[i + 1].Tag != "Bomba")
                        {
                            child[i + 1].Content = (int)child[i + 1].Content + 1;
                        }

                        if (child[i - 1].Tag != "Bomba")
                        {
                            child[i - 1].Content = (int)child[i - 1].Content + 1;
                        }
                        if (child[i + 4].Tag != "Bomba")
                        {
                            child[i + 4].Content = (int)child[i + 4].Content + 1;
                        }

                        if (child[i + 5].Tag != "Bomba")
                        {
                            child[i + 5].Content = (int)child[i + 5].Content + 1;
                        }
                        if (child[i + 6].Tag != "Bomba")
                        {
                            child[i + 6].Content = (int)child[i + 6].Content + 1;
                        }

                        if (child[i - 4].Tag != "Bomba")
                        {
                            child[i - 4].Content = (int)child[i - 4].Content + 1;
                        }

                        if (child[i - 5].Tag != "Bomba")
                        {
                            child[i - 5].Content = (int)child[i - 5].Content + 1;
                        }
                        if (child[i - 6].Tag != "Bomba")
                        {
                            child[i - 6].Content = (int)child[i - 6].Content + 1;
                        }
                    }
                    else if (i > 20 && i < 24)
                    {
                        if (child[i + 1].Tag != "Bomba")
                        {
                            child[i + 1].Content = (int)child[i + 1].Content + 1;
                        }
                        if (child[i - 1].Tag != "Bomba")
                        {
                            child[i - 1].Content = (int)child[i - 1].Content + 1;

                        }

                        if (child[i - 4].Tag != "Bomba")
                        {
                            child[i - 4].Content = (int)child[i - 4].Content + 1;

                        }
                        if (child[i - 5].Tag != "Bomba")
                        {
                            child[i - 5].Content = (int)child[i - 5].Content + 1;
                        }
                        if (child[i - 6].Tag != "Bomba")
                        {
                            child[i - 6].Content = (int)child[i - 6].Content + 1;
                        }
                    }
                }


            }


        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = (sender as Button).Tag;
            (sender as Button).IsHitTestVisible = false;
            (sender as Button).Background = Brushes.White;
            if((sender as Button).Tag == "Bomba")
            {
                for(int i = 0; i < gridboi.Children.OfType<Button>().ToArray<Button>().Length;i++)
                {
                    gridboi.Children.OfType<Button>().ToArray<Button>()[i].Content = gridboi.Children.OfType<Button>().ToArray<Button>()[i].Tag;
                    gridboi.Children.OfType<Button>().ToArray<Button>()[i].IsHitTestVisible = false;
                }
            }
        }
    }
}
