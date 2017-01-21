# Motivation
This small project is my solution to a problem I came across when trying to access multiple WCF-services
from a new ASP.NET Core project and could not get the official WCF-extension to properly create
the interfaces.

# Description
The first step in trying to enable WCF-services is to use the official Visual Studio extension found here:

https://blogs.msdn.microsoft.com/webdev/2016/06/26/wcf-connected-service-for-net-core-1-0-0-and-asp-net-core-1-0-0-is-now-available/

The WCF Connected service for .NET Core 1.0 and ASP.NET Core 1.0 should fit to most use cases, but the preview
version is not compatible with more complex services. You might face an error similar to the following, in such a
case, the best option is to connect programmatically to the service via a proxy. This repository shows one way to
implement this approach.

```
Scaffolding Code …
Error:Error: No endpoints compatible with .Net Core apps were found.
An error occurred in the tool.

Failed to generate service reference. 
```

# Solution projects

## NetCoreSample
A simple .NET Core console application that references the WCFProxy implementation to call the CountryService
indirectly. 

## WcfProxy
This project contains the definition for the WcfProxy class and a wrapper class that implements the ICountryService
interface. The wrapper implements the same interfaces as the service would, but it calls the actual service through
a proxy.

The proxy class itself opens a client connection to the service programmatically, enabling the actual consumer to
specify the endpoint url. 

## WcfService
Contains a very naive and simple WCF-service implementation for getting and saving country names and codes. This

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