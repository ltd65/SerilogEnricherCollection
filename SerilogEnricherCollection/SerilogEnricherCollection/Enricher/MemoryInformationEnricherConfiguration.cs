using System;
using Serilog;
using Serilog.Configuration;

namespace SerilogEnricherCollection.Enricher
{
    public static class MemoryInformationEnricherConfiguration
    {
        public static LoggerConfiguration WithMemoryInformation(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<MemoryInformationEnricher>();
        }
    }
}