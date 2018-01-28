using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using SerilogEnricherCollection.Enricher;

namespace SerilogEnricherCollectionTests.TestHelper
{
    public class TestBase
    {
        public LogEvent Event
        {
            get;
            set;
        }

        public Logger Log
        {
            get;
            set;
        }

        public ILogEventSink LogEventSink
        {
            get;
            set;
        }

        protected void CreateDefaultLoggerEnvironment()
        {

            LogEventSink = Substitute.For<ILogEventSink>();
            LogEventSink.Emit(Arg.Do<LogEvent>(e => Event = e));

            Log = new LoggerConfiguration()
                    .Enrich.WithUtcTimestamp()
                    .WriteTo.Sink(LogEventSink)
                    .CreateLogger();
        }
    }
}
