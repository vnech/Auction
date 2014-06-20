using Auction.Models.DTO;

namespace Auction.Infrastructure.Interfaces
{
    public interface IAccountController
    {
        void Login(User user);

        void LogOut();

        int SignUp(User user);

        bool IsAuthentificated { get; }

        User CurrentUser { get; }
    }
}
