using System;
using System.Collections.Generic;
using System.Windows;
using Auction.Interfaces;
using Auction.IoCConfig;
using Caliburn.Micro;
using Microsoft.Practices.Unity;

namespace Auction
{
    public class AuctionBootstrapper : BootstrapperBase
    {
        private IUnityContainer container;

        public AuctionBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            base.Configure();
            ContainerBuilder containerBuilder = new ContainerBuilder();
            container = containerBuilder.Build();

            AutoMapperConfiguration.Initiallize();
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.ResolveAll(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.Resolve(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShellViewModel>();
        }
    }

   
}
