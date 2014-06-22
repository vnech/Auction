using System;
using System.Collections.Generic;
using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IAuctionWatcherService
    {
        event EventHandler OnAuctionsChange;

        IEnumerable<AuctionDTO> AuctionsGet();
    }
}
