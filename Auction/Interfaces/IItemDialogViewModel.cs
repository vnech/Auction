using Auction.Infrastructure.Interfaces;

namespace Auction.Interfaces
{
    public interface IItemDialogViewModel: IViewModel
    {
        void Create();

        void Delete();
    }
}
