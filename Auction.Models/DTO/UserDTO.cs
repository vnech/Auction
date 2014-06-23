using Auction.Infrastructure.Interfaces;
using Caliburn.Micro;

namespace Auction.Models.DTO
{
    public class UserDTO : PropertyChangedBase, IResetable
    {
        private string _userName;
        private string _password;
        private byte _userLevel;
        public int UserId { get; set; }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value == _userName) return;
                _userName = value;
                NotifyOfPropertyChange();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password) return;
                _password = value;
                NotifyOfPropertyChange();
            }
        }

        public byte UserLevel
        {
            get { return _userLevel; }
            set
            {
                if (value == _userLevel) return;
                _userLevel = value;
                NotifyOfPropertyChange();
            }
        }

        public void Reset()
        {
            UserName = string.Empty;
            Password = string.Empty;
            UserLevel = 0;

            this.Refresh();
        }
    }
}
