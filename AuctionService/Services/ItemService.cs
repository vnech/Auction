using System;
using Auction.Data;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using AutoMapper;

namespace AuctionService.Services
{
    public class ItemService : IItemService
    {
        public ItemDTO NewItem(ItemDTO itemDto)
        {
            using (var context = new AuctionContext())
            {
                var itemEntity = Mapper.Map<Auction.Data.Item>(itemDto);

                itemEntity = context.Items.Add(itemEntity);

                context.SaveChanges();

                return Mapper.Map<ItemDTO>(itemEntity);
            }
        }

        public void DeleteItem(ItemDTO itemDto)
        {
            throw new NotImplementedException();
        }

        public ItemDTO GetItem(ItemDTO itemDto)
        {
            throw new NotImplementedException();
        }

        public ItemDTO UpdateItem(ItemDTO itemDto)
        {
            throw new NotImplementedException();
        }
    }
}
