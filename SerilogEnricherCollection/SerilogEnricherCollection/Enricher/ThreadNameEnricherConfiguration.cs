using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Configuration;

namespace SerilogEnricherCollection.Enricher
{
    public static class ThreadNameEnricherConfiguration
    {
        public static LoggerConfiguration WithThreadName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ThreadNameEnricher>();
        }
    }
}
