using CourseProject_v1._1.Commands;
using CourseProject_v1._1.Models;
using CourseProject_v1._1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProject_v1._1.ViewModels
{
    internal class EditPlaylistViewModel : ViewModel
    {
        private readonly MusicService db = new MusicService();
        private PlayerViewModel _main;
        public PlayerViewModel main
        {
            get => _main;
            set => Set(ref _main, value);
        }
        private List<TRACKS> _TrackList;
        public List<TRACKS> TrackList
        {
            get => _TrackList;
            set => Set(ref _TrackList, value);
        }

        private PLAYLISTS _playlist;
        public PLAYLISTS playlist
        {
            get => _playlist;
            set => Set(ref _playlist, value);
        }
        private List<TRACKS> _playlistList;
        public List<TRACKS> PlaylistList
        {
            get => _playlistList;
            set => Set(ref _playlistList, value);
        }
        private TRACKS _SelectedTrackInTracklist;
        public TRACKS SelectedTrackInTracklist
        {
            get => _SelectedTrackInTracklist;
            set => Set(ref _SelectedTrackInTracklist, value);
        }
        private TRACKS _SelectedTrackInPlaylist;
        public TRACKS SelectedTrackInPlaylist
        {
            get => _SelectedTrackInPlaylist;
            set => Set(ref _SelectedTrackInPlaylist, value);
        }
        public ICommand AddTrackToPlaylistCommand { get; }
        public bool CanAddTrackToPlaylistCommandExecuted(object p) => SelectedTrackInTracklist != null; 
        public void OnAddTrackToPlaylistCommandExecute(object p)
        {
            db.PLAYLISTS.Find(playlist.playlist_id).TRACKS.Add(SelectedTrackInTracklist);
            PlaylistList = db.PLAYLISTS.Find(playlist.playlist_id).TRACKS.ToList();
            TrackList = TrackList.Except(PlaylistList).ToList();

        }

        public ICommand DeleteTrackFromPlaylistCommand { get; }
        public bool CanDeleteTrackFromPlaylistCommandExecuted(object p) => SelectedTrackInPlaylist != null;
        public void OnDeleteTrackFromPlaylistCommandExecute(object p)
        {
            db.PLAYLISTS.Find(playlist.playlist_id).TRACKS.Remove(SelectedTrackInPlaylist);
            TrackList.Add(SelectedTrackInPlaylist);
            TrackList = db.TRACKS.ToList();
            PlaylistList = db.PLAYLISTS.Find(playlist.playlist_id).TRACKS.ToList();
        }

        public ICommand SavePlaylistChangesCommand { get; }
        public bool CanSavePlaylistChangesCommandExecuted(object p) => true;
        public void OnSavePlaylistChangesCommandExecute(object p)
        {
            db.SaveChanges();
            main.selectedVM = new OpenPlaylistViewModel(playlist, main);
        }
        public EditPlaylistViewModel(PLAYLISTS pls, PlayerViewModel window)
        {
            this.playlist = pls;
            main = window;
            TrackList = db.TRACKS.ToList();
            PlaylistList = db.PLAYLISTS.Find(playlist.playlist_id).TRACKS.ToList();
            TrackList = TrackList.Except(PlaylistList).ToList();
            AddTrackToPlaylistCommand = new LambdaCommand(OnAddTrackToPlaylistCommandExecute, CanAddTrackToPlaylistCommandExecuted);
            DeleteTrackFromPlaylistCommand = new LambdaCommand(OnDeleteTrackFromPlaylistCommandExecute, CanDeleteTrackFromPlaylistCommandExecuted);
            SavePlaylistChangesCommand = new LambdaCommand(OnSavePlaylistChangesCommandExecute, CanSavePlaylistChangesCommandExecuted);
        }
    }
}
