# ProfulfilmentSharp: A .NET library for Profulfilment.

ProfulfilmentSharp is a .NET library that enables you to authenticate and make API calls to Profulfilment Warehouse. It's great for 
building custom ProfulfilmentSharp Apps using C# and .NET. You can quickly and easily get up and running with ProfulfilmentSharp
using this library.

# Installation

ProfulfilmentSharp is [available on NuGet](https://www.nuget.org/packages/ProfulfilmentSharp/). Use the package manager
console in Visual Studio to install it:

```
Install-Package ProfulfilmentSharp
```

If you're using .NET Core, you can use the `dotnet` command from your favorite shell:

```
dotnet add package ProfulfilmentSharp
```

# Using ProfulfilmentSharp

**Note**: All instances of `user_name` and `password` in the examples below **do not refer to your ProfulfilmentSharp cerdentials**.

```cs
var productService = new ProductService("user_name", "password");
```

# APIS Implemented
- Order
- Product
