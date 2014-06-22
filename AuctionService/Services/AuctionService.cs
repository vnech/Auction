using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Data;
using Auction.Data.Notifications;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using AutoMapper;

namespace AuctionService.Services
{
    public class AuctionService : IAuctionService
    {
        public event EventHandler OnAuctionsChange;

        private LiveNotification<Auction.Data.Auction> _notification; 

        private readonly AuctionContext _context;

        public AuctionService()
            : this(new AuctionContext())
        {

        }

        public AuctionService(AuctionContext context)
        {
            this._context = context;


            //todo: refactor

            var query = from auction in _context.Auctions select auction;

            _notification = new LiveNotification<Auction.Data.Auction>(_context, query);

            _notification.OnChanged += Notification_OnChanged;
        }

        private void Notification_OnChanged(object sender, EventArgs e)
        {
            if (OnAuctionsChange != null)
            {
                OnAuctionsChange(this, null);
            }
        }

        #region IAuctionManageService

        public int NewAuction(AuctionDTO auction)
        {
            var auctionEntity = Mapper.Map<Auction.Data.Auction>(auction);

            auctionEntity = _context.Auctions.Add(auctionEntity);

            _context.SaveChanges();

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
            var auctions = _context.Auctions.ToList();

            var x = Mapper.Map<IEnumerable<Auction.Data.Auction>, IEnumerable<AuctionDTO>>(auctions);

            return Mapper.Map<IEnumerable<Auction.Data.Auction>, IEnumerable<AuctionDTO>>(auctions);
        }

        #endregion IAuctionWatcherService

        #region IAuctionBiddingService

        public void Bid(BidDTO bid)
        {
            bid.CreatedAt = DateTime.Now;
            
            var bidEntity = Mapper.Map<Auction.Data.Bid>(bid);

            bidEntity = _context.Bids.Add(bidEntity);

            _context.SaveChanges();
        }

        #endregion IAuctionBiddingService
    }
}
