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
        private LiveNotification<Auction.Data.Auction> _auctionsChangedNotification;
        private readonly AuctionContext _context;

        public AuctionService()
            : this(new AuctionContext())
        {

        }

        public AuctionService(AuctionContext context)
        {
            _context = context;

            //todo: refactor

            var query = from auction in _context.Auctions select auction;

            _auctionsChangedNotification = new LiveNotification<Auction.Data.Auction>(_context, query);

            _auctionsChangedNotification.OnChanged += AuctionsChangedNotificationOnChanged;
        }

        private void AuctionsChangedNotificationOnChanged(object sender, EventArgs e)
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

            auctionEntity.CreatedAt = DateTime.Now;

            auctionEntity.StartDate = null;

            auction.Status = (int) AuctionStatus.NotStarted;

            auctionEntity = _context.Auctions.Add(auctionEntity);

            _context.SaveChanges();

            return auctionEntity.AuctionId;
        }

        public void StartAuction(AuctionDTO auction)
        {
            var entity = _context.Auctions.FirstOrDefault(a => a.AuctionId == auction.AuctionId);

            if (entity != null)
            {
                entity.StartDate = DateTime.Now;

                entity.Status = (int)AuctionStatus.Started;

                _context.SaveChanges();
            }
        }

        public void EndAuction(AuctionDTO auction)
        {
            var entity = _context.Auctions.FirstOrDefault(a => a.AuctionId == auction.AuctionId);

            if (entity != null)
            {
                entity.Status = (int)AuctionStatus.Ended;

                _context.SaveChanges();
            }
        }

        public bool CanAuctionBeStarted(AuctionDTO auction)
        {
            return auction != null && auction.Status == AuctionStatus.NotStarted;
            //|| auction.Status == AuctionStatus.Suspended;
        }

        public bool CanAuctionBeEnded(AuctionDTO auction)
        {
            return auction != null && auction.Status == AuctionStatus.Started;
        }

        #endregion IAuctionManageService

        #region IAuctionWatcherService

        public event EventHandler OnAuctionsChange;

        public IEnumerable<AuctionDTO> AuctionsGet()
        {
            var auctions = _context.Auctions.ToList();

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
