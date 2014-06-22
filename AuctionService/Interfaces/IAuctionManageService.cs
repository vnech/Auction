namespace AuctionService.Interfaces
{
    public interface IAuctionManageService
    {
        int NewAuction(Auction.Models.DTO.AuctionDTO auction);

        void StartAuction();

        void EndAuction();
    }
}
