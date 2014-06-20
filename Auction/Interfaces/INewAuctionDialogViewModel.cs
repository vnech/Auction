using Auction.Infrastructure.Interfaces;

namespace Auction.Interfaces
{
    public interface INewAuctionDialogViewModel: IViewModel
    {
        Models.DTO.Auction Auction { get; set; }

        void Create();
    }
}
