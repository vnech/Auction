using System.Collections.Generic;
using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using Screen = Caliburn.Micro.Screen;

namespace Auction.ViewModels
{
    public class NewAuctionDialogViewModel : Screen, INewAuctionDialogViewModel
    {
        private readonly IAuctionService _auctionService;
        private readonly IItemService _itemService;
        private readonly IAccountController _accountController;

        private AuctionDTO _auction;
        private IEnumerable<ItemDTO> _itemsAvailable;

        public NewAuctionDialogViewModel(IAuctionService auctionService, IItemService itemService, IAccountController accountController)
        {
            _auctionService = auctionService;
            _itemService = itemService;
            _accountController = accountController;

            AuctionInitiallize();
        }

        void Auction_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyOfPropertyChange(() => CanCreate);
        }

        public AuctionDTO Auction
        {
            get { return _auction; }
            set
            {
                if (Equals(value, _auction)) return;
                _auction = value;
                NotifyOfPropertyChange();
            }
        }

        /// <summary>
        /// Represents items that are not under any auction
        /// </summary>
        public IEnumerable<ItemDTO> ItemsAvailable
        {
            get { return _itemsAvailable; }
            set
            {
                if (Equals(value, _itemsAvailable)) return;
                _itemsAvailable = value;
                NotifyOfPropertyChange();
            }
        }

        public void Create()
        {
            Auction.BidderId = _accountController.CurrentUser.UserId;

            _auctionService.NewAuction(Auction);

            Auction = new AuctionDTO();

            TryClose(true);
        }

        public bool CanCreate
        {
            get { return Auction.ItemId > 0 && Auction.StartPrice >= 0; }
        }

        #region Helpers

        private void AuctionInitiallize()
        {
            Auction = new AuctionDTO();

            Auction.PropertyChanged += Auction_PropertyChanged;
        }

        #endregion Helpers

        #region Screen overrides

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            ItemsAvailable = _itemService.GetItemsAvailableForAuction();
        }

        protected override void OnDeactivate(bool close)
        {
            AuctionInitiallize();

            base.OnDeactivate(close);
        }

        #endregion Screen overrides
    }
}
