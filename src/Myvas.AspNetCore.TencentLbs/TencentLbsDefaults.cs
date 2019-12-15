using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myvas.AspNetCore.TencentLbs
{
    public static class TencentLbsDefaults
    {
        public const string DefaultNationCode = "86";

        /// <summary>
        /// 地址解析服务地址：https://apis.map.qq.com/ws/geocoder/v1
        /// </summary>
        public const string GeocoderUrl = "https://apis.map.qq.com/ws/geocoder/v1";

        /// <summary>
        /// IP定位服务地址：https://apis.map.qq.com/ws/location/v1/ip
        /// </summary>
        public const string LocationUrl = "https://apis.map.qq.com/ws/location/v1/ip";

        /// <summary>
        /// 坐标转换服务地址：https://apis.map.qq.com/ws/coord/v1/translate
        /// </summary>
        public const string TranslateUrl = "https://apis.map.qq.com/ws/coord/v1/translate";

        /// <summary>
        /// 距离计算服务地址：https://apis.map.qq.com/ws/distance/v1
        /// 子服务：matrix
        /// </summary>
        public const string DistanceUrl = "https://apis.map.qq.com/ws/distance/v1";

        /// <summary>
        /// 行政区划服务地址：https://apis.map.qq.com/ws/district/v1
        /// 子服务: list, getchildren, search
        /// </summary>
        public const string DistrictUrl = "https://apis.map.qq.com/ws/district/v1";

        /// <summary>
        /// 地点搜索服务：https://apis.map.qq.com/ws/place/v1
        /// 子服务: search, suggestion
        /// </summary>
        public const string PlaceUrl = "https://apis.map.qq.com/ws/place/v1";

        /// <summary>
        /// 路线规划：https://apis.map.qq.com/ws/direction/v1
        /// 子服务：driving, walking, bicycling, transit
        /// </summary>
        public const string DirectionUrl = "https://apis.map.qq.com/ws/direction/v1";
    }
}
