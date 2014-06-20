using System.Collections.Generic;
using Auction.Data;
using AuctionService.Interfaces;

namespace AuctionService.Services
{
    public class AuctionService : IAuctionService
    {
        public AuctionService()
        {

        }

        public int NewAuction(Auction.Models.DTO.Auction auction)
        {
            using (var context = new AuctionContext())
            {
                var auctionEntity = AutoMapper.Mapper.Map<Auction.Data.Auction>(auction);

                auctionEntity = context.Auctions.Add(auctionEntity);

                context.SaveChanges();

                return auctionEntity.AuctionId;
            }
        }

        public void StartAuction()
        {
        }

        public void EndAuction()
        {
        }

        public IEnumerable<Auction.Models.DTO.Auction> AuctionsGet()
        {
            return new List<Auction.Models.DTO.Auction>();
        }

        public void Bid()
        {
        }
    }
}
