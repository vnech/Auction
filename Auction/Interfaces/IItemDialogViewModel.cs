using Auction.Infrastructure.Interfaces;
using Auction.Models.DTO;

namespace Auction.Interfaces
{
    public interface IItemDialogViewModel: IViewModel
    {
        ItemDTO Item { get; set; }

        void Create();

        void Delete();
    }
}
