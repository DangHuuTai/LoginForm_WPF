using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LoginForm.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public MainViewModel()
        {
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            });
        }
    }
}