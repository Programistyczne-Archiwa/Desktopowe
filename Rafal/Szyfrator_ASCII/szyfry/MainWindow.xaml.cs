using System;
using System.Collections;
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

namespace szyfry
{
    
    public static class Extensions
    {
        public static string Scramble(this string s)
        {
            return new string(s.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
        }
        
        
    }
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string aaa = t1.Text;

                byte[] bity = Encoding.ASCII.GetBytes(aaa);
                string szyfred = "";
                for(int i=0;i<bity.Length; i++)
                {
                    szyfred += bity[i] + "-";
                }
                szyfred = szyfred.Remove(szyfred.Length - 1);
               
                t2.Text = szyfred;

            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try 
            {
                string[] tab1 = t2.Text.Split("-");
                int[] tab2 = new int[tab1.Length];
                for (int i = 0; i < tab1.Length; i++)
                {
                    tab2[i] = int.Parse(tab1[i]);
                }


                byte[] unszyfred = new byte[tab2.Length * sizeof(int)];
                Buffer.BlockCopy(tab2, 0, unszyfred, 0, unszyfred.Length);

                t2_Copy.Text = Encoding.ASCII.GetString(unszyfred);
            }catch(System.FormatException)
            {

            }
        }
    }
}
