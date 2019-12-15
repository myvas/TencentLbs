using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Myvas.AspNetCore.TencentLbs.UnitTests
{

    public class TencentLbsTest : IClassFixture<DependencySetupFixture>
    {
        private ServiceProvider _serviceProvider;

        public TencentLbsTest(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }


        [Fact]
        public async Task Test1()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ITencentLbs>();
                var result = await context.GetLocation("广东省广州市天河区天府路1号");

                Assert.NotNull(result);
                Assert.Equal(113.362m, result.Longitude);
                Assert.Equal(23.1235m, result.Latitude);
            }
        }

        [Fact]
        public async Task Test2()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ITencentLbs>();
                var result = await context.GetAddress(new Location(113.362m, 23.1235m));

                Assert.NotNull(result);
                Assert.Equal("广东省广州市天河区黄埔大道中", result.address);
            }
        }

        [Fact]
        public async Task Test3()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ITencentLbs>();
                var result = await context.GetIpLocation("59.41.8.215");

                Assert.NotNull(result);
                Assert.Equal(113.26436m, result.Longitude);
                Assert.Equal(23.12908m, result.Latitude);
            }
        }

    }
}
