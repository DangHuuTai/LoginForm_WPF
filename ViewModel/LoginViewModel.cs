using LoginForm.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoginForm.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }

        private string inputUserName;
        public string InputUserName { get => inputUserName; set { inputUserName = value; } }
        private string inputPassword;
        public string InputPassword { get => inputPassword; set { inputPassword = value; } }

        public string DisplayName { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChanged { get; set; }

        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Login(p);
            });

            PasswordChanged = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                InputPassword = p.Password;
            });

        }

        private void Login(Window p)
        {
            if (p == null)
            {
                return;
            }

            IsLogin = true;
            if (CheckLoginInfor(InputUserName, InputPassword))
            {
                MessageBox.Show("Đăng nhập thành công!\nChào " + DisplayName);
                MemberListWindow memberListWindow = new MemberListWindow();
                memberListWindow.Show();
                p.Close();
            }
            else
            {
                MessageBox.Show("Kiểm tra lại thông tin đăng nhập\n" + InputPassword);
            }
        }

        private bool CheckLoginInfor(string username, string password)
        {
            var res = DataProvider.Ins.DB.thanhviens.Where(x => x.tai_khoan == username && x.mat_khau == password);
            if (res.Count() > 0)
            {
                DisplayName = res.First().ten;
                return true;
            }
            return false;

        }

        //private void GetLoginData()
        //{
        //    //this is for mysql
        //    string connectionString = "SERVER=localhost; DATABASE=hoc_mysql; UID=root; PASSWORD=";

        //    MySqlConnection connection = new MySqlConnection(connectionString);

        //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM thanhvien", connection);
        //    try
        //    {
        //        connection.Open();
        //        DataTable dt = new DataTable();
        //        dt.Load(cmd.ExecuteReader());
        //        connection.Close();

        //        name = dt.Rows[0]["tai_khoan"].ToString();
        //        pass = dt.Rows[0]["mat_khau"].ToString();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("failed to connect to database!\n" + e.Message);
        //    }



        //}
    }
}