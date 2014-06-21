using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {
        private IAccountController _accountController;
        private UserDTO _user;

        public LoginViewModel(IAccountController accountController)
        {
            this._accountController = accountController;
            _user = new UserDTO();
        }

        public UserDTO User
        {
            get { return _user; }
            set
            {
                if (Equals(value, _user)) return;
                _user = value;
                NotifyOfPropertyChange();
            }
        }

        public void Confirm()
        {
            var isLoggedIn = _accountController.Login(User);

            if (!isLoggedIn)
            {
                _accountController.SignUp(User);
            }

            User = new UserDTO();

            TryClose();
        }

        public bool CanConfirm()
        {
            return true;
        }
    }
}
