namespace Myvas.AspNetCore.TencentLbs
{
    public class AccuracyLocation : Location
    {
        public decimal Accuracy { get; set; }
        public override string ToString()
        {
            return $"Location: ({Latitude}, {Longitude}) with accuracy {Accuracy}";
        }
    }
}
