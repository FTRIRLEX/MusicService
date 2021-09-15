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
    class LikedTracksViewModel : ViewModel
    {
        private readonly MusicService db = new MusicService();
        private PlayerViewModel _main;
        public PlayerViewModel main
        {
            get => _main;
            set => Set(ref _main, value);
        }
        private USERS _user;
        public USERS user
        {
            get => _user;
            set => Set(ref _user, value);
        }
        private ObservableCollection<TRACKS> _likedTracks = new ObservableCollection<TRACKS>();
        public ObservableCollection<TRACKS> likedTracks
        {
            get => _likedTracks;
            set => Set(ref _likedTracks, value);
        }
        public LikedTracksViewModel(USERS _user, PlayerViewModel _main)
        {
            this.user = _user;
            this.main = _main;
            foreach(TRACKS tr in db.USERS.Find(user.id_user).TRACKS1)
            {
                likedTracks.Add(tr);
            }
        }
    }
}
