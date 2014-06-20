using Auction.Infrastructure.Interfaces;
using Auction.Models.DTO;

namespace Auction.Interfaces
{
    public interface ILoginViewModel : IViewModel
    {
        User User { get; set; }

        void Login();
    }
}
