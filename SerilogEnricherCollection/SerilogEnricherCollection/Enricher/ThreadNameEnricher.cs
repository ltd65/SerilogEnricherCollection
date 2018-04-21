using System.Threading;
using Serilog.Core;
using Serilog.Events;

namespace SerilogEnricherCollection.Enricher
{
    public class ThreadNameEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadName", Thread.CurrentThread.Name));
        }
    }
}