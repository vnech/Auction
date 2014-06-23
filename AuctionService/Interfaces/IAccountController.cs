using System.ComponentModel;
using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IAccountController: INotifyPropertyChanged
    {
        bool Login(UserDTO userDto);

        void LogOut();

        bool SignUp(UserDTO user);

        bool IsAuthentificated { get; }

        bool IsAdmin { get; }

        UserDTO CurrentUser { get; }
    }
}
