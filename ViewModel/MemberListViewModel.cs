using LoginForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LoginForm.ViewModel
{
    class MemberListViewModel : BaseViewModel
    {
        private List<thanhvien> memberList;
        public List<thanhvien> MemberList
        {
            get { return memberList; }
            set { memberList = value; }
        }

        public MemberListViewModel()
        {
            MemberList = DataProvider.Ins.DB.thanhviens.ToList();

        }
    }
}
