﻿using AutoMapper;

namespace Auction.IoCConfig
{
    internal static class AutoMapperConfiguration
    {
        public static void Initiallize()
        {
            Mapper.CreateMap<Auction.Models.DTO.AuctionDTO, Auction.Data.Auction>();
            Mapper.CreateMap<Auction.Data.Auction, Auction.Models.DTO.AuctionDTO>();

            Mapper.CreateMap<Auction.Models.DTO.UserDTO, Auction.Data.User>();
            Mapper.CreateMap<Auction.Data.User, Auction.Models.DTO.UserDTO>();

            Mapper.CreateMap<Auction.Models.DTO.ItemDTO, Auction.Data.Item>();
            Mapper.CreateMap<Auction.Data.Item, Auction.Models.DTO.ItemDTO>();

            Mapper.CreateMap<Auction.Models.DTO.BidDTO, Auction.Data.Bid>();
            Mapper.CreateMap<Auction.Data.Bid, Auction.Models.DTO.BidDTO>();
        }
    }
}