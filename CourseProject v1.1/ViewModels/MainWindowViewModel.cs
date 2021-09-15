using CourseProject_v1._1.Commands;
using CourseProject_v1._1.Models;
using CourseProject_v1._1.ViewModels.Base;
using CourseProject_v1._1.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProject_v1._1.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private bool _IsRegister;
        public bool IsRegister
        {
            get => _IsRegister;
            set => Set(ref _IsRegister, value);
        }
        private bool _IsLogin = true;
        public bool IsLogin
        {
            get => _IsLogin;
            set => Set(ref _IsLogin, value);
        }
        private ViewModel _selectedVM = new AuthPageViewModel();
        public ViewModel selectedVM
        {
            get => _selectedVM;
            set => Set(ref _selectedVM, value);
        }

        public ICommand SwitchLoginCommand { get; }
        private bool CanSwitchLoginCommandExecute(object p) => true;
        private void OnSwitchLoginCommandExecuted(object p)
        {
            switch (p.ToString())
            {
                case "RegisterView":
                    selectedVM = new RegisterPageViewModel();
                    IsRegister = true;
                    IsLogin = false;
                    break;
                case "SignInView":
                    selectedVM = new AuthPageViewModel();
                    IsRegister = false;
                    IsLogin = true;
                    break;
            }
        }



        public ICommand GuestCommand { get; }
        private bool CanGuestCommandExecuted(object p) => true;
        private void OnGuestCommandExecute(object p)
        {
            PlayerViewModel playerViewModel = new PlayerViewModel(new MusicService().USERS.Find(1009));
            PlayerWindow playerWindow = new PlayerWindow()
            {
                DataContext = playerViewModel
            };
            playerWindow.Show();
            App.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;

        }
        public MainWindowViewModel()
        {
            SwitchLoginCommand = new LambdaCommand(OnSwitchLoginCommandExecuted,CanSwitchLoginCommandExecute);
            GuestCommand = new LambdaCommand(OnGuestCommandExecute, CanGuestCommandExecuted);
        }
    }
}
