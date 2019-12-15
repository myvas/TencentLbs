namespace Myvas.AspNetCore.TencentLbs
{
    public class AdInfo
    {
        public string nation_code { get; set; }
        /// <summary>
        /// 有时是数字，有时是字符串
        /// </summary>
        public object adcode { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public string nation { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string district { get; set; }
    }
}
