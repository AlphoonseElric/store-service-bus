// using System;
// using MassTransit;
// using Microsoft.Azure.Functions.Extensions.DependencyInjection;
// using Microsoft.Extensions.DependencyInjection;
// using Store.ServiceBus;
// using Store.ServiceBus.Consumers;
//
// [assembly: FunctionsStartup(typeof(Startup))]
//
//
// namespace Store.ServiceBus
//
// {
//     public class Startup :
//         FunctionsStartup
//     {
//         public override void Configure(IFunctionsHostBuilder builder)
//         {
//             builder.Services
//                 .AddScoped<SubmitStoreFunctions>()
//                 .AddMassTransitForAzureFunctions(cfg =>
//                     {
//                         // cfg.AddConsumersFromNamespaceContaining<ConsumerNamespace>();
//                         cfg.AddRequestClient< SubmitStoreFunctions>(new Uri("queue:submit-order"));
//                     },
//                     "AzureWebJobsServiceBus")
//                 .AddMassTransitEventHub();
//         }
//     }
// }

using System;
using MassTransit;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Store.ServiceBus;
using Store.ServiceBus.Consumers;
using FunctionsStartup = Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup;

[assembly: FunctionsStartup(typeof(Startup))]


namespace Store.ServiceBus
{
    public class Startup :
        FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddScoped<SubmitStoreFunctions>()
                .AddMassTransitForAzureFunctions(cfg =>
                    {
                        cfg.AddConsumersFromNamespaceContaining<ConsumerNamespace>();
                        cfg.AddRequestClient<object>(new Uri("queue:submit-order"));
                    },
                    "AzureWebJobsServiceBus")
                .AddMassTransitEventHub();
        }
    }
}
