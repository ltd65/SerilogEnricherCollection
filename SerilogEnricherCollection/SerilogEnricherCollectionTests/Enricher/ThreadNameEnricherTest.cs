using System.Threading;
using Serilog.Events;
using SerilogEnricherCollectionTests.TestHelper;
using Xunit;

namespace SerilogEnricherCollectionTests.Enricher
{
    public class ThreadNameEnricherTest : TestBase
    {
        private static string SetupThreadName(string threadName)
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
            Log.Information("Has a ThreadName property");

            Assert.NotNull(Event);
            Assert.Equal(expectedName, ((ScalarValue)Event.Properties["ThreadName"]).Value.ToString());
        }

        [Fact]
        public void EnricherDoesNotOverrideProperty()

        {
            CreateDefaultLoggerEnvironment();
            SetupThreadName("test string");
            Log.Information("Has a ThreadName property set in log: {ThreadName}", "abc");

            Assert.NotNull(Event);
            Assert.Equal("abc", ((ScalarValue)Event.Properties["ThreadName"]).Value.ToString());
        }
    }
}