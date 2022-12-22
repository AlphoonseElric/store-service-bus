using System;

namespace Sample.AzureFunction
{
    public interface SubmitStore
    {
        Guid OrderId { get; }
        string OrderNumber { get; }
    }
}