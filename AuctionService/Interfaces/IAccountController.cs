using Auction.Models.DTO;

namespace Auction.Infrastructure.Interfaces
{
    public interface IAccountController
    {
        void Login(UserDTO userDto);

        void LogOut();

        int SignUp(UserDTO userDto);

        bool IsAuthentificated { get; }

        UserDTO CurrentUserDto { get; }
    }
}
