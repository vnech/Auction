using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Auction.Interfaces;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using AutoMapper;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class AuctionUserViewModel : Screen, IAuctionAdminViewModel
    {
        private readonly IAccountController _accountController;
        private readonly IAuctionService _auctionService;
        private readonly IWindowManager _windowManager;
        private readonly INewAuctionDialogViewModel _newAuctionDialogViewModel;
        private readonly IItemDialogViewModel _itemDialogViewModel;
        private readonly IBidAuctionViewModel _bidAuctionViewModel;
        private AuctionDTO _selectedAuction;
        private int _time;

        public AuctionUserViewModel(IAccountController accountController,
                                    IAuctionService auctionService,
                                    IWindowManager windowManager,
                                    INewAuctionDialogViewModel newAuctionDialogViewModel,
                                    IItemDialogViewModel itemDialogViewModel,
                                    IBidAuctionViewModel bidAuctionViewModel)
        {
            _accountController = accountController;
            _auctionService = auctionService;
            _windowManager = windowManager;
            _newAuctionDialogViewModel = newAuctionDialogViewModel;
            _itemDialogViewModel = itemDialogViewModel;
            _bidAuctionViewModel = bidAuctionViewModel;

            Auctions = new BindableCollection<AuctionDTO>(_auctionService.AuctionsAllGet());

            _auctionService.OnAuctionsChange += AuctionService_OnAuctionsChange;

            _accountController.PropertyChanged += AccountController_PropertyChanged;

            Timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };

            Timer.Tick += Timer_Tick;
        }

        private void AccountController_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyOfPropertyChange(() => CanNewItem);
            NotifyOfPropertyChange(() => CanNewAuction);
            NotifyOfPropertyChange(() => CanEndAuction);
            NotifyOfPropertyChange(() => CanStartAuction);
            NotifyOfPropertyChange(() => CanBid);
        }

        private void AuctionService_OnAuctionsChange(object sender, System.EventArgs e)
        {
            //todo: refactor

            //todo: update ui on editing
            App.Current.Dispatcher.Invoke(() =>
            {
                Auctions.Clear();

                var auctions = _auctionService.AuctionsAllGet();

                auctions.Each(a => Auctions.Add(a));

                Auctions.Refresh();
            });
        }

        public DispatcherTimer Timer { get; set; }

        public int Time
        {
            get { return _time; }
            set
            {
                if (value.Equals(_time)) return;
                _time = value;
                NotifyOfPropertyChange();
            }
        }

        public BindableCollection<AuctionDTO> Auctions { get; set; }

        public AuctionDTO SelectedAuction
        {
            get { return _selectedAuction; }
            set
            {
                if (Equals(value, _selectedAuction)) return;
                _selectedAuction = value;
                NotifyOfPropertyChange();

                SelectedAuctionChanged();
            }
        }

        private void SelectedAuctionChanged()
        {
            //todo: refactor
            if (SelectedAuction != null && SelectedAuction.Status == AuctionStatus.Started && SelectedAuction.LastBiddedAt.HasValue)
            {
                var endTime = SelectedAuction.LastBiddedAt.Value + new TimeSpan(0, 2, 0);

                var timeLeft = (endTime - DateTime.Now).TotalSeconds;

                Time = (int)timeLeft;

                Timer.Start();
            }
            else if (SelectedAuction != null && SelectedAuction.Status == AuctionStatus.NotStarted)
            {
                Time = 0;

                Timer.Stop();
            }
            else
            {
                //db layer managed by sql agent
                if (SelectedAuction != null) SelectedAuction.Status = AuctionStatus.Ended;
                
                Time = 0;

                Timer.Stop();
            }

            NotifyOfPropertyChange(() => CanStartAuction);
            NotifyOfPropertyChange(() => CanEndAuction);
            NotifyOfPropertyChange(() => CanBid);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Time <= 0)
            {
                Timer.Stop();

                Time = 0;
            }

            Time--;
        }

        #region IAuctionUserViewModelBase

        public void Login()
        {
            _windowManager.ShowDialog(IoC.Get<ILoginViewModel>());

            NotifyOfPropertyChange(() => CanLogin);
        }

        public bool CanLogin
        {
            get { return !_accountController.IsAuthentificated; }
        }

        public void LogOut()
        {
            _accountController.LogOut();
        }

        public bool CanLogOut
        {
            get { return _accountController.IsAuthentificated; }
        }

        #endregion IAuctionUserViewModelBase

        #region IAuctionUserViewMode

        public void Bid()
        {
            _bidAuctionViewModel.SetAuction(SelectedAuction);

            _windowManager.ShowDialog(_bidAuctionViewModel);
        }

        public bool CanBid
        {
            get
            {
                return _accountController.IsAuthentificated &&
                        SelectedAuction != null &&
                        SelectedAuction.Status == AuctionStatus.Started;
            }
        }

        #endregion IAuctionUserViewMode

        #region IAuctionAdminViewModel

        public void StartAuction()
        {
            _auctionService.StartAuction(SelectedAuction);
        }

        public bool CanStartAuction
        {
            get
            {
                return _accountController.IsAdmin && _auctionService.CanAuctionBeStarted(SelectedAuction);
            }
        }

        public void NewAuction()
        {
            bool? showDialog = _windowManager.ShowDialog(_newAuctionDialogViewModel);
        }

        public bool CanNewAuction
        {
            get
            {
                return _accountController.IsAdmin;
            }
        }

        public void NewItem()
        {
            bool? showDialog = _windowManager.ShowDialog(_itemDialogViewModel);
        }

        public bool CanNewItem
        {
            get
            {
                return _accountController.IsAdmin;
            }
        }

        public void EndAuction()
        {
            _auctionService.EndAuction(SelectedAuction);
        }

        public bool CanEndAuction
        {
            get
            {
                return _accountController.IsAdmin && _auctionService.CanAuctionBeEnded(SelectedAuction);
            }
        }

        #endregion IAuctionAdminViewModel
    }
}
