﻿using Caliburn.Micro;

namespace Auction.Models.DTO
{
    public class Item : PropertyChangedBase
    {
        private string _itemName;
        private int _itemId;
        private decimal _itemStartPrice;
        private string _itemDescription;
        private int _sellerId;

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

        public decimal ItemStartPrice
        {
            get { return _itemStartPrice; }
            set
            {
                if (value == _itemStartPrice) return;
                _itemStartPrice = value;
                NotifyOfPropertyChange();
            }
        }

        public string ItemDescription
        {
            get { return _itemDescription; }
            set
            {
                if (value == _itemDescription) return;
                _itemDescription = value;
                NotifyOfPropertyChange();
            }
        }

        public int SellerId
        {
            get { return _sellerId; }
            set
            {
                if (value == _sellerId) return;
                _sellerId = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
