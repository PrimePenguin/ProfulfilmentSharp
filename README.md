# ProfulfillmentSharp: A .NET library for Profulfillment.

Profulfillment is a .NET library that enables you to authenticate and make API calls to Profulfillment. It's great for 
building custom Profulfillment Apps using C# and .NET. You can quickly and easily get up and running with Profulfillment
using this library.

# Installation

Profulfillment is [available on NuGet](https://www.nuget.org/packages/Profulfillment/). Use the package manager
console in Visual Studio to install it:

```
Install-Package Profulfillment
```

If you're using .NET Core, you can use the `dotnet` command from your favorite shell:

```
dotnet add package Profulfillment
```

# Using Profulfillment

**Note**: All instances of `user_name` and `password` in the examples below **do not refer to your Profulfillment cerdentials**.

```cs
var productService = new ProductService("user_name", "password");
```

# APIS Implemented
- Order
- Product
