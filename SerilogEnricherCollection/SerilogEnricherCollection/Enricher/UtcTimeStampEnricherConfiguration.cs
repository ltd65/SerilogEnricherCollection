using System;
using Serilog;
using Serilog.Configuration;

namespace SerilogEnricherCollection.Enricher
{
    public static class UtcTimestampConfigurationExtension
    {
        public static LoggerConfiguration WithUtcTimestamp(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<UtcTimestampEnricher>();
        }
    }
}