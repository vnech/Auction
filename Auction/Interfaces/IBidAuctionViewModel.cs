using Auction.Infrastructure.Interfaces;
using Auction.Models.DTO;

namespace Auction.Interfaces
{
    public interface IBidAuctionViewModel: IViewModel
    {
        AuctionDTO Auction { get; }

        void Bid();

        void SetAuction(AuctionDTO auction);
    }
}
