using Auction.Infrastructure.Interfaces;

namespace Auction.Interfaces
{
    public interface INewAuctionDialogViewModel: IViewModel
    {
        Models.DTO.AuctionDTO Auction { get; set; }

        void Create();
    }
}
