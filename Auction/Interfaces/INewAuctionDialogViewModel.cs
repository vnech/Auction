using Auction.Infrastructure.Interfaces;

namespace Auction.Interfaces
{
    public interface INewAuctionDialogViewModel: IViewModel
    {
        Models.DTO.AuctionDTO AuctionDto { get; set; }

        void Create();
    }
}
