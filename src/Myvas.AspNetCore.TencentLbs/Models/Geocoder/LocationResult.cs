namespace Myvas.AspNetCore.TencentLbs
{
    public class LocationResult
    {
        public Location location { get; set; }
        public AddressComponent address_componnet { get; set; }
        public AdInfo ad_info { get; set; }

        public int? similarity { get; set; }
        public int? deviation { get; set; }
        public int? reliability { get; set; }
        public int? level { get; set; }
    }
}
