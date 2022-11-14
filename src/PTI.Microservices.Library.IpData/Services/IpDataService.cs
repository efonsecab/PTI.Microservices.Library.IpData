using Microsoft.Extensions.Logging;
using PTI.Microservices.Library.Interceptors;
using PTI.Microservices.Library.IpData.Configuration;
using PTI.Microservices.Library.IpData.Models.GetGeoLocationInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.IpData.Services
{
    public class IpDataService
    {
        private ILogger<IpDataService> Logger { get; }
        private CustomHttpClient CustomHttpClient { get; }
        private IpDataConfiguration IpDataConfiguration { get; }

        /// <summary>
        /// Creates a new instance of <see cref="IpDataService"/>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="ipDataConfiguration"></param>
        /// <param name="customHttpClient"></param>
        public IpDataService(ILogger<IpDataService> logger,
            IpDataConfiguration ipDataConfiguration, CustomHttpClient customHttpClient)
        {
            this.Logger = logger;
            this.CustomHttpClient = customHttpClient;
            this.IpDataConfiguration = ipDataConfiguration;
        }

        /// <summary>
        /// Gets the geo location info for the specified ip address
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetGeoLocationInfoResponse> GetIpGeoLocationInfoAsync(IPAddress ipAddress,
            CancellationToken cancellationToken = default)
        {
            string requestUrl =
                $"https://api.ipdata.co/{ipAddress}?api-key={IpDataConfiguration.Key}";
            try
            {
                var result = await CustomHttpClient
                    .GetFromJsonAsync<GetGeoLocationInfoResponse>(requestUrl, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
