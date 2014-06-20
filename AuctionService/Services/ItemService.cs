using System;
using Auction.Data;
using AuctionService.Interfaces;
using AutoMapper;
using Item = Auction.Models.DTO.Item;

namespace AuctionService.Services
{
    public class ItemService : IItemService
    {
        public Item NewItem(Item item)
        {
            using (var context = new AuctionContext())
            {
                var itemEntity = Mapper.Map<Auction.Data.Item>(item);

                itemEntity = context.Items.Add(itemEntity);

                context.SaveChanges();

                return Mapper.Map<Item>(itemEntity);
            }
        }

        public void DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
