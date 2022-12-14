using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Spotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Song> filePaths = new ObservableCollection<Song>();
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            list_music.ItemsSource = filePaths;
            timer.Interval = TimeSpan.FromSeconds(1);
            slider_volume.Interval = 1;
            slider_speed_ratio.Interval = 1;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if((mediaPlayer.Source != null) && (mediaPlayer.NaturalDuration.HasTimeSpan))
            {
                lbl_timer.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"hh\:mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss"));
                slider_timer.Minimum = 0;
                slider_timer.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                slider_timer.Value = mediaPlayer.Position.TotalSeconds;
            }
        }
        private void btn_play_music_Click(object sender, RoutedEventArgs e)
        {
            if(list_music.SelectedIndex != -1)
            {
                mediaPlayer.Play();
                timer.Tick += timer_Tick;
                timer.Start();
                btn_pause_music.Visibility = Visibility.Visible;
                btn_play_music.Visibility = Visibility.Collapsed;
            }
        }
        private void btn_pause_music_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            mediaPlayer.Pause();
            btn_pause_music.Visibility = Visibility.Collapsed;
            btn_play_music.Visibility = Visibility.Visible;
        }
        private void btn_add_song_to_list_Click(object sender, RoutedEventArgs e)
        {
            // add song to list
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3|WAV Files (*.wav)|*.wav|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                filePaths.Add(new Song(openFileDialog.FileName, openFileDialog.FileName.Split('\\').Last()));
            }
        }

        private void slider_timer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds(slider_timer.Value);
            lbl_timer.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"hh\:mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss"));
        }

        private void slider_volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbl_volume.Content = "Volume " + Math.Round(slider_volume.Value).ToString() + "%:";
            mediaPlayer.Volume = slider_volume.Value / 100;
        }
        
        private void slider_speed_ratio_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbl_speed_ratio.Content = "Speed Ratio " + Math.Round(slider_speed_ratio.Value / 10, 1).ToString() + ":";
            mediaPlayer.SpeedRatio = slider_speed_ratio.Value / 10;
        }

        private void list_music_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mediaPlayer.Open(new Uri(filePaths[list_music.SelectedIndex].path));
            lbl_song_name.Content = filePaths[list_music.SelectedIndex].name;
        }
    }
    class Song
    {
        public string path { get; set; }
        public string name { get; set; }
        public bool isFavorite { get; set; }
        public Song(string path, string name)
        {
            this.path = path;
            this.name = name;
        }
    }
}
