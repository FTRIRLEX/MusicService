using CourseProject_v1._1.Commands;
using CourseProject_v1._1.Models;
using CourseProject_v1._1.Models.ENUM;
using CourseProject_v1._1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CourseProject_v1._1.ViewModels
{
    internal class AdminPagViewModel : ViewModel
    {
        MusicService db = new MusicService();
        private PlayerViewModel _PlayerViewModel;
        public PlayerViewModel PlayerViewModel
        {
            get => _PlayerViewModel;
            set => Set(ref _PlayerViewModel, value);
        }
        private bool _DialogVisibility = false;
        public bool DialogVisibility
        {
            get => _DialogVisibility;
            set => Set(ref _DialogVisibility, value);
        }
        private List<USERS> _AccountsList;
        public List<USERS> AccountsList
        {
            get => _AccountsList;
            set => Set(ref _AccountsList, value);
        }
        private int _selectRole;
        public int selectRole
        {
            get => _selectRole;
            set => Set(ref _selectRole, value);
        }
        private string _searchString;
        public string searchString
        {
            get => _searchString;
            set => Set(ref _searchString, value);
        }
        private USERS _selectedAccount;
        public USERS selectedAccount
        {
            get => _selectedAccount;
            set => Set(ref _selectedAccount, value);
        }
        public ICommand OpenDialogCommand { get; }
        public bool CanOpenDialogCommandExecuted(object p) => selectedAccount != null;
        public void OnOpenDialogCommandExecute(object p)
        {
            DialogVisibility = true;
        }
        public ICommand CloseDialogCommand { get; }
        public bool CanCloseDialogCommandExecuted(object p) => true;
        public void OnCloseDialogCommandExecute(object p)
        {
            DialogVisibility = false;
        }
        public ICommand SearchCommand { get; }
        public bool CanSearchCommandExecuted(object p) => true;
        public void OnSearchCommandExecuted(object p)
        {
            AccountsList = db.USERS.Where(us => us.user_nickname.Contains(searchString) && us.user_role != (int)UserRole.Admin && us.user_role != (int)UserRole.Anonim).ToList();
        }
        public ICommand AccountDeleteCommand { get; }
        public bool CanAccountDeleteCommandExecuted(object p) => selectedAccount != null;
        public void OnAccountDeleteCommandExecute(object p)
        {
            try
            {
                if (PlayerViewModel.selectedTrack?.id_user == selectedAccount.id_user)
                {
                    PlayerViewModel.Stoping();
                    PlayerViewModel.selectedTrack = null;
                }
                foreach (USERS us in db.USERS)
                {
                    foreach (TRACKS tr in db.TRACKS.Where(tr => tr.id_user == selectedAccount.id_user).ToList())
                    {
                        db.USERS.Find(us.id_user).TRACKS1.Remove(tr);
                    }
                }
                foreach (PLAYLISTS pl in db.PLAYLISTS)
                {
                    foreach (TRACKS track in db.PLAYLISTS.Find(pl.playlist_id).TRACKS.Where(tr1 => tr1.id_user == selectedAccount.id_user).ToList())
                    {
                        db.PLAYLISTS.Find(pl.playlist_id).TRACKS.Remove(track);
                    }
                }
                foreach (PLAYLISTS pl in db.PLAYLISTS.Where(pl => pl.id_user == selectedAccount.id_user))
                {
                    foreach (TRACKS tr in db.PLAYLISTS.Find(pl.playlist_id).TRACKS.ToList())
                    {
                        db.PLAYLISTS.Find(pl.playlist_id).TRACKS.Remove(tr);
                    }
                    db.PLAYLISTS.Remove(pl);
                }
                foreach (TRACKS tr in db.TRACKS.Where(tr => tr.id_user == selectedAccount.id_user))
                {
                    db.TRACKS.Remove(tr);
                }
                foreach (ALBUMS al in db.ALBUMS.Where(al => al.id_user == selectedAccount.id_user))
                {
                    db.ALBUMS.Remove(al);
                }
                db.USERS.Remove(selectedAccount);
                db.SaveChanges();
                AccountsList = db.USERS.Where(us => us.user_role != (int)UserRole.Anonim && us.user_role != (int)UserRole.Admin).ToList();
            }
            catch
            {
                MessageBox.Show("Whoooooops.....");
            }
        }

        public ICommand ChangeRoleCommand { get; }
        public bool CanChangeRoleCommand(object p) => selectedAccount != null;
        public void OnChangeRoleCommandExecute(object p)
        {
            try
            { 
            selectedAccount.user_role = selectRole;
            db.SaveChanges();
            AccountsList = db.USERS.Where(us => us.user_role != (int)UserRole.Anonim && us.user_role != (int)UserRole.Admin).ToList();
            DialogVisibility = false;
            }
            catch
            {
                MessageBox.Show("Whoooooops.....");
            }
        }
        public AdminPagViewModel(PlayerViewModel viewmodel)
        {
            PlayerViewModel = viewmodel;
            AccountsList = db.USERS.Where(us => us.user_role != (int)UserRole.Anonim && us.user_role != (int)UserRole.Admin).ToList();
            AccountDeleteCommand = new LambdaCommand(OnAccountDeleteCommandExecute, CanAccountDeleteCommandExecuted);
            SearchCommand = new LambdaCommand(OnSearchCommandExecuted, CanSearchCommandExecuted);
            ChangeRoleCommand = new LambdaCommand(OnChangeRoleCommandExecute, CanChangeRoleCommand);
            OpenDialogCommand = new LambdaCommand(OnOpenDialogCommandExecute, CanOpenDialogCommandExecuted);
            CloseDialogCommand = new LambdaCommand(OnCloseDialogCommandExecute, CanCloseDialogCommandExecuted);
        }
    }
}
