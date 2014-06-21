using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class NewItemDialogViewModel: Screen, INewItemDialogViewModel
    {
        private readonly IItemService _itemService;
        private ItemDTO _itemDto;
        
        public NewItemDialogViewModel(IItemService itemService)
        {
            _itemService = itemService;
            _itemDto = new ItemDTO();
        }

        public ItemDTO ItemDto
        {
            get { return _itemDto; }
            set
            {
                if (Equals(value, _itemDto)) return;
                _itemDto = value;
                NotifyOfPropertyChange();
            }
        }

        public void Create()
        {
            _itemService.NewItem(ItemDto);

            ItemDto = new ItemDTO();
        }
    }
}
