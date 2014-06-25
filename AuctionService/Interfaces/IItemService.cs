using System.Collections.Generic;
using Auction.Models.DTO;

namespace AuctionService.Interfaces
{
    public interface IItemService
    {
        ItemDTO NewItem(ItemDTO item);

        void DeleteItem(ItemDTO itemDto);

        ItemDTO GetItem(ItemDTO itemDto);

        ItemDTO UpdateItem(ItemDTO itemDto);

        //todo: refactor
        IEnumerable<ItemDTO> GetItemsAvailableForAuction();
    }
}
