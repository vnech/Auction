using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IAccountController
    {
        bool Login(UserDTO userDto);

        void LogOut();

        void SignUp(UserDTO userDto);

        bool IsAuthentificated { get; }

        UserDTO CurrentUser { get; }
    }
}
