# Motivation
This small project is my solution to a problem I came across when trying to access multiple WCF-services
from a new ASP.NET Core project and could not get the official WCF-extension to properly create
the interfaces.

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

# This project includes:

## Multiple WCF services
Simple examples of WCF services that are connected to by the proxy-class via message contracts.

## WCF-proxy implementation
### A class library project that includes a proxy class that creates the WCF-connections from IOptions configuration files (todo) 
### Wrapper interfaces hiding the actual service implementation and wrapping the response objects to local model classes
### Factory class for creating the wrappers with their respective endpoint-urls and credentials (todo)
### Simple authentication implementation (todo)

## ASP.NET Core client that calls is used to demonstrate the use cases

## .NET Core -> .NET 4.6 dependency resolving through Nuget packages

# Running the solution
1. Open the solution in visual studio
2. Run the WCF service project
3. Run the NetCoreSample project

# Improvements still to be done
1. Improve the UI to a simple ASP.NET Core App
2. Inversion of Control
3. Multiple Wcf Endpoints
4. Config files & IOptions
5. Secret Manager (dev) & Environment Variables (prod)
