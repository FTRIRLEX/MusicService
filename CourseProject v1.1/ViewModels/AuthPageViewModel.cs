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
    internal class AuthPageViewModel : ViewModel
    { 
        private readonly MusicService db = new MusicService();
        private string _Login;
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
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
        private string _Password;
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }


        public ICommand DialogCloseCommand { get; }
        private bool CanDialogCloseCommandExecuted(object p) => true;
        private void OnDialogCloseCommandExecute(object p) => DialogVisible = false;
      

        public ICommand AuthCommand { get; }
        private bool CanAuthCommanExecuted(object p) => Login?.Length > 5 && Login?.Length < 25 && (p as PasswordBox).Password?.Length >= 8;
        private void OnAuthCommandExecute(object p)
        {
            Password = (p as PasswordBox).Password;
            Password = USERS.getHash(((p as PasswordBox).Password));
            if (db.USERS.FirstOrDefault(u => u.user_login == Login && u.user_password == Password) != null)
            {
                USERS user = db.USERS.FirstOrDefault(u => u.user_login == Login);
                PlayerViewModel playerViewModel = new PlayerViewModel(user);
                PlayerWindow playerWindow = new PlayerWindow()
                {
                    DataContext = playerViewModel
                };
                playerWindow.Show();
                App.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                DialogVisible = true;
                DialogText = "Такой пользователь не найден";
            }
        }

        public AuthPageViewModel()
        {
            
            AuthCommand = new LambdaCommand(OnAuthCommandExecute, CanAuthCommanExecuted);
            DialogCloseCommand = new LambdaCommand(OnDialogCloseCommandExecute, CanDialogCloseCommandExecuted);
        }
    }
}
