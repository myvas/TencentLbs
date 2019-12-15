# TencentLbs and TencentMap [![GitHub (Pre-)Release Date](https://img.shields.io/github/release-date-pre/myvas/TencentLbs?label=github)](https://github.com/myvas/TencentLbs)
* Myvas.AspNetCore.TencentLbs (LBS, Location Based Service) [![NuGet](https://img.shields.io/nuget/v/Myvas.AspNetCore.TencentLbs.svg)](https://www.nuget.org/packages/Myvas.AspNetCore.TencentLbs)

  * IP定位服务：通过IP地址，定位所在位置（坐标）
  * 地址解析服务：通过地址，获取坐标（腾讯地图、高德地图适用）
  * 逆地址解析服务：通过坐标，获取地址描述（行政区划、街道、地标、商圈、路口等）

* Myvas.AspNetCore.Components.TencentMap (Blazor Components) [![NuGet](https://img.shields.io/nuget/v/Myvas.AspNetCore.Components.TencentMap.svg)](https://www.nuget.org/packages/Myvas.AspNetCore.Components.TencentMap)
  * 以指定坐标为中心，显示地图
  * 在地图上显示自定义标记

## Usage1: Myvas.AspNetCore.TencentLbs
### ConfigureServices
```csharp
services.AddTencentLbs(options =>
{
    options.Key = Configuration["TencentLbs:Key"];
})
// WebService API (not implemented yet!)
.AddWebServiceApi(options =>
{
    options.SecretKey = Configuration["TencentLbs:SecretKey"];
});
```

### Inject & Invoke
```csharp
private readonly ITencentLbs _lbs;

public XxxController(ITencentLbs lbs)
{
    _lbs = lbs ?? throw new ArgumentNullException(nameof(lbs);
}

public IActionResult Xxx()
{
    //...
    var location = await _lbs.GetCurrentLocation();
    var location2 = await _lbs.GetLocation("广州市天河区晴旭街2号");
    var address = await _lbs.GetAddress(location);
}
```

### Inject on Razor
```csharp
@inject Myvas.AspNetCore.TencentLbs.ITencentLbs lbs

<p>经度: @(lbs.GetCurrentLocation().Longitude)</p>
<p>纬度: @(lbs.GetCurrentLocation().Latitude)</p>

...
```

## Usage2: Myvas.AspNetCore.Components.TencentMap

### ConfigureServices
```csharp
services.AddTencentLbs(options =>
{
    options.Key = Configuration["TencentLbs:Key"];
})
// WebService API
.AddWebServiceApi(options =>
{
    options.SecretKey = Configuration["TencentLbs:SecretKey"];
});
```

### Blazor Components
```csharp
@inject Myvas.AspNetCore.TencentLbs.ITencentLbs lbs
@using Myvas.AspNetCore.Components

<TencentMap>
    <Point Longtitude="@(lbs.GetCurrentLocation().Longitude)" Latitude="@(lbs.GetCurrentLocation().Latitude)">
        <p>我的位置</p>
    </Point>
</TencentMap>
```

### References:
- https://lbs.qq.com
