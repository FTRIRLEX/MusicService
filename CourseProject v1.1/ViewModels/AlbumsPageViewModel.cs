using CourseProject_v1._1.Commands;
using CourseProject_v1._1.Models;
using CourseProject_v1._1.Models.ENUM;
using CourseProject_v1._1.ViewModels.Base;
using CourseProject_v1._1.Views.Windows;
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
using System.Windows.Media.Imaging;

namespace CourseProject_v1._1.ViewModels
{
    class AlbumsPageViewModel : ViewModel
    {
        private readonly MusicService db = new MusicService();
        private readonly USERS user;
        private readonly BitmapImage _noPhoto = new BitmapImage(new Uri(@"D:/MusicService/NoPhoto.png"));

        private PlayerViewModel _PlayerViewModel;
        public PlayerViewModel PlayerViewModel
        {
            get => _PlayerViewModel;
            set => Set(ref _PlayerViewModel, value);
        }
        private List<ALBUMS> _AlbumList;
        public List<ALBUMS> AlbumList
        {
            get => _AlbumList;
            set => Set(ref _AlbumList, value);
        }
        private bool _DialogVisible = false;
        public bool DialogVisible
        {
            get => _DialogVisible;
            set => Set(ref _DialogVisible, value);
        }
        private string _AlbumName;
        public string AlbumName
        {
            get => _AlbumName;
            set => Set(ref _AlbumName, value);
        }
        private BitmapImage _albumPicture;
        public BitmapImage albumPicture
        {
            get => _albumPicture;
            set => Set(ref _albumPicture, value);
        }
        private string _imgPath;
        

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

        private ALBUMS _selectedAlbum;
        public ALBUMS selectedAlbum
        {
            get => _selectedAlbum;
            set => Set(ref _selectedAlbum, value);
        }

        private void RestoreForm()
        {
            AlbumName = null;
            albumPicture = _noPhoto;
            _imgPath = null;
        }

        public ICommand OpenCreateAlbumCommand { get; }
        public bool CanOpenCreateAlbumCommandExecuted(object p) => user.user_role == (int)UserRole.Signer;
        public void OnOpenCreateAlbumCommandExecude(object p)
        {
            DialogVisible = true;
        }
        public ICommand OpenAlbumCommand { get; }
        public bool CanOpenAlbumCommandExecuted(object p) => selectedAlbum != null;
        public void OnOpenAlbumCommandExecute(object p)
        {
            PlayerViewModel.selectedVM = new OpenAlbumViewModel(selectedAlbum, PlayerViewModel);
        }
        public ICommand ChooseCoverCommand { get; }
        public bool CanChooseCoverCommandExecuted(object p) => true;
        public void OnChooseCoverCommandExecude(object p)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Photo|*.jpg;";
            if(openFileDialog.ShowDialog() == true)
            {
                albumPicture = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                _imgPath = openFileDialog.FileName;
            }
        }
        public ICommand CreateAlbumCommand { get; }
        public bool CanCreateAlbumCommandExecuted(object p) => AlbumName != null && _imgPath != null && AlbumName.Length < 40 && selectedGenre != null;
        public void OnCreateAlbumCommandExecude(object p)
        {
            ALBUMS alb = new ALBUMS(selectedGenre.genre_id, user.id_user, AlbumName);
            db.ALBUMS.Add(alb);
            db.SaveChanges();
            Directory.CreateDirectory($@"D:\MusicService\{alb.album_id}");
            File.Copy(_imgPath, $@"D:\MusicService\{alb.album_id}\cover.jpg", true);
            AlbumList = db.ALBUMS.ToList();
            DialogVisible = false; 
            RestoreForm();
        }
        public ICommand EditAlbumCommand { get; }
        public bool CanEditAlbumCommandExecuted(object p) => selectedAlbum != null && selectedAlbum.id_user == user.id_user && user.user_role == (int)UserRole.Signer;
        public void OnEditAlbumCommandExecute(object p)
        {
            PlayerViewModel.selectedVM = new EditAlbumPageViewModel(selectedAlbum, PlayerViewModel);
        }
        public ICommand CloseCreateAlbumCommand { get; }
        public bool CanCloseCreateAlbumCommandExecuted(object p) => true;
        public void OnCloseCreateAlbumCommandExecute(object p)
        {
            DialogVisible = false;
        }
  


        public AlbumsPageViewModel(USERS user, PlayerViewModel viewmodel)
        {
            RestoreForm();
            PlayerViewModel = viewmodel;
            this.user = user;
            AlbumList = db.ALBUMS.ToList();
            genres = db.GENRES.ToList();
            OpenCreateAlbumCommand = new LambdaCommand(OnOpenCreateAlbumCommandExecude, CanOpenCreateAlbumCommandExecuted);
            ChooseCoverCommand = new LambdaCommand(OnChooseCoverCommandExecude, CanChooseCoverCommandExecuted);
            CreateAlbumCommand = new LambdaCommand(OnCreateAlbumCommandExecude, CanCreateAlbumCommandExecuted);
            EditAlbumCommand = new LambdaCommand(OnEditAlbumCommandExecute, CanEditAlbumCommandExecuted);
            OpenAlbumCommand = new LambdaCommand(OnOpenAlbumCommandExecute, CanOpenAlbumCommandExecuted);
            CloseCreateAlbumCommand = new LambdaCommand(OnCloseCreateAlbumCommandExecute, CanCloseCreateAlbumCommandExecuted);
        }
       
        
      
    }
}
