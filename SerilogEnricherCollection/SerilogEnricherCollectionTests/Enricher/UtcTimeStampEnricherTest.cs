using Serilog.Events;
using SerilogEnricherCollectionTests.TestHelper;
using Xunit;

namespace SerilogEnricherCollectionTests.Enricher
{
    public class UtcTimeStampEnricherTest : TestBase
    {
        [Fact]
        public void UtcTimeStampEnricherIsApplied()

        {
            CreateDefaultLoggerEnvironment();
            Log.Information("Has an UtcTimestamp property");

            Assert.NotNull(Event);
            Assert.NotEmpty(((ScalarValue)Event.Properties["UtcTimestamp"]).Value.ToString());
        }

        [Fact]
        public void UtcTimeStampDoesNotOverrideProperty()

        {
            CreateDefaultLoggerEnvironment();
            Log.Information("Has an UtcTimestamp property set in log: {UtcTimestamp}", "abc");

            Assert.NotNull(Event);
            Assert.Equal("abc", ((ScalarValue)Event.Properties["UtcTimestamp"]).Value.ToString());
        }
    }
}