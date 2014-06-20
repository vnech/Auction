namespace AuctionService.Interfaces
{
    public interface IAuctionManageService
    {
        int NewAuction(Auction.Models.DTO.Auction auction);

        void StartAuction();

        void EndAuction();
    }
}
