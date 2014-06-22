using System.Collections.ObjectModel;
using System.Windows.Threading;
using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using AutoMapper;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class AuctionUserViewModel: Screen, IAuctionAdminViewModel
    {
        private readonly IAccountController _accountController;
        private readonly IAuctionService _auctionService;
        private readonly IWindowManager _windowManager;
        private readonly INewAuctionDialogViewModel _newAuctionDialogViewModel;
        private readonly INewItemDialogViewModel _newItemDialogViewModel;
        private readonly ILoginViewModel _loginViewModel;
        private readonly IBidAuctionViewModel _bidAuctionViewModel;
        private AuctionDTO _selectedAuction;

        public AuctionUserViewModel(IAccountController accountController, 
                                    IAuctionService auctionService, 
                                    IWindowManager windowManager, 
                                    INewAuctionDialogViewModel newAuctionDialogViewModel, 
                                    ILoginViewModel loginViewModel,
                                    INewItemDialogViewModel newItemDialogViewModel,
                                    IBidAuctionViewModel bidAuctionViewModel)
        {
            _accountController = accountController;
            _auctionService = auctionService;
            _windowManager = windowManager;
            _newAuctionDialogViewModel = newAuctionDialogViewModel;
            _loginViewModel = loginViewModel;
            _newItemDialogViewModel = newItemDialogViewModel;
            _bidAuctionViewModel = bidAuctionViewModel;

            Auctions = new ObservableCollection<AuctionDTO>(_auctionService.AuctionsGet());

            _auctionService.OnAuctionsChange += AuctionService_OnAuctionsChange;

            _accountController.PropertyChanged += AccountController_PropertyChanged;
        }

        private void AccountController_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyOfPropertyChange(() => CanNewItem);
        }

        private void AuctionService_OnAuctionsChange(object sender, System.EventArgs e)
        {
            //todo: refactor
            App.Current.Dispatcher.Invoke(() =>
            {
                Auctions.Clear();

                var auctions = _auctionService.AuctionsGet();

                auctions.Each(a => Auctions.Add(a));
            });
        }

        public ObservableCollection<AuctionDTO> Auctions { get; set; }

        public AuctionDTO SelectedAuction
        {
            get { return _selectedAuction; }
            set
            {
                if (Equals(value, _selectedAuction)) return;
                _selectedAuction = value;
                NotifyOfPropertyChange();
            }
        }

        #region IAuctionUserViewModelBase

        public void Login()
        {
            bool? showDialog = _windowManager.ShowDialog(_loginViewModel);
        }

        public bool CanLogin()
        {
            return true;
        }

        public void LogOut()
        {
        }

        public bool CanLogOut()
        {
            return true;
        }

        #endregion IAuctionUserViewModelBase

        #region IAuctionUserViewMode

        public void Bid()
        {
            bool? showDialog = _windowManager.ShowDialog(_bidAuctionViewModel);
        }

        public bool CanBid()
        {
            return true;
        }

        #endregion IAuctionUserViewMode

        #region IAuctionAdminViewModel

        public void StartAuction()
        {
        }

        public bool CanStartAuction()
        {
            return _accountController.IsAuthentificated;
        }

        public void NewAuction()
        {
            bool? showDialog = _windowManager.ShowDialog(_newAuctionDialogViewModel);
        }

        public bool CanNewAuction()
        {
            return true;
        }

        public void NewItem()
        {
            bool? showDialog = _windowManager.ShowDialog(_newItemDialogViewModel);
        }

        public bool CanNewItem
        {
            get { return _accountController.IsAuthentificated; }
        }

        public void EndAuction()
        {
        }

        public bool CanEndAuction()
        {
            return true;
        }

        #endregion IAuctionAdminViewModel
    }
}
