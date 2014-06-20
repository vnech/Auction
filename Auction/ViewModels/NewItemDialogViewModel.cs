using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class NewItemDialogViewModel: Screen, INewItemDialogViewModel
    {
        private readonly IItemService _itemService;
        private Item _item;
        
        public NewItemDialogViewModel(IItemService itemService)
        {
            _itemService = itemService;
            _item = new Item();
        }

        public Item Item
        {
            get { return _item; }
            set
            {
                if (Equals(value, _item)) return;
                _item = value;
                NotifyOfPropertyChange();
            }
        }

        public void Create()
        {
            _itemService.NewItem(Item);

            Item = new Item();
        }
    }
}
