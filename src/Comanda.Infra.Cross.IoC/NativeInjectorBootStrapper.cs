using AutoMapper;
using Comanda.Infra.Cross.Bus;
using Comanda.Infra.Data.Repository.EventSourcing;
using Comanda.Domain.Core.Bus;
using Comanda.Domain.Core.Events;
using Comanda.Domain.Core.Notifications;
using Comanda.Domain.Interfaces;
using Comanda.Domain.Interfaces.Repository;
using Comanda.Domain.Interfaces.Repository.Catalog;
using Comanda.Infra.Cross.Identity.Models;
using Comanda.Infra.Data.Context;
using Comanda.Infra.Data.EventSourcing;
using Comanda.Infra.Data.Repository;
using Comanda.Infra.Data.Repository.Catalog;
using Comanda.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Comanda.Infra.Cross.Identity.Authorization;

namespace Comanda.Infra.Cross.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            //services.AddSingleton(Mapper.Configuration);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            //services.AddScoped<ICustomerAppService, CustomerAppService>();
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IReviewService, ReviewService>();
            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<IManufacturerService, ManufacturerService>();
            //services.AddScoped<IImageManagerService, ImageManagerService>();
            //services.AddScoped<IBillingAddressService, BillingAddressService>();
            //services.AddScoped<IUserAppService, UserAppService>();



            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            //services.AddScoped<INotificationHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            //services.AddScoped<INotificationHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            //services.AddScoped<INotificationHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data        
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageManagerRepository, ImageManagerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ComandaDbContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddDbContext<EventStoreDBContext>();

            // Infra - Identity Services

            // Infra - Identity
            services.AddScoped<ICurrentUser, AspNetUser>();

        }
    }
}