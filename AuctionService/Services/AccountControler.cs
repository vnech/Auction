using Auction.Data;
using Auction.Infrastructure.Interfaces;
using Auction.Models.DTO;
using AutoMapper;

namespace Auction.Infrastructure.Controllers
{
    public class AccountControler: IAccountController
    {
        public void Login(UserDTO userDto)
        {
        }

        public void LogOut()
        {
        }

        public int SignUp(UserDTO userDto)
        {
            using (var context = new AuctionContext())
            {
                var userEntity = Mapper.Map<Data.User>(userDto);

                userEntity = context.Users.Add(userEntity);

                context.SaveChanges();

                return userEntity.UserId;
            }
        }

        public bool IsAuthentificated { get; private set; }

        public UserDTO CurrentUserDto { get; private set; }
    }
}
