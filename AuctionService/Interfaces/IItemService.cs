﻿using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IItemService
    {
        ItemDTO NewItem(ItemDTO itemDto);

        void DeleteItem(ItemDTO itemDto);

        ItemDTO GetItem(ItemDTO itemDto);

        ItemDTO UpdateItem(ItemDTO itemDto);
    }
}