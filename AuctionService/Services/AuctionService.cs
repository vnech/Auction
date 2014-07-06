using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private readonly AuctionContext _context;
        private readonly IQueryable<Auction.Data.Auction> _activeAuctionsQuery;

        //todo: extract
        private readonly int AuctionDurationMinutes = 2; 

        public AuctionService()
            : this(new AuctionContext())
        {

        }

        public AuctionService(AuctionContext context)
        {
            _context = context;

            //todo: refactor

            //get active auctions query
            _activeAuctionsQuery = _context.Auctions.Where(
                a => a.IsActive &&
                    a.Status == (short) AuctionStatus.Started &&
                    DbFunctions.DiffMinutes(DateTime.Now, a.LastBiddedAt) < AuctionDurationMinutes);

            //get all auctions query
            IQueryable<Auction.Data.Auction> allAuctionsQuery = from auction in _context.Auctions where auction.IsActive select auction;

            //subscription to SqlDependency for all auctions changes
            LiveNotification<Auction.Data.Auction> auctionsChangedNotification = new LiveNotification<Auction.Data.Auction>(_context, allAuctionsQuery);

            auctionsChangedNotification.OnChanged += AuctionsChangedNotificationOnChanged;
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

            auctionEntity.Status = (int) AuctionStatus.NotStarted;

            auctionEntity.IsActive = true;

            auctionEntity = _context.Auctions.Add(auctionEntity);

            _context.SaveChanges();

            return auctionEntity.AuctionId;
        }

        public void StartAuction(AuctionDTO auction)
        {
            var entity = _context.Auctions.Where(a => a.IsActive).FirstOrDefault(a => a.AuctionId == auction.AuctionId);

            if (entity != null)
            {
                entity.StartDate = DateTime.Now;

                entity.Status = (int) AuctionStatus.Started;

                entity.CurrentPrice = entity.StartPrice;

                entity.LastBiddedAt = DateTime.Now;

                _context.SaveChanges();
            }
        }

        public void EndAuction(AuctionDTO auction)
        {
            var entity = _context.Auctions.Where(a => a.IsActive).FirstOrDefault(a => a.AuctionId == auction.AuctionId);

            if (entity != null)
            {
                entity.Status = (int) AuctionStatus.Ended;

                _context.SaveChanges();
            }
        }

        public void UpdateAuction(AuctionDTO auction)
        {
            var entity = _context.Auctions.FirstOrDefault(a => a.AuctionId == auction.AuctionId);

            if (entity != null)
            {
                entity = Mapper.Map<AuctionDTO, Auction.Data.Auction>(auction, entity);

                _context.SaveChanges();
            }
        }

        public bool CanAuctionBeStarted(AuctionDTO auction)
        {
            return auction != null && auction.Status == AuctionStatus.NotStarted;
        }

        public bool CanAuctionBeEnded(AuctionDTO auction)
        {
            return auction != null && auction.Status == AuctionStatus.Started;
        }

        public void Delete(AuctionDTO auction)
        {
            var entity = _context.Auctions.FirstOrDefault(a => a.AuctionId == auction.AuctionId);

            if (entity != null)
            {
                entity.IsActive = false;

                _context.SaveChanges();
            }
        }

        #endregion IAuctionManageService

        #region IAuctionWatcherService

        public event EventHandler OnAuctionsChange;

        public IEnumerable<AuctionDTO> AuctionsAllGet()
        {
            using (var context = new AuctionContext())
            {
                var auctions = context.Auctions.Where(a => a.IsActive).ToList();

                return Mapper.Map<IEnumerable<Auction.Data.Auction>, IEnumerable<AuctionDTO>>(auctions);
            }
        }

        #endregion IAuctionWatcherService

        #region IAuctionBiddingService

        public void Bid(BidDTO bid)
        {
            throw new NotImplementedException();

            bid.CreatedAt = DateTime.Now;

            var bidEntity = Mapper.Map<Auction.Data.Bid>(bid);

            bidEntity = _context.Bids.Add(bidEntity);

            _context.SaveChanges();
        }

        #endregion IAuctionBiddingService
    }
}
