using System;
using Serilog.Core;
using Serilog.Events;

namespace SerilogEnricherCollection.Enricher
{
    class MemoryInformationEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("AllocatedMemory", GC.GetTotalMemory(false)));
            for (int i = 0; i < GC.MaxGeneration; i++)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty($"GC{i}CollectionCount", GC.CollectionCount(i)));
            }
        }
    }
}