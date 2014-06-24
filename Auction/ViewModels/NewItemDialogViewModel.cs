using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class NewItemDialogViewModel: Screen, INewItemDialogViewModel
    {
        private readonly IAccountController _accountController;
        private readonly IItemService _itemService;
        private ItemDTO _item;
        
        public NewItemDialogViewModel(IItemService itemService, IAccountController accountController)
        {
            _accountController = accountController;
            _itemService = itemService;
            _item = new ItemDTO();
        }

        public ItemDTO Item
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
            _item.SellerId = _accountController.CurrentUser.UserId;

            _itemService.NewItem(Item);

            Item = new ItemDTO();

            TryClose(true);
        }
    }
}
