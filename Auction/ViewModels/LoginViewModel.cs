using Auction.Infrastructure.Interfaces;
using Auction.Interfaces;
using Auction.Models.DTO;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {
        private IAccountController _accountController;
        private User _user;

        public LoginViewModel(IAccountController accountController)
        {
            this._accountController = accountController;
            _user = new User();
        }

        public User User
        {
            get { return _user; }
            set
            {
                if (Equals(value, _user)) return;
                _user = value;
                NotifyOfPropertyChange();
            }
        }

        public void Login()
        {

        }

        public void Confirm()
        {
            _accountController.SignUp(User);
        }

        public bool CanConfirm()
        {
            return true;
        }
    }
}
