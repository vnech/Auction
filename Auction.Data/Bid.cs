//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Auction.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bid
    {
        public int BidId { get; set; }
        public int AuctionId { get; set; }
        public int BidderId { get; set; }
        public System.DateTime CratedAt { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Auction Auction { get; set; }
    }
}