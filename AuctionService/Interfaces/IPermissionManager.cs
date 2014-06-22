using System.ComponentModel;
using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IPermissionManager: INotifyPropertyChanged
    {
        bool CanAddNewAuctions(UserDTO user);

        bool CanAddNewItems(UserDTO user);

        bool CanBid(UserDTO user);

        bool CanWathAuctions(UserDTO user);
    }
}
