using System;
using Auction.Models.DTO;
using Caliburn.Micro;

namespace AuctionService.Services
{
    public class PermissionManager: PropertyChangedBase
    {
        public bool CanAddNewAuctions(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public bool CanAddNewItems(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public bool CanBid(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public bool CanWathAuctions(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
