using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Data;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using AutoMapper;

namespace AuctionService.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly AuctionContext context;

        public AuctionService()
            : this(new AuctionContext())
        {

        }

        public AuctionService(AuctionContext context)
        {
            this.context = context;
        }

        #region IAuctionManageService

        public int NewAuction(AuctionDTO auctionDto)
        {
            var auctionEntity = Mapper.Map<Auction.Data.Auction>(auctionDto);

            auctionEntity = context.Auctions.Add(auctionEntity);

            context.SaveChanges();

            return auctionEntity.AuctionId;
        }

        public void StartAuction()
        {

        }

        public void EndAuction()
        {
        }

        #endregion IAuctionManageService

        #region IAuctionWatcherService

        public IEnumerable<AuctionDTO> AuctionsGet()
        {
            var auctions = context.Auctions.ToList();

            var x = Mapper.Map<IEnumerable<Auction.Data.Auction>, IEnumerable<AuctionDTO>>(auctions);

            return Mapper.Map<IEnumerable<Auction.Data.Auction>, IEnumerable<AuctionDTO>>(auctions);
        }

        #endregion IAuctionWatcherService

        #region IAuctionBiddingService

        public void Bid(BidDTO bid)
        {
            bid.CreatedAt = DateTime.Now;
            
            var bidEntity = Mapper.Map<Auction.Data.Bid>(bid);

            bidEntity = context.Bids.Add(bidEntity);

            context.SaveChanges();
        }

        #endregion IAuctionBiddingService
    }
}
