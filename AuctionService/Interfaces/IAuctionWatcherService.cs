using System.Collections.Generic;
using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IAuctionWatcherService
    {
        IEnumerable<AuctionDTO> AuctionsGet();
    }
}
