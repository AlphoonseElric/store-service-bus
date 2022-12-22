using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;


using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using MassTransit;
using Microsoft.Azure.WebJobs;
using Store.ServiceBus.Consumers;

namespace Store.ServiceBus
{
    public class SubmitStoreFunctions
    {

   const string SubmitOrderQueueName = "OrderCreated";
        readonly IMessageReceiver _receiver;

        public SubmitStoreFunctions(IMessageReceiver receiver)
        {
            _receiver = receiver;
        }


        [FunctionName("StoreServiceBusQueueTrigger")]
        public Task SubmitStoreAsync([ServiceBusTrigger(SubmitOrderQueueName)] ServiceBusReceivedMessage message, CancellationToken cancellationToken,ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {message}");
            return _receiver.HandleConsumer<SubmitStoreConsumer>(SubmitOrderQueueName, message, cancellationToken);

        }
    }
}





// using System;
// using Microsoft.Azure.WebJobs;
// using Microsoft.Azure.WebJobs.Host;
// using Microsoft.Extensions.Logging;


// namespace Store.ServiceBus
// {
//     public class StoreServiceBusQueueTrigger
//     {
//         [FunctionName("StoreServiceBusQueueTrigger")]
//         public void Run([ServiceBusTrigger("storeQueue", Connection = "h4bdevcus_SERVICEBUS")]string myQueueItem, ILogger log)
//         {
//             log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
//         }
//     }
// }
