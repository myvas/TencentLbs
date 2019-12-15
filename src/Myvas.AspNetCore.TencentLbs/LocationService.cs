using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Net;
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

        public LocationService(IOptions<TencentLbsOptions> optionsAccessor)
            : this(optionsAccessor, NullLoggerFactory.Instance.CreateLogger<LocationService>())
        {
        }
        public LocationService(IOptions<TencentLbsOptions> optionsAccessor, ILogger<LocationService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = optionsAccessor?.Value ?? throw new ArgumentNullException(nameof(optionsAccessor));
            _backchannel = _options.Backchannel ?? new HttpClient();
        }

        public async Task<AddressResult> GetAddress(Location location, bool poi)
        {
            var url = $"{TencentLbsDefaults.GeocoderUrl}/?location={location.Latitude},{location.Longitude}&key={_options.Key}";
            if (poi) url += "&get_poi=1";
            url = Signature.TrySignaturedGet(_options.SecretKey, url);

            var resp = await _backchannel.GetAsync(url);
            if (resp.IsSuccessStatusCode)
            {
                Debug.WriteLine(await resp.Content.ReadAsStringAsync());
                var json = await resp.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<JsonResponse<AddressResult>>(json);
                if (result.status.GetValueOrDefault(999) == 0)
                    return result.result;
                else
                    throw new TencentLbsException(result.status.Value, result.message, result.request_id);
            }

            return null;
        }

        public async Task<Location> GetLocation(string address, string region)
        {
            address = WebUtility.UrlEncode(address);
            region = WebUtility.UrlEncode(region);
            var url = $"{TencentLbsDefaults.GeocoderUrl}?address={address}&key={_options.Key}";
            if (!string.IsNullOrWhiteSpace(region))
            {
                url += $"&region={region}";
            }
            url = Signature.TrySignaturedGet(_options.SecretKey, url);

            var resp = await _backchannel.GetAsync(url);
            if (resp.IsSuccessStatusCode)
            {
                Debug.WriteLine(await resp.Content.ReadAsStringAsync());
                var json = await resp.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<JsonResponse<LocationResult>>(json);
                if (result.status.GetValueOrDefault(999) == 0)
                    return result.result.location;
                else
                    throw new TencentLbsException(result.status.Value, result.message, result.request_id);
            }

            return null;
        }

        public async Task<Location> GetIpLocation(string ipv4)
        {
            var url = $"{TencentLbsDefaults.LocationUrl}?ip={ipv4}&key={_options.Key}";
            url = Signature.TrySignaturedGet(_options.SecretKey, url);

            var resp = await _backchannel.GetAsync(url);
            if (resp.IsSuccessStatusCode)
            {
                Debug.WriteLine(await resp.Content.ReadAsStringAsync());
                var json = await resp.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<JsonResponse<LocationResult>>(json);
                if (result.status.GetValueOrDefault(999) == 0)
                    return result.result.location;
                else
                    throw new TencentLbsException(result.status.Value, result.message, result.request_id);
            }

            return null;
        }
    }
}
