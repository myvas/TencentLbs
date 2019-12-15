using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Xunit;

namespace Myvas.AspNetCore.TencentLbs.UnitTests
{
    public class SignatureTest : IClassFixture<DependencySetupFixture>
    {
        private ServiceProvider _serviceProvider;

        public SignatureTest(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void TestSignatureGet()
        {
            var secretKey = "SWvT26ypwq5Nwb5RvS8cLi6NSoH8HlJX";
            var url = "https://apis.map.qq.com/ws/geocoder/v1?location=28.7033487,115.8660847&key=5Q5BZ-5EVWJ-SN5F3-K6QBZ-B3FAO-RVBWM";
            var result = Signature.TrySignaturedGet(secretKey, url);
            Assert.Equal("https://apis.map.qq.com/ws/geocoder/v1?location=28.7033487,115.8660847&key=5Q5BZ-5EVWJ-SN5F3-K6QBZ-B3FAO-RVBWM&sig=90da272bfa19122547298e2b0bcc0e50", result);
        }

        [Fact]
        public void TestSignatureGet2()
        {
            var secretKey = "SWvT26ypwq5Nwb5RvS8cLi6NSoH8HlJX";
            var url = "https://apis.map.qq.com/ws/geocoder/v1/?location=28.7033487,115.8660847&key=5Q5BZ-5EVWJ-SN5F3-K6QBZ-B3FAO-RVBWM";
            var result = Signature.TrySignaturedGet(secretKey, url);
            Assert.Equal("https://apis.map.qq.com/ws/geocoder/v1/?location=28.7033487,115.8660847&key=5Q5BZ-5EVWJ-SN5F3-K6QBZ-B3FAO-RVBWM&sig=44dc01e036e685fa8e4c4a081357f234", result);
        }

        [Fact]
        public void TestSignaturePost()
        {
            var secretKey = "KIpUE64TiqLuF2vBJCLOvkFVy0we0Ypp";
            var url = "https://apis.map.qq.com/place_cloud/data/create";
            var json = File.ReadAllText("Data/json1.json");
            var result = Signature.TrySignaturedPost(secretKey, url, json);
            Assert.Equal("https://apis.map.qq.com/place_cloud/data/create?sig=782f2ca97e6592741049823787203e9c", result);
        }
    }
}
