using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IAuctionBiddingService
    {
        void Bid(BidDTO bid, AuctionDTO auction);
    }
}
