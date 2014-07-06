using Auction.Infrastructure.Constants;
using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {
        private readonly IAccountController _accountController;
        private UserDTO _user;
        private string _errorMessage;

        public LoginViewModel(IAccountController accountController)
        {
            _accountController = accountController;

            UserInitiallize();
        }

        private void User_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyOfPropertyChange(() => CanConfirm);
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value == _errorMessage) return;
                _errorMessage = value;
                NotifyOfPropertyChange();
            }
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
                isLoggedIn = _accountController.SignUp(User);
                if (!isLoggedIn)
                {
                    ErrorMessage = ErrorMessages.IncorrectCreadentials;
                    return;
                }
            }

            TryClose(true);
        }

        public bool CanConfirm
        {
            get
            {
                return !string.IsNullOrEmpty(User.UserName) && !string.IsNullOrEmpty(User.Password);
            }
        }

        #region Helpers

        private void UserInitiallize()
        {
            _user = new UserDTO();

            User.PropertyChanged += User_PropertyChanged;
        }

        #endregion Helpers

        protected override void OnDeactivate(bool close)
        {
            UserInitiallize();

            ErrorMessage = string.Empty;
            base.OnDeactivate(close);
        }
    }
}
