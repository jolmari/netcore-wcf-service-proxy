# Motivation
This small project is my solution to a problem I came across when trying to access multiple WCF-services
from a new ASP.NET Core project and could not get the official WCF-extension to properly create
the interfaces.

Most of the examples found by simple googling came up with simple connector implementations. These did not
showcase the actual problem and were lacking in situations where multiple connections are needed. The aim here
is to create a generic, yet simple, way to handle such a situation.

# Problem description
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
# Solution
1. Services are implemented in WcfServices
2. WcfProxy project uses service references to create service contracts
3. Wrapper classes in WcfProxy-project mask the actual services implementations and instad call them through the Proxy-class.
4. Wrapper maps the Dtos to separate model classes
5. ASP.NET Core injects the wrappers where they are used

The Wcf services are completely isolated from the ASP.NET implementation and no references are needed to WcfServices-project.

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

# This project includes:

* Multiple WCF services
   * Simple examples of WCF services that are connected to by the proxy-class via message contracts.
   * IoC using SimpleInjector and its Wcf Integration Extension

* WCF-proxy implementation
   * A class library project that wraps the actual service contracts with proxy implementations
   * Simple authentication implementation (todo)

* ASP.NET Core client that calls is used to demonstrate the use cases

##Troubleshooting
1. The services don't start:
  * Solution Explorer -> Solution -> Properties -> Startup Project. Start WcfServices & NetCoreWebApp.
