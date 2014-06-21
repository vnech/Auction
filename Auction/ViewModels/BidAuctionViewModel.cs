using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class BidAuctionViewModel: Screen, IBidAuctionViewModel
    {
        private readonly IAuctionBiddingService _auctionBiddingService;

        private AuctionDTO _auction;
        private BidDTO _bidItem;

        public BidAuctionViewModel(IAuctionBiddingService auctionBiddingService)
        {
            _auctionBiddingService = auctionBiddingService;

            BidItem = new BidDTO();
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

        public void Bid()
        {
            _auctionBiddingService.Bid(BidItem);

            BidItem = new BidDTO();
        }

        public void SetAuction(AuctionDTO auction)
        {
            Auction = auction;
        }
    }
}
