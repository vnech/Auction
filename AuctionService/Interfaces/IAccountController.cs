using System.ComponentModel;
using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IAccountController: INotifyPropertyChanged
    {
        bool Login(UserDTO userDto);

        void LogOut();

        void SignUp(UserDTO userDto);

        bool IsAuthentificated { get; }

        bool IsAdmin { get; }

        UserDTO CurrentUser { get; }
    }
}
