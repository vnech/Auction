using Caliburn.Micro;

namespace Auction.Models.DTO
{
    public class User: PropertyChangedBase
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
    }
}
