using System.Collections.Generic;

namespace AuctionService.Interfaces
{
    public interface IAuctionWatcherService
    {
        IEnumerable<Auction.Models.DTO.Auction> AuctionsGet();
    }
}
