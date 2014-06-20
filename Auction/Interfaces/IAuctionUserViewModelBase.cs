using Auction.Infrastructure.Interfaces;

namespace Auction.Interfaces
{
    public interface IAuctionUserViewModelBase: IViewModel
    {
        void Login();

        void LogOut();
    }
}
