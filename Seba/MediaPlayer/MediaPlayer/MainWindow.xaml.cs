using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Song> filePaths = new ObservableCollection<Song>();
        private SoundPlayer soundPlayer = new SoundPlayer();
        public MainWindow()
        {
            InitializeComponent();
            filePaths.Add(new Song("E:\\Unity\\Desktopowe\\Seba\\MediaPlayer\\MediaPlayer\\assets\\PAKUJE WALIZE (Official Video).mp3", "PAKUJE WALIZE (Official Video)"));
            list_music.ItemsSource = filePaths;
        }

        private void btn_play_music_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.SoundLocation = filePaths[list_music.SelectedIndex].path;
            soundPlayer.Load();
            soundPlayer.Play();
        }
    }
    class Song
    {
        public string path;
        public string name;
        public Song(string path, string name)
        {
            this.path = path;
            this.name = name;
        }
    }
}
