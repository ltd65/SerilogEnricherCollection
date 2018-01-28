# SerilogEnricherCollection

A collection of some simple enrichers for serilog

## Important notice

I use this also as a learning project for github, open source and handling of nuget packages especially in light of the support for different .net/netstandard versions.
Therefore please be aware that there is now in the beginning a fair chances that the repo is sometimes broken or that files are not structured in the way they should.

## Usage

To use the enricher collection you can install it via nuget:

Until the project is not out of it's experimental state there will be no package available on nuget. First release will be done when I am happy with the packaging.
```powershell
Install-Package Name not decided yet
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
```

or in appconfig.json:

```JSON
formation missing
```

## Included Enrichers

* WithUtcTimestamp: Adds the timestamp of the logging event in Utc. Property name added: "UtcTimestamp"
* WithThreadName: Adds the name found in Thread.Name. Property name added: "ThreadName"
* WithMemoryInformation: Add Memory information including number of GC calls since start.