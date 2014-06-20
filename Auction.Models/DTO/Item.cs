namespace Auction.Models.DTO
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemStartPrice { get; set; }
        public string ItemDescription { get; set; }
        public int SellerId { get; set; }
    }
}
