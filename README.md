# Motivation
This small project is my solution to a problem I came across when trying to access multiple WCF-services
from a new ASP.NET Core project and could not get the official WCF-extension to properly create
the interfaces.

Most of the examples found by simple googling came up with simple connector implementations. These did not
showcase the actual problem and were lacking in situations where multiple connections are needed. The aim here
is to create a generic, yet simple, way to handle such a situation.

# Description
The first step in trying to enable WCF-services is to use the official Visual Studio extension found here:

https://blogs.msdn.microsoft.com/webdev/2016/06/26/wcf-connected-service-for-net-core-1-0-0-and-asp-net-core-1-0-0-is-now-available/

The WCF Connected service for .NET Core 1.0 and ASP.NET Core 1.0 should fit to most use cases, but the preview
version is not compatible with more complex (or incorrectly configured) services. You might face an error similar to the following, in such a
case, the best option is to connect programmatically to the service via a proxy class library. This repository shows one way to
implement this approach.

```
Scaffolding Code …
Error:Error: No endpoints compatible with .Net Core apps were found.
An error occurred in the tool.

Failed to generate service reference. 
```

# Running the solution
```
git clone https://github.com/jolmari/netcore-wcf-service-proxy.git
```

1. Open the solution in Visual Studio 2015 with relevant ASP.NET Core tools installed, or VS2017
https://www.microsoft.com/net/core#windowsvs2015
2. Build solution
3. Open the NetCoreWebApp project, open context menu on references and restore packages
3. Run the solution (Ctrl+F5/F5)

![Alt text](/ui.png?raw=true "Example UI")

##Troubleshooting
1. The services don't start:
  * Solution Explorer -> Solution -> Properties -> Startup Project. Start CountryWcfService, NetCoreWebApp, PersonWcfService.

# This project includes:

* Multiple WCF services
Simple examples of WCF services that are connected to by the proxy-class via message contracts.

* WCF-proxy implementation
   * A class library project that includes a proxy class that creates the WCF-connections from IOptions configuration files (todo) 
   * Wrapper interfaces hiding the actual service implementation and wrapping the response objects to local model classes
   * Factory class for creating the wrappers with their respective endpoint-urls and credentials
   * Simple authentication implementation (todo)

* ASP.NET Core client that calls is used to demonstrate the use cases
* .NET Core -> .NET 4.6 dependency resolving through Nuget packages
