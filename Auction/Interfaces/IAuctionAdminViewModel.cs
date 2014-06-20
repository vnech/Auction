namespace Auction.Interfaces
{
    public interface IAuctionAdminViewModel: IAuctionUserViewMode
    {
        void StartAuction();

        void NewAuction();

        void EndAuction();
    }
}
