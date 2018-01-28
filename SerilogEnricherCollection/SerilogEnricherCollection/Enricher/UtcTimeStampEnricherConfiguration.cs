using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace SerilogEnricherCollection.Enricher
{
    public static class UtcTimestampConfigurationExtension
    {
        public static LoggerConfiguration WithUtcTimestamp(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<UtcTimestampEnricher>();
        }
    }
}
