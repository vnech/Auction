using Auction.Interfaces;
using Caliburn.Micro;

namespace Auction.ViewModels
{
    public class ShellViewModel : Conductor<object>, IShellViewModel
    {
        public ShellViewModel()
        {
            Initiallize();
        }

        public void Initiallize()
        {
            //ActivateItem(IoC.Get<ILoginViewModel>());
            ActivateItem(IoC.Get<IAuctionAdminViewModel>());
        }
    }
}
