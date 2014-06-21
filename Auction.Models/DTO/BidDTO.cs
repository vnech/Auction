using System;
using Caliburn.Micro;

namespace Auction.Models.DTO
{
    public class BidDTO: PropertyChangedBase
    {
        private int _bidId;
        private int _auctionId;
        private int _bidderId;
        private DateTime _createdAt;
        private decimal _amount;

        public int BidId
        {
            get { return _bidId; }
            set
            {
                if (value == _bidId) return;
                _bidId = value;
                NotifyOfPropertyChange();
            }
        }

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

        public int BidderId
        {
            get { return _bidderId; }
            set
            {
                if (value == _bidderId) return;
                _bidderId = value;
                NotifyOfPropertyChange();
            }
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set
            {
                if (value.Equals(_createdAt)) return;
                _createdAt = value;
                NotifyOfPropertyChange();
            }
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (value == _amount) return;
                _amount = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
