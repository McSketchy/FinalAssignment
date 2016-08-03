using InventoryDataInteraction;

namespace FinalAssignment
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using ViewModels;
    using InventoryData;
    using InventoryDataInteraction;
    //using Common.Interfaces;

    public class AppBootstrapper : BootstrapperBase
	{
		SimpleContainer container;

		public AppBootstrapper()
		{
			Initialize();
		}

		protected override void Configure()
		{
			container = new SimpleContainer();

			container.Activated += (instance) =>
			{
				container.BuildUp(instance);
			};

			container.Singleton<IWindowManager, WindowManager>();
			container.Singleton<IEventAggregator, EventAggregator>();
			container.PerRequest<MainViewModel>();
			container.PerRequest<InventoryViewModel>();
			container.PerRequest<NewOrderViewModel>();
			container.PerRequest<OrdersViewModel>();

			//container.Singleton<IInventoryData, DatabaseInteraction>();
		}

		protected override object GetInstance(Type service, string key)
		{
			var instance = container.GetInstance(service, key);
			if (instance != null)
				return instance;

			throw new InvalidOperationException("Could not locate any instances.");
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			container.BuildUp(instance);
		}

		protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
		{
			DisplayRootViewFor<MainViewModel>();
		}
	}
}