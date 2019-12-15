using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Myvas.AspNetCore.TencentLbs.UnitTests
{
    public class DependencySetupFixture
    {
        public ServiceProvider ServiceProvider { get; }

        public DependencySetupFixture()
        {
            var services = new ServiceCollection();
            services.AddTencentLbs(o =>
            {
                o.Key = "NH7BZ-CTYKR-7CAWL-WTIU4-WLRWT-UQFYW";
                o.SecretKey = "vf0RDbVbh8pbIXIgYBF52R65d4DVKQk2";
            });

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
