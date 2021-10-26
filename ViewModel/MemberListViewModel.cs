using LoginForm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace LoginForm.ViewModel
{
    class MemberListViewModel : BaseViewModel
    {
        private ObservableCollection<thanhvien> memberList;

        private thanhvien selectedThanhvien;
        public  thanhvien SelectedThanhvien 
        { 
            get => selectedThanhvien;
            set 
            {
                selectedThanhvien = value;
                OnPropertyChanged();
            } 
        }

        public ICommand ItemSelectedCommand { get; set; }
        public ICommand RemoveThanhvienCommnad { get; set; }
        public ObservableCollection<thanhvien> MemberList
        {
            get { return memberList; }
            set { memberList = value; OnPropertyChanged(); }
        }

        public MemberListViewModel()
        {
            MemberList = new ObservableCollection<thanhvien>(DataProvider.Ins.DB.thanhviens);
            ItemSelectedCommand = new RelayCommand<object>(p => { return true; }, p =>
            {
                SelectedThanhvien = p as thanhvien;
                //MessageBox.Show("Selected a thanhvien "+ SelectedThanhvien.ten);
            });

            RemoveThanhvienCommnad = new RelayCommand<object>(p => { return true; }, p =>
            {
                RemoveSelectedThanhvien();
            });
        }

        private void RemoveSelectedThanhvien()
        {
            MessageBoxResult res = MessageBox.Show("Điều này sẽ vĩnh viễn xoá " + SelectedThanhvien.ten + " ra khỏi danh sách.",
                "Warning!!",
                MessageBoxButton.OKCancel);

            if(res == MessageBoxResult.OK)
            {
                memberList.Remove(SelectedThanhvien);
                SelectedThanhvien = null;
            }
        }
    }
}
