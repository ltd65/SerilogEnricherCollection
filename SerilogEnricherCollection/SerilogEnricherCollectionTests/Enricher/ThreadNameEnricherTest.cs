using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Serilog.Events;
using SerilogEnricherCollectionTests.TestHelper;
using Xunit;

namespace SerilogEnricherCollectionTests.Enricher
{
    public class ThreadNameEnricherTest : TestBase
    {
        private string SetupThreadName(string threadName)
        {
            if (string.IsNullOrWhiteSpace(Thread.CurrentThread.Name))
            {
                Thread.CurrentThread.Name = threadName;
            }
            return Thread.CurrentThread.Name;
        }

        [Fact]
        public void ThreadNameEnricherIsApplied()

        {
            CreateDefaultLoggerEnvironment();
            string expectedName = SetupThreadName("test string");
            Log.Information("Has an ThreadName property");

            Assert.NotNull(Event);
            Assert.Equal(expectedName,((ScalarValue)Event.Properties["ThreadName"]).Value.ToString());
        }

        [Fact]
        public void UtcTimeStampDoesNotOverrideProperty()

        {
            CreateDefaultLoggerEnvironment();
            string expectedName = SetupThreadName("test string");
            Log.Information("Has an UtcTimestamp property set in log: {ThreadName}", "abc");

            Assert.NotNull(Event);
            Assert.Equal("abc", ((ScalarValue)Event.Properties["ThreadName"]).Value.ToString());
        }
    }
}
