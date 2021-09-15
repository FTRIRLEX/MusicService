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
    internal class OpenPlaylistViewModel : ViewModel
    {
        MusicService db = new MusicService();
        private PLAYLISTS _playlist;
        public PLAYLISTS playlist
        {
            get => _playlist;
            set => Set(ref _playlist, value);
        }
        private List<TRACKS> _tracks = new List<TRACKS>();
        public List<TRACKS> tracks
        {
            get => _tracks;
            set => Set(ref _tracks, value);
        }

        private PlayerViewModel _PlayerViewModel;
        public PlayerViewModel PlayerViewModel
        {
            get => _PlayerViewModel;
            set => Set(ref _PlayerViewModel, value);
        }
        public OpenPlaylistViewModel(PLAYLISTS Playlist, PlayerViewModel viewmodel)
        {
            this.playlist = Playlist;
            PlayerViewModel = viewmodel;
            tracks = db.PLAYLISTS.Find(playlist.playlist_id).TRACKS.ToList();
        }
    }
}
