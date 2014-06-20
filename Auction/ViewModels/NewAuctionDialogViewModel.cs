﻿using Auction.Interfaces;
using AuctionService.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class NewAuctionDialogViewModel : Screen, INewAuctionDialogViewModel
    {
        private readonly IAuctionService _auctionService;

        private Models.DTO.Auction _auction;

        public NewAuctionDialogViewModel(IAuctionService auctionService)
        {
            _auctionService = auctionService;
            Auction = new Models.DTO.Auction();
        }

        public Models.DTO.Auction Auction
        {
            get { return _auction; }
            set
            {
                if (Equals(value, _auction)) return;
                _auction = value;
                NotifyOfPropertyChange();
            }
        }

        public void Create()
        {
            _auctionService.NewAuction(Auction);

            Auction = null;
        }

        public bool CanCreate()
        {
            return true;
            //return !string.IsNullOrEmpty(Auction.ItemName);
        }
    }
}
