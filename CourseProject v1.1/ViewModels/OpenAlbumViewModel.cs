using CourseProject_v1._1.Models;
using CourseProject_v1._1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_v1._1.ViewModels
{
    internal class OpenAlbumViewModel : ViewModel
    {
        MusicService db = new MusicService();
        private ALBUMS _album;
        public ALBUMS album
        {
            get => _album;
            set => Set(ref _album, value);
        }

        private PlayerViewModel _PlayerViewModel;
        public PlayerViewModel PlayerViewModel
        {
            get => _PlayerViewModel;
            set => Set(ref _PlayerViewModel, value);
        }

        private ObservableCollection<TRACKS> _tracks = new ObservableCollection<TRACKS>();
        public ObservableCollection<TRACKS> tracks
        {
            get => _tracks;
            set => Set(ref _tracks, value);
        }
        public OpenAlbumViewModel(ALBUMS album, PlayerViewModel viewmodel)
        {
            this.album = album;
            PlayerViewModel = viewmodel;
            var tracks = db.TRACKS.Where(t => t.album_id == album.album_id);
            foreach (TRACKS track in tracks)
            {
                _tracks.Add(track);
            }
        }
    }
}
