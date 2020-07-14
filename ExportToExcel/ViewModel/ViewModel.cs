using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SfDataGridDemo
{
    public class UserInfoViewModel : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public UserInfoViewModel()
        {
            UserDetails1 = new UserInfoRepository().GetUserDetails1(100);
            UserDetails2 = new UserInfoRepository().GetUserDetails2(100);
        }

        private ObservableCollection<UserInfo> userDetails1;
        public ObservableCollection<UserInfo> UserDetails1
        {
            get { return userDetails1; }
            set { userDetails1 = value; RaisePropertyChanged("UserDetails"); }
        }

        private ObservableCollection<UserInfo> userDetails2;
        public ObservableCollection<UserInfo> UserDetails2
        {
            get { return userDetails2; }
            set { userDetails2 = value; RaisePropertyChanged("UserDetails2"); }
        }

        public void Dispose()
        {
            if (UserDetails1 != null)
                UserDetails1.Clear();
        }

        
        private bool _isopen=false;
        public bool isOpen
        {
            get { return _isopen; }
            set { _isopen = value; RaisePropertyChanged("isOpen"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
