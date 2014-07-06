using System;
using System.Collections.Generic;
using Auction.Infrastructure.Interfaces;
using Caliburn.Micro;

namespace Auction.Models.DTO
{
    public class AuctionDTO: PropertyChangedBase, IResetable
    {
        private int _auctionId;
        private DateTime _startDate;
        private decimal _startPrice;
        private int _itemId;
        private ItemDTO _item;
        private IEnumerable<BidDTO> _bids;
        private AuctionStatus _status;

        public int AuctionId
        {
            get { return _auctionId; }
            set
            {
                if (value == _auctionId) return;
                _auctionId = value;
                NotifyOfPropertyChange();
            }
        }

        public int ItemId
        {
            get { return _itemId; }
            set
            {
                if (value == _itemId) return;
                _itemId = value;
                NotifyOfPropertyChange();
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (value.Equals(_startDate)) return;
                _startDate = value;
                NotifyOfPropertyChange();
            }
        }

        public decimal StartPrice
        {
            get { return _startPrice; }
            set
            {
                if (value == _startPrice) return;
                _startPrice = value;
                NotifyOfPropertyChange();
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

        public IEnumerable<BidDTO> Bids
        {
            get { return _bids; }
            set
            {
                if (Equals(value, _bids)) return;
                _bids = value;
                NotifyOfPropertyChange();
            }
        }

        public AuctionStatus Status
        {
            get { return _status; }
            set
            {
                if (value == _status) return;
                _status = value;
                NotifyOfPropertyChange();
            }
        }

        public DateTime CreatedAt { get; set; }

        public decimal CurrentPrice { get; set; }

        public int? BidderId { get; set; }

        public DateTime? LastBiddedAt { get; set; }

        public bool IsActive { get; set; }

        public void Reset()
        {
        }
    }
}
