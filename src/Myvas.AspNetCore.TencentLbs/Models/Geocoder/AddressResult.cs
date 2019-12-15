namespace Myvas.AspNetCore.TencentLbs
{
    public class AddressResult
    {
        public string address { get; set; }
        public FormattedAddress formatted_addresses { get; set; }
        public AddressComponent address_component { get; set; }
        public AdInfo ad_info { get; set; }
        public AddressReference address_reference { get; set; }
    }
}
