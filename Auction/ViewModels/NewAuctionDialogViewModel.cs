using Auction.Interfaces;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class NewAuctionDialogViewModel : Screen, INewAuctionDialogViewModel
    {
        private readonly IAuctionService _auctionService;

        private Models.DTO.AuctionDTO _auctionDto;

        public NewAuctionDialogViewModel(IAuctionService auctionService)
        {
            _auctionService = auctionService;
            AuctionDto = new Models.DTO.AuctionDTO();
        }

        public Models.DTO.AuctionDTO AuctionDto
        {
            get { return _auctionDto; }
            set
            {
                if (Equals(value, _auctionDto)) return;
                _auctionDto = value;
                NotifyOfPropertyChange();
            }
        }

        public void Create()
        {
            _auctionService.NewAuction(AuctionDto);

            AuctionDto = new Auction.Models.DTO.AuctionDTO();
        }

        public bool CanCreate()
        {
            return true;
            //return !string.IsNullOrEmpty(AuctionDTO.ItemName);
        }
    }
}
