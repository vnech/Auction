namespace AuctionService.Interfaces
{
    public interface IAuctionManageService
    {
        int NewAuction(Auction.Models.DTO.AuctionDTO auctionDto);

        void StartAuction();

        void EndAuction();
    }
}
