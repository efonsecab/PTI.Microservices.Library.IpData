# PTI.Microservices.Library.AzureTranslator

This is part of PTI.Microservices.Library set of packages

The purpose of this package is to facilitate the calls to Azure Translator APIs, while maintaining a consistent usage pattern among the different services in the group

**Examples:**

## Get Geo-Location Info by IP Address

    IpDataService ipStackService =
                new IpDataService(logger: _logger, _ipDataConfiguration, customHttpClient);
            var result = await ipStackService.GetIpGeoLocationInfoAsync(IPAddress.Parse(this.TestIpAddress));
