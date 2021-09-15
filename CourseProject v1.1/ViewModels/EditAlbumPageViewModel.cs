using CourseProject_v1._1.Commands;
using CourseProject_v1._1.Models;
using CourseProject_v1._1.ViewModels.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CourseProject_v1._1.ViewModels
{
    internal class EditAlbumPageViewModel : ViewModel
    {
        private readonly MusicService db = new MusicService();
        private readonly string _myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
 
        private bool _DialogVisible = false;
        public bool DialogVisible
        {
            get => _DialogVisible;
            set => Set(ref _DialogVisible, value);
        }
        private string _TrackName;
        public string TrackName
        {
            get => _TrackName;
            set => Set(ref _TrackName, value);
        }
        private string _trackpath;
        public string trackpath
        {
            get => _trackpath;
            set => Set(ref _trackpath, value);
        }
        private List<GENRES> _genres;
        public List<GENRES> genres
        {
            get => _genres;
            set => Set(ref _genres, value);
        }
        private GENRES _selectedGenre;
        public GENRES selectedGenre
        {
            get => _selectedGenre;
            set => Set(ref _selectedGenre, value);
        }
        private ALBUMS _album;
        public ALBUMS album
        {
            get => _album;
            set => Set(ref _album, value);
        }
        private ObservableCollection<TRACKS> _tracks = new ObservableCollection<TRACKS>();
        public ObservableCollection<TRACKS> tracks
        {
            get => _tracks;
            set => Set(ref _tracks, value);
        }
        private void RestorePage()
        {
            tracks = new ObservableCollection<TRACKS>();
            var tracks1 = db.TRACKS.Where(t => t.album_id == album.album_id);
            foreach (TRACKS track in tracks1)
            {
                tracks.Add(track);
            }
            TrackName = "";
            _trackpath = "";
        }

        public ICommand OpenAddTrackCommand { get; }
        public bool CanOpenAddTrackCommandExecuted(object p) => true;
        public void OnOpenAddTrackCommandExecute(object p)
        {
            DialogVisible = true;
        }

        public ICommand SelectFileCommand { get; }
        public bool CanSeectFileCommandExecuted(object p) => true;
        public void OnSelectFileCommandExecute(object p)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Музыка|*.mp3;";
            if (openFileDialog.ShowDialog() == true)
            {
                _trackpath = openFileDialog.FileName;
            }
        }

        public ICommand CreateTrackCommand { get; }
        public bool CanCreateTrackCommandExecuted(object p) => TrackName?.Length > 4 && _trackpath?.Length > 0;
        public void OnCreateTrackCommandExecute(object p)
        {
            try
            {
                TRACKS track = new TRACKS(TrackName, (int)album.id_user, album.album_id, (int)album.genre_id);
                db.TRACKS.Add(track);
                db.SaveChanges();
                File.Copy(_trackpath, $@"D:\MusicService\{album.album_id}\{track.track_name}.mp3", true);
                RestorePage();
                DialogVisible = false;
            }
            catch
            {
                MessageBox.Show("Enter track name");
            }
        }


        public EditAlbumPageViewModel(ALBUMS alb, PlayerViewModel window)
        {
            this.album = alb;
            var tracks = db.TRACKS.Where(t => t.album_id == album.album_id);
            foreach (TRACKS track in tracks)
            {
                _tracks.Add(track);
            }
            OpenAddTrackCommand = new LambdaCommand(OnOpenAddTrackCommandExecute, CanOpenAddTrackCommandExecuted);
            SelectFileCommand = new LambdaCommand(OnSelectFileCommandExecute, CanSeectFileCommandExecuted);
            CreateTrackCommand = new LambdaCommand(OnCreateTrackCommandExecute, CanCreateTrackCommandExecuted);
            genres = db.GENRES.ToList();
        }
    }
}
