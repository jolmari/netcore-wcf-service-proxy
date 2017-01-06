# Description
This small project is my solution to a problem I came across when trying to access multiple WCF-services
from a new ASP.NET Core project and could not get the official WCF-extension to properly create
the interfaces.

There is a profound lack of articles and examples about this topic, so here is my take on the issue.

# Solution projects

## AspNetStub
A small stub project for 

## WCFProxy
This project implements the WCFProxy 

The service references that are added here are not used directly to access the services, but are there
to reference necessary type definitions for the proxy class to function.

## WcfService
Contains a very naive and simple WCF-service implementation for getting and saving country names and codes. This
is the service that we are accessing indirectly via the proxy class.

# Running the solution
