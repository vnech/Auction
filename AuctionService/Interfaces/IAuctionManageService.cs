﻿using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IAuctionManageService
    {
        int NewAuction(AuctionDTO auction);

        void StartAuction(AuctionDTO auction);

        void EndAuction(AuctionDTO auction);

        void UpdateAuction(AuctionDTO auction);

        bool CanAuctionBeStarted(AuctionDTO auction);

        bool CanAuctionBeEnded(AuctionDTO auction);

        void Delete(AuctionDTO auction);
    }
}
