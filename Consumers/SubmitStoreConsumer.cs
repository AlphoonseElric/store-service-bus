using System;
using System.Threading.Tasks;
using MassTransit;
using Sample.AzureFunction;

namespace Store.ServiceBus.Consumers
{
    public class SubmitStoreConsumer :
        IConsumer<SubmitStore>
    {
        public Task Consume(ConsumeContext<SubmitStore> context)
        {
            LogContext.Debug?.Log("Processing Order: {OrderNumber}", context.Message.OrderNumber);

            context.Publish<object>(new
            {
                context.Message.OrderNumber,
                Timestamp = DateTime.UtcNow
            });

            return context.RespondAsync<object>(context.Message);
        }
    }


}