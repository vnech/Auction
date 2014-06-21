using Auction.Infrastructure.Interfaces;
using Auction.Interfaces;
using Auction.Models.DTO;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {
        private IAccountController _accountController;
        private UserDTO _userDto;

        public LoginViewModel(IAccountController accountController)
        {
            this._accountController = accountController;
            _userDto = new UserDTO();
        }

        public UserDTO UserDto
        {
            get { return _userDto; }
            set
            {
                if (Equals(value, _userDto)) return;
                _userDto = value;
                NotifyOfPropertyChange();
            }
        }

        public void Login()
        {

        }

        public void Confirm()
        {
            _accountController.SignUp(UserDto);

            UserDto = new UserDTO();
        }

        public bool CanConfirm()
        {
            return true;
        }
    }
}
