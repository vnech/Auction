using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Data;
using Auction.Data.Notifications;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using AutoMapper;

namespace AuctionService.Services
{
    public class ItemService : IItemService
    {
        private readonly AuctionContext _context;

        public ItemService()
            : this(new AuctionContext())
        {

        }

        public ItemService(AuctionContext context)
        {
            _context = context;
        }

        public ItemDTO NewItem(ItemDTO item)
        {
            using (var context = new AuctionContext())
            {
                var itemEntity = Mapper.Map<Auction.Data.Item>(item);

                itemEntity.IsActive = true;

                itemEntity = context.Items.Add(itemEntity);

                context.SaveChanges();

                return Mapper.Map<ItemDTO>(itemEntity);
            }
        }

        public void DeleteItem(ItemDTO item)
        {
            var entity = _context.Items.FirstOrDefault(i => i.ItemId == item.ItemId);

            if (entity == null) return;

            entity.IsActive = false;

            _context.SaveChanges();
        }

        public ItemDTO GetItem(ItemDTO itemDto)
        {
            throw new NotImplementedException();
        }

        public ItemDTO UpdateItem(ItemDTO itemDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemDTO> GetItemsAvailableForAuction()
        {
            var items = _context.Items.Where(item => item.IsActive && item.Auctions.Count == 0).ToList();
            return Mapper.Map<IEnumerable<Item>, IEnumerable<ItemDTO>>(items);
        }

        public IEnumerable<ItemDTO> GetItems()
        {
            using (var context = new AuctionContext())
            {
                var items = context.Items.Where(i => i.IsActive).ToList();

                return Mapper.Map<IEnumerable<Item>, IEnumerable<ItemDTO>>(items);
            }
        }
    }
}
