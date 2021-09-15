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
    internal class PlaylistsPageViewModel : ViewModel
    {
        private readonly MusicService db = new MusicService();
        private readonly USERS user;

        private List<PLAYLISTS> _PlaylistList;
        public List<PLAYLISTS> PlaylistList
        {
            get => _PlaylistList;
            set => Set(ref _PlaylistList, value);
        }


        private PLAYLISTS _SelectedPlaylist;
        public PLAYLISTS SelectedPlaylist
        {
            get => _SelectedPlaylist;
            set => Set(ref _SelectedPlaylist, value);
        }

        private string _PlaylistName;
        public string PlayListName
        {
            get => _PlaylistName;
            set => Set(ref _PlaylistName, value);
        }

        private bool _DialogVisible = false;
        public bool DialogVisible
        {
            get => _DialogVisible;
            set => Set(ref _DialogVisible, value);
        }


        private PlayerViewModel _PlayerViewModel;
        public PlayerViewModel PlayerViewModel
        {
            get => _PlayerViewModel;
            set => Set(ref _PlayerViewModel, value);
        }

        public ICommand OpenCreatePlaylistCommand { get; }
        public bool CanOpenCreatePlaylistCommandExecuted(object p) => true;
        public void OnOpenCreatePlaylistCommandExecute(object p)
        {
            DialogVisible = true;
        }

        public ICommand CloseCreatePlaylistCommand { get; }
        public bool CanCloseCreatePlaylistCommandExecuted(object p) => true;
        public void OnCloseCreatePlaylistCommandExecute(object p)
        {
            DialogVisible = false;
        }

        public ICommand CreatePlaylistCommand { get; }
        public bool CanCreatePlaylistCommandExecuted(object p) => PlayListName?.Length > 5 && PlayListName?.Length < 40;
        public void OnCreatePlaylistCommandExecute(object p)
        {
            PLAYLISTS pl = new PLAYLISTS(user.id_user, PlayListName);
            db.PLAYLISTS.Add(pl);
            db.SaveChanges();
            PlaylistList = db.PLAYLISTS.Where(pl1 => pl1.id_user == user.id_user).ToList();
            DialogVisible = false;
        }

        public ICommand EditPlaylistCommand { get; }
        public bool CanEditPlaylistCommandExecuted(object p) => SelectedPlaylist != null;
        public void OnEditPlaylistCommandExecute(object p)
        {
            PlayerViewModel.selectedVM = new EditPlaylistViewModel(SelectedPlaylist, PlayerViewModel);
        }
        public ICommand OpenPlaylistCommand { get; }
        public bool CanOpenPlaylistCommandExecuted(object p) => SelectedPlaylist != null;
        public void OnOpenPlaylistCommandExecuted(object p)
        {
            PlayerViewModel.selectedVM = new OpenPlaylistViewModel(SelectedPlaylist, PlayerViewModel);
        }
        public PlaylistsPageViewModel(USERS user, PlayerViewModel viewmodel)
        {
            PlayerViewModel = viewmodel;
            this.user = user;
            PlaylistList = db.PLAYLISTS.Where(pl => pl.id_user == user.id_user).ToList();
            EditPlaylistCommand = new LambdaCommand(OnEditPlaylistCommandExecute, CanEditPlaylistCommandExecuted);
            OpenCreatePlaylistCommand = new LambdaCommand(OnOpenCreatePlaylistCommandExecute, CanOpenCreatePlaylistCommandExecuted);
            CloseCreatePlaylistCommand = new LambdaCommand(OnCloseCreatePlaylistCommandExecute, CanCloseCreatePlaylistCommandExecuted);
            CreatePlaylistCommand = new LambdaCommand(OnCreatePlaylistCommandExecute, CanCreatePlaylistCommandExecuted);
            OpenPlaylistCommand = new LambdaCommand(OnOpenPlaylistCommandExecuted, CanOpenPlaylistCommandExecuted);
        }

      
        

    }
}
