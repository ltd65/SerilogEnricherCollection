using System;
using System.Collections.Generic;
using System.Text;
using Serilog.Events;
using SerilogEnricherCollectionTests.TestHelper;
using Xunit;

namespace SerilogEnricherCollectionTests.Enricher
{
    public class MemoryInformationEnricherTest : TestBase
    {
        [Fact]
        public void MemoryAllocationIsApplied()

        {
            CreateDefaultLoggerEnvironment();
            Log.Information("Has an MemoryAllocation property");

            Assert.NotNull(Event);
            Assert.NotEmpty(((ScalarValue)Event.Properties["AllocatedMemory"]).Value.ToString());
        }

        [Fact]
        public void MemoryAllocationNotOverrideProperty()

        {
            CreateDefaultLoggerEnvironment();
            Log.Information("Has an MemoryAllocation property set in log: {AllocatedMemory}", "abc");

            Assert.NotNull(Event);
            Assert.Equal("abc", ((ScalarValue)Event.Properties["AllocatedMemory"]).Value.ToString());
        }

        [Fact]
        public void GcCollectionCountPropertyApplied()

        {
            CreateDefaultLoggerEnvironment();
            Log.Information("Has an gc information property");

            Assert.NotNull(Event);
            for (int i = 0; i < GC.MaxGeneration; i++)
            {
                Assert.NotEmpty(((ScalarValue)Event.Properties[$"GC{i}CollectionCount"]).Value.ToString());
            }
        }
    }
}
