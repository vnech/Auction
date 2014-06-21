using Auction.Infrastructure.Interfaces;
using Auction.Interfaces;
using Auction.ViewModels;
using AuctionService.Interfaces;
using Caliburn.Micro;
using Microsoft.Practices.Unity;

namespace Auction.IoCConfig
{
    public class ContainerBuilder
    {
        public IUnityContainer Build()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IWindowManager, WindowManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());

            container.RegisterType<IShellViewModel, ShellViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuctionAdminViewModel, AuctionUserViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILoginViewModel, LoginViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<INewAuctionDialogViewModel, NewAuctionDialogViewModel>();
            container.RegisterType<INewItemDialogViewModel, NewItemDialogViewModel>();
            container.RegisterType<IBidAuctionViewModel, BidAuctionViewModel>();

            container.RegisterType<IAccountController, Infrastructure.Controllers.AccountControler>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuctionService, AuctionService.Services.AuctionService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuctionBiddingService, AuctionService.Services.AuctionService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IItemService, AuctionService.Services.ItemService>(new ContainerControlledLifetimeManager());

            RegisterDependenciesFromModules(container);

            return container;
        }

        private void RegisterDependenciesFromModules(IUnityContainer container)
        {
            //container.RegisterType<MenuContainerInitializer>(new ContainerControlledLifetimeManager());
            //container.RegisterType<TableDataContainerInitializer>(new ContainerControlledLifetimeManager());

            //container.Resolve<MenuContainerInitializer>();
            //container.Resolve<TableDataContainerInitializer>();
        }
    }
}
