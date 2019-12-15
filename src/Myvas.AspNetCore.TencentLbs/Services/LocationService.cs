using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Myvas.AspNetCore.TencentLbs
{
    public class LocationService : ITencentLbs
    {
        private readonly HttpClient _backchannel;

        private readonly ILogger _logger;
        private readonly TencentLbsOptions _options;


        public LocationService(IOptions<TencentLbsOptions> optionsAccessor, ILogger<LocationService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = optionsAccessor?.Value ?? throw new ArgumentNullException(nameof(optionsAccessor));
            _backchannel = _options.Backchannel ?? new HttpClient();
        }

        public async Task<AddressComponent> GetAddress(Location location, bool poi)
        {
            var url = $"{TencentLbsDefaults.GeocoderUrl}/?location={location.Latitude},{location.Longitude}&key={_options.Key}";
            if (poi) url += "&get_poi=1";

            var resp = await _options.Backchannel.GetAsync(url);
            if (resp.IsSuccessStatusCode)
            {
                var json = await resp.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<JsonResponse<AddressResult>>(json);
                return result.result.address_componnet;
            }

            return null;
        }

        public async Task<Location> GetLocation(string address, string region)
        {
            var url = $"{TencentLbsDefaults.GeocoderUrl}/?address={address}&key={_options.Key}";

            if (!string.IsNullOrWhiteSpace(region))
            {
                url += $"&region={region}";
            }

            var resp = await _options.Backchannel.GetAsync(url);
            if (resp.IsSuccessStatusCode)
            {
                var json = await resp.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<JsonResponse<LocationResult>>(json);
                return result.result.location;
            }

            return null;
        }
        
        public async Task<Location> GetIpLocation(string ipv4)
        {
            var url = $"{TencentLbsDefaults.LocationUrl}?ip={ipv4}&key={_options.Key}";

            var resp = await _options.Backchannel.GetAsync(url);
            if (resp.IsSuccessStatusCode)
            {
                var json = await resp.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<JsonResponse<LocationResult>>(json);
                return result.result.location;
            }

            return null;
        }
    }
}
