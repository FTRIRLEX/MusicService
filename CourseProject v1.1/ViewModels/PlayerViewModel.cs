using CourseProject_v1._1.Commands;
using CourseProject_v1._1.Models;
using CourseProject_v1._1.Models.ENUM;
using CourseProject_v1._1.ViewModels.Base;
using CourseProject_v1._1.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProject_v1._1.ViewModels
{
    internal class PlayerViewModel : ViewModel
    {
        private readonly USERS User;
        private bool IsPlay = false;
        private string track_name;
        private readonly MusicService db = new MusicService();
        public string AccountName
        {
            get
            {
                return User.user_nickname;
            }
        }

        public Visibility AdminVisibility
        {
            get
            {
                return User.user_role == (int)UserRole.Admin ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private bool _DialogVisible;
        public bool DialogVisible
        {
            get => _DialogVisible;
            set => Set(ref _DialogVisible, value);
        }
        private string _DialogText;
        public string DialogText
        {
            get => _DialogText;
            set => Set(ref _DialogText, value);
        }
        private ObservableCollection<TRACKS> _usersTracksList = new ObservableCollection<TRACKS>();
        public ObservableCollection<TRACKS> usersTracksList
        {
            get => _usersTracksList;
            set => Set(ref _usersTracksList, value);
        }

        private ViewModel _selectedVM;
        public ViewModel selectedVM
        {
            get => _selectedVM;
            set => Set(ref _selectedVM, value);
        }
        private string _ButtonPlay = "Play";
        public string ButtonPlay
        {
            get => _ButtonPlay;
            set => Set(ref _ButtonPlay, value);
        }
        private MediaPlayer _MediaPlayer = new MediaPlayer();
        public MediaPlayer MediaPlayer
        {
            get => _MediaPlayer;
            set => Set(ref _MediaPlayer, value);
        }

        private TRACKS _selectedTrack;
        public TRACKS selectedTrack
        {
            get => _selectedTrack;
            set
            {
                _selectedTrack = value;
                Stoping();
                RaisePropertyChanged("selectedTrack");
            }
        }


        private double _SliderMaximum;
        public double SliderMaximum
        {
            get => _SliderMaximum;
            set => Set(ref _SliderMaximum, value);
        }
        public TimeSpan TimeSpan { get; private set; }


        public void Stoping()
        {
            MediaPlayer.Stop();
            ButtonPlay = "Play";
        }

        public ICommand PlayTrackCommand { get; }
        private bool CanPlayTrackCommandExecute(object p) => selectedTrack != null;
        private void OnPlayTrackCommandExecuted(object p)
        {
            if (track_name != selectedTrack.track_name)
            {
                ButtonPlay = "Play";
                MediaPlayer.Stop();
                MediaPlayer.Open(new Uri($@"D:\MusicService\{selectedTrack.album_id}\{selectedTrack.track_name}.mp3"));
                MediaPlayer.Play();
                track_name = selectedTrack.track_name;
                IsPlay = true;
                ButtonPlay = "Pause";
            }
            else
            {
                if (IsPlay)
                {
                    MediaPlayer.Pause();
                    IsPlay = false;
                    ButtonPlay = "Play";
                }
                else
                {
                    MediaPlayer.Play();
                    IsPlay = true;
                    ButtonPlay = "Pause";
                }
            }
        }

        public ICommand CloseDialogCommand { get; }
        public bool CanCloseDialogCommandExecuted(object p) => true;
        public void OnCloseDialogCommandExecute(object p)
        {
            DialogVisible = false;
        }



        private int _SelectedMenuItem;
        public int SelectedMenuItem
        {
            get => _SelectedMenuItem;
            set
            {
                _SelectedMenuItem = value;
                switch (SelectedMenuItem)
                {
                    case 0:
                        {
                            selectedVM = new TracksViewModel(this, User);
                            break;
                        }
                    case 1:
                        {
                            if (User.user_role == (int)UserRole.Anonim)
                            {
                                DialogVisible = true;
                                DialogText = "Зарегестрируйтесь, чтобы получить доступ!";
                            }
                            else
                            {
                                selectedVM = new LikedTracksViewModel(User, this);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (User.user_role == (int)UserRole.Anonim)
                            {
                                DialogVisible = true;
                                DialogText = "Зарегестрируйтесь, чтобы получить доступ!";
                            }
                            else
                            {
                                selectedVM = new PlaylistsPageViewModel(User, this);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (User.user_role == (int)UserRole.Anonim)
                            {
                                DialogVisible = true;
                                DialogText = "Зарегестрируйтесь, чтобы получить доступ!";
                            }
                            else 
                            { 
                            selectedVM = new AlbumsPageViewModel(User, this);
                            }
                            break;
                        }
                    case 5:

                        {
                            MediaPlayer.Stop();
                            App.Current.Shutdown();


                            break;
                        }
                    case 6:
                        {
                            selectedVM = new AdminPagViewModel(this);
                            break;
                        }
                }
            }
        }
        public PlayerViewModel(USERS user)
        {
            this.User = user;
            
            selectedVM = new TracksViewModel(this, user);
            PlayTrackCommand = new LambdaCommand(OnPlayTrackCommandExecuted, CanPlayTrackCommandExecute);
            CloseDialogCommand = new LambdaCommand(OnCloseDialogCommandExecute, CanCloseDialogCommandExecuted);
        }

        private void MediaPlayer_MediaOpened(object sender, EventArgs e)
        {
            SliderMaximum = MediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
            TimeSpan = MediaPlayer.NaturalDuration.TimeSpan;
        }


    }
}
