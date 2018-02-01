# SerilogEnricherCollection

A collection of some simple enrichers for serilog

## Status

Released as version 1.

## Usage

To use the enricher collection you can install it via nuget:

Until the project is not out of it's experimental state there will be no package available on nuget. First release will be done when I am happy with the packaging.
```powershell
Install-Package SerilogEnricherCollection
```

To activate you can either apply the enricher by adding them to your `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
            .Enrich.WithUtcTimestamp()
            .Enrich.WithThreadName()
            .Enrich.WithMemoryInformation()
            // your configuration here
            .CreateLogger();
```

If you have enabled the file based configuration in your `LoggerConfiguration` you can configure within the app.config:

```XML
        <add key="serilog:using:SerilogEnricherCollection" value="SerilogEnricherCollection"/>
        <add key="serilog:enrich:WithUtcTimestamp" value=""/>
        <add key="serilog:enrich:WithThreadName" value=""/>
        <add key="serilog:enrich:WithMemoryInformation" value=""/>
```

or in appconfig.json:

```JSON
{
  "Serilog": {
    "Enrich": ["WithUtcTimestamp", "WithThreadName", "WithMemoryInformation"]
  }
}

```

## Included Enrichers

* WithUtcTimestamp: Adds the timestamp of the logging event in Utc. Property name added: "UtcTimestamp"
* WithThreadName: Adds the name found in Thread.Name. Property name added: "ThreadName"
* WithMemoryInformation: Add Memory information including number of GC calls since start. The collections are read via the GC class using the "MaxGeneration" Property. So only reported GC counter are logged. Properties created are: AllocatedMemory, GCxCollectionCount with x being the generation number.