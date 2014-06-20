namespace Auction.Interfaces
{
    public interface IAuctionAdminViewModel: IAuctionUserViewMode
    {
        void StartAuction();

        void EndAuction();

        void NewAuction();

        void NewItem();
    }
}
