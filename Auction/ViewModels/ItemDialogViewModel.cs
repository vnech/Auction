using System.Linq;
using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using AutoMapper;
using Caliburn.Micro;
using Microsoft.Practices.ObjectBuilder2;

namespace Auction.ViewModels
{
    public class    ItemDialogViewModel: Screen, IItemDialogViewModel
    {
        private readonly IAccountController _accountController;
        private readonly IItemService _itemService;
        private readonly IAuctionService _auctionService;
        private ItemDTO _item;
        private ItemDTO _selectedItem;

        public ItemDialogViewModel(IItemService itemService, IAccountController accountController, IAuctionService auctionService)
        {
            _accountController = accountController;
            _auctionService = auctionService;
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

        public BindableCollection<ItemDTO> Items { get; set; }

        public ItemDTO SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                NotifyOfPropertyChange();

                NotifyOfPropertyChange(() => CanDelete);
            }
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

        public void RefreshItemsGrid()
        {
            Items.Clear();

            var items = _itemService.GetItems();

            items.Each(a => Items.Add(a));

            Items.Refresh();
        }

        public void Delete()
        {
            if (SelectedItem.Auctions.Any())
            {
                SelectedItem.Auctions.ForEach(a => _auctionService.Delete(a));
            }

            _itemService.DeleteItem(SelectedItem);

            RefreshItemsGrid();
        }

        public bool CanDelete
        {
            get { return SelectedItem != null; }
        }

        public void Create()
        {
            _item.SellerId = _accountController.CurrentUser.UserId;

            _itemService.NewItem(Item);

            RefreshItemsGrid();

            Item = new ItemDTO();
        }

        public bool CanCreate
        {
            get { return !string.IsNullOrEmpty(Item.ItemName) && Item.ItemName.Length <= 50; }
        }

        #region Screen overrides

        protected override void OnActivate()
        {
            Items = new BindableCollection<ItemDTO>(_itemService.GetItems());

            ItemInitiallize();

            base.OnActivate();
        }

        #endregion Screen overrides
    }
}
