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

            ItemInitiallize();
        }

        private void ItemInitiallize()
        {
            _item = new ItemDTO();

            _item.PropertyChanged += Item_PropertyChanged;
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyOfPropertyChange(() => CanCreate);
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

        public bool CanCreate
        {
            get { return !string.IsNullOrEmpty(Item.ItemName) && Item.ItemName.Length <= 50; }
        }

        #region Screen overrides

        protected override void OnDeactivate(bool close)
        {
            ItemInitiallize();

            base.OnDeactivate(close);
        }

        #endregion Screen overrides
    }
}
