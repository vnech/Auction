using Auction.Interfaces;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class NewAuctionDialogViewModel : Screen, INewAuctionDialogViewModel
    {
        private readonly IAuctionService _auctionService;

        private Models.DTO.AuctionDTO _auction;

        public NewAuctionDialogViewModel(IAuctionService auctionService)
        {
            _auctionService = auctionService;
            Auction = new Models.DTO.AuctionDTO();
        }

        public Models.DTO.AuctionDTO Auction
        {
            get { return _auction; }
            set
            {
                if (Equals(value, _auction)) return;
                _auction = value;
                NotifyOfPropertyChange();
            }
        }

        public void Create()
        {
            _auctionService.NewAuction(Auction);

            Auction = new Auction.Models.DTO.AuctionDTO();

            TryClose(true);
        }

        public bool CanCreate()
        {
            return true;
            //return !string.IsNullOrEmpty(AuctionDTO.ItemName);
        }
    }
}
