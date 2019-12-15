namespace Myvas.AspNetCore.TencentLbs
{
    public class JsonResponse<T> where T : class
    {
        public int? status { get; set; }
        public string message { get; set; }
        public string request_id { get; set; }
        public T result { get; set; }

    }
}
