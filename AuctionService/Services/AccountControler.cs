using Auction.Data;
using Auction.Infrastructure.Interfaces;
using AutoMapper;
using User = Auction.Models.DTO.User;

namespace Auction.Infrastructure.Controllers
{
    public class AccountControler: IAccountController
    {
        public void Login(User user)
        {
        }

        public void LogOut()
        {
        }

        public int SignUp(User user)
        {
            using (var context = new AuctionContext())
            {
                var userEntity = Mapper.Map<Data.User>(user);

                userEntity = context.Users.Add(userEntity);

                context.SaveChanges();

                return userEntity.UserId;
            }
        }

        public bool IsAuthentificated { get; private set; }

        public User CurrentUser { get; private set; }
    }
}
