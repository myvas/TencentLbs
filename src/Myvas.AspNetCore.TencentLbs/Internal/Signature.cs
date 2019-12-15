using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Myvas.AspNetCore.TencentLbs
{
    public static class Signature
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="secretKey"></param>
        /// <param name="url"></param>
        /// <returns>签名后的URL</returns>
        public static string TrySignaturedGet(string secretKey, string url)
        {
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                return url;
            }

            var uri = new Uri(url);

            var path = uri.AbsolutePath;
            var query = WebUtility.UrlDecode(uri.Query);
            var orderedQuery = string.Join("&", query.Substring(1).Split('&').OrderBy(x => x).ToArray());

            var newPathAndQuery = $"{path}?{orderedQuery}{secretKey}";
            var md5 = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(newPathAndQuery));
            var signature = BitConverter.ToString(md5).Replace("-", "").ToLower();

            var newUrl = url + "&sig=" + signature;
            return newUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secretKey"></param>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns>签名后的URL</returns>
        public static string TrySignaturedPost(string secretKey, string url, string json)
        {
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                return url;
            }

            var uri = new Uri(url);

            var path = uri.AbsolutePath;
            // 获取json对象中的所有一级属性
            var rootElements = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            // 将所有一级属性值转换成最紧凑化字符串
            var shrinkRootElements = new Dictionary<string, string>();
            var shrinkJsonSerializerOptions = new JsonSerializerOptions()
            {
                AllowTrailingCommas = false,
                WriteIndented = false,
                ReadCommentHandling = JsonCommentHandling.Skip,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };
            foreach (var key in rootElements.Keys)
            {
                var value = rootElements[key];
                var shrinkValue = JsonSerializer.Serialize(value, typeof(object), shrinkJsonSerializerOptions);
                shrinkValue = shrinkValue.Trim('"');
                shrinkRootElements.Add(key, shrinkValue);
            }
            // 将所有一级属性转换成key=value形式字符串，如：data=[{"ud_id":"156985","title":"海淀区苏州街营业部","location":{"lat":39.983988,"lng":116.307709},"x":{"price":15.5}}]&key=5Q5BZ-5EVWJ-SN5F3-K6QBZ-*****&table_id=5d405395d230bf1d9416be10
            // 排序后用&连接
            var orderedJsonQuery = string.Join("&", shrinkRootElements.Select(x => x.Key + "=" + x.Value).OrderBy(x => x).ToArray());
            var newPathAndQuery = $"{path}?{orderedJsonQuery}{secretKey}";
            var md5 = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(newPathAndQuery));
            var signature = BitConverter.ToString(md5).Replace("-", "").ToLower();

            var newUrl = url + (url.IndexOf('?') > 0 ? "&" : "?") + "sig=" + signature;
            return newUrl;
        }
    }
}
