using System;
using Caliburn.Micro;

namespace Auction.Models.DTO
{
    public class Auction: PropertyChangedBase
    {
        private int _auctionId;
        private string _itemName;
        private DateTime _startDate;
        private decimal _startPrice;

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

        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (value == _itemName) return;
                _itemName = value;
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
    }
}
