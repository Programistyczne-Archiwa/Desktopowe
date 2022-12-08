using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;
using static System.Net.WebRequestMethods;

namespace spotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        
        public MainWindow()
        {
            InitializeComponent();

            string[] filenames = Directory.GetFiles("C:\\Users\\4pTP Gr2\\Desktop\\desktopowe\\spotify\\music");

            
            for (int i = 0; i < filenames.Length; i++)
            {
                string[] tab1 = filenames[i].Split('\\');
                listbox.Items.Add(tab1[tab1.Length-1]);
                
            }
            
            mediaPlayer.Volume = sliderus.Value;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
            {

                lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                double duration = Convert.ToDouble(mediaPlayer.NaturalDuration.TimeSpan.Seconds);
                sliderD.Maximum = duration;
            }
            else
            {
                lblStatus.Content = "No file selected...";
            }
        }
        private void btnOpenAudioFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
                mediaPlayer.Play();
            }
        }

        

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void sliderus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = sliderus.Value;
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listbox.SelectedIndex;
            mediaPlayer.Open(new Uri("C:\\Users\\4pTP Gr2\\Desktop\\desktopowe\\spotify\\music\\" + listbox.Items[index]));
            
            mediaPlayer.Play();
            

        }

        private void sliderD_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }
    }
}
