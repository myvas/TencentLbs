using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myvas.AspNetCore.TencentLbs
{
    public interface ITencentLbs
    {
        Task<Location> GetIpLocation(string ipv4);
        Task<Location> GetLocation(string address, string region = null);
        Task<AddressComponent> GetAddress(Location location, bool poi = false);
    }
}
