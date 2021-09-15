using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CourseProject_v1._1.Commands;
using CourseProject_v1._1.Models;
using CourseProject_v1._1.ViewModels.Base;
using CourseProject_v1._1.Views.Windows;

namespace CourseProject_v1._1.ViewModels
{
    internal class RegisterPageViewModel : ViewModel
    {
        private readonly MusicService db = new MusicService();
        private string _Login;
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        private string _Nickname;
        public string Nickname
        {
            get => _Nickname;
            set => Set(ref _Nickname, value);
        }
        private string _Password;
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }
        private bool _DialogVisible = false;
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
        public ICommand CloseDialogCommand { get; }
        public bool CanCloseDialogCommandExecuted(object p) => true;
        public void OnCloseDialogCommandExecute(object p)
        {
            DialogVisible = false;
        }
        public ICommand RegisterCommand { get; }
        private bool CanRegisterCommandExecute(object p) => Login?.Length > 5 && Login?.Length < 25 && (p as PasswordBox).Password?.Length >= 8 && Nickname?.Length > 5 && Nickname?.Length < 30;
        private void OnRegisterCommandExecuted(object p)
        {   
            if(db.USERS.Count(u => u.user_login == Login) != 0 ){
                DialogText = "This login already exists";
                DialogVisible = true;
            }
            else if (db.USERS.Count(u => u.user_nickname == Nickname) != 0)
            {
                DialogText = "This nickname already exists";
                DialogVisible = true;
            }
            else 
            {
                Password = (p as PasswordBox).Password;
                string password = USERS.getHash(Password);
                USERS user = new USERS(Login, password, Nickname);
                db.USERS.Add(user);
                db.SaveChanges();
                PlayerViewModel playerViewModel = new PlayerViewModel(user);
                PlayerWindow playerWindow = new PlayerWindow()
                {
                    DataContext = playerViewModel
                };
                playerWindow.Show();
                App.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public RegisterPageViewModel()
        {
            RegisterCommand = new LambdaCommand(OnRegisterCommandExecuted, CanRegisterCommandExecute);
            CloseDialogCommand = new LambdaCommand(OnCloseDialogCommandExecute, CanCloseDialogCommandExecuted);
        }

    }
}
