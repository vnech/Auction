using AutoMapper;

namespace Auction.IoCConfig
{
    internal static class AutoMapperConfiguration
    {
        public static void Initiallize()
        {
            Mapper.CreateMap<Auction.Models.DTO.Auction, Auction.Data.Auction>();
            Mapper.CreateMap<Auction.Models.DTO.User, Auction.Data.User>();
        }
    }
}
