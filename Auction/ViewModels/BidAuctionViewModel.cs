using System;
using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class BidAuctionViewModel: Screen, IBidAuctionViewModel
    {
        private readonly IAuctionBiddingService _auctionBiddingService;
        private readonly IAuctionService _auctionService;
        private readonly IAccountController _accountController;

        private AuctionDTO _auction;
        private BidDTO _bidItem;

        public BidAuctionViewModel(IAuctionService auctionService, IAccountController accountController)
        {
            _auctionService = auctionService;
            _accountController = accountController;

            BidItem = new BidDTO();

            BidItem.PropertyChanged += BidItem_PropertyChanged;
        }

        public BidDTO BidItem
        {
            get { return _bidItem; }
            set
            {
                if (Equals(value, _bidItem)) return;
                _bidItem = value;
                NotifyOfPropertyChange();
            }
        }

        public AuctionDTO Auction
        {
            get { return _auction; }
            private set
            {
                if (Equals(value, _auction)) return;
                _auction = value;
                NotifyOfPropertyChange();
            }
        }

        public bool CanBid
        {
            get
            {
                return BidItem.Amount > 0 && Auction.Status == AuctionStatus.Started && Auction.ItemId > 0;
            }
        }

        public void Bid()
        {
            Auction.LastBiddedAt = DateTime.Now;

            Auction.BidderId = _accountController.CurrentUser.UserId;

            Auction.CurrentPrice += BidItem.Amount;

            _auctionService.UpdateAuction(Auction);

            BidItem = new BidDTO();

            TryClose(true);
        }

        public void SetAuction(AuctionDTO auction)
        {
            Auction = auction;
        }

        private void BidItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyOfPropertyChange(() => CanBid);
        }
    }
}
