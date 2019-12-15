# TencentLbs and Map Blazor Components
* LBS(Location Based Service)
0.IP��λ����ͨ��IP��ַ����λ����λ�ã����꣩
1.��ַ��������ͨ����ַ����ȡ���꣨��Ѷ��ͼ���ߵµ�ͼ���ã�
2.���ַ��������ͨ�����꣬��ȡ��ַ�����������������ֵ����رꡢ��Ȧ��·�ڵȣ�

* Map Blazor Components
1.��ָ������Ϊ���ģ���ʾ��ͼ
2.�ڵ�ͼ����ʾ�Զ�����

## Demo
�����ޣ�

## NuGet
* Myvas.AspNetCore.TencentLbs
[![NuGet](https://img.shields.io/nuget/v/Myvas.AspNetCore.TencentLbs.svg)](https://www.nuget.org/packages/Myvas.AspNetCore.TencentLbs) [![GitHub (Pre-)Release Date](https://img.shields.io/github/release-date-pre/myvas/AspNetCore.TencentLbs?label=github)](https://github.com/myvas/AspNetCore.TencentLbs)

* Myvas.AspNetCore.Components.TencentMap
[![NuGet](https://img.shields.io/nuget/v/Myvas.AspNetCore.Components.TencentMap.svg)](https://www.nuget.org/packages/Myvas.AspNetCore.Components.TencentMap) [![GitHub (Pre-)Release Date](https://img.shields.io/github/release-date-pre/myvas/AspNetCore.TencentLbs?label=github)](https://github.com/myvas/AspNetCore.TencentLbs)

## Usage: Myvas.AspNetCore.TencentLbs
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
    var location2 = await _lbs.GetLocation("����������������2��");
    var address = await _lbs.GetAddress(location);
}
```

### Inject on Razor
```csharp
@inject Myvas.AspNetCore.TencentLbs.ITencentLbs lbs

<p>����: @(lbs.GetCurrentLocation().Longitude)</p>
<p>γ��: @(lbs.GetCurrentLocation().Latitude)</p>

...
```

## Myvas.AspNetCore.Components.TencentMap

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
        <p>�ҵ�λ��</p>
    </Point>
</TencentMap>
```

### References:
- https://lbs.qq.com
