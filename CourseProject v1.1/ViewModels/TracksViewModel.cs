using CourseProject_v1._1.Commands;
using CourseProject_v1._1.Models;
using CourseProject_v1._1.Models.ENUM;
using CourseProject_v1._1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProject_v1._1.ViewModels
{
    internal class TracksViewModel : ViewModel
    {
        private readonly MusicService db = new MusicService();

        private List<TRACKS> _TrackList;
        public List<TRACKS> TrackList
        {
            get => _TrackList;
            set => Set(ref _TrackList, value);
        }

        private USERS _User;
        public USERS User
        {
            get => _User;
            set => Set(ref _User, value);
        }

        private TRACKS _selectedValue;
        public TRACKS selectedValue
        {
            get => _selectedValue;
            set => Set(ref _selectedValue, value);
        }

        public ICommand LikeTrackCommand { get; }
        private bool CanLikeTrackCommandCommandExecuted(object p) => main.selectedTrack != null && User != null && !db.USERS.Find(User?.id_user).TRACKS1.Contains(main.selectedTrack) && User.user_role != (int)UserRole.Anonim && selectedValue !=null;
        private void OnLikeTrackCommandExecute(object p)
        {
            db.USERS.Find(User.id_user).TRACKS1.Add(main.selectedTrack);
            db.SaveChanges();
        }
        public ICommand UnlikeTrackCommand { get; }
        private bool CanUnlikeTrackCommandExecuted(object p) => main.selectedTrack != null && User != null && db.USERS.Find(User?.id_user).TRACKS1.Contains(main.selectedTrack) && User.user_role != (int)UserRole.Anonim && selectedValue != null;
        private void OnUnlikeTrackCommandExecute(object p)
        {
            db.USERS.Find(User.id_user).TRACKS1.Remove(main.selectedTrack);
            db.SaveChanges();
        }

        private PlayerViewModel _main;
        public PlayerViewModel main
        {
            get => _main;
            set => Set(ref _main, value);
        }

        public TracksViewModel(PlayerViewModel _PlayerWindow, USERS _user)
        {
            this.User = _user;
            TrackList = db.TRACKS.ToList();
            _main = _PlayerWindow;
            LikeTrackCommand = new LambdaCommand(OnLikeTrackCommandExecute, CanLikeTrackCommandCommandExecuted);
            UnlikeTrackCommand = new LambdaCommand(OnUnlikeTrackCommandExecute, CanUnlikeTrackCommandExecuted);
        }
     
    }
}
