# SmartSystems .NET Client Web API, Angular 5 [![Build status]
## Project prototipe to demonstrate using .NET Core 2, Web API2, Angular 5, PrimeNG 5.0,TypeScript, ECMAScript6, SCSS.
* [1](Home Page is public available top-menu for "Login/Registration"and Main Drop Menu "Reports") 
	includes Sub-menu 1.BrokerageBrokers and 2.Brokers. 
	(Menu is visible but access will be forbidden until user not authenticated for Reports)
* [2]Authorisation implementation Microsoft.AspNetCore.Identity:
	* [2.1]Authenticated users can get access to Sub-Menu invoke to populate via  Web-API service 
	or master table BrokerageBrokers or single table Brokerage 
	* [2.2]BrokerageBrokers master table and table Broker (One-To-Menu relation) 
	Second Grid Brokers will be  Drop Down when user click  Master record Brokerage in the first grid.
* [5]MS SQL (Express) and Azure SQL Server Script Create and Populate DataBase.
* [6]Web Services: WebAPI implementation SPA DI Repositories Busines Access Layer (BAL), Data Access Layer (DAL), Presentation Layer Angular as conception without pretention  full  implementation
* [7]Done ASP.NET Core 2 Identity



## RabbitMQ .NET Client [![Build status](https://ci.appveyor.com/api/projects/status/33srpo7owl1h3y4e?svg=true)](https://ci.appveyor.com/project/rabbitmq/rabbitmq-dotnet-client)

This repository contains source code of the [RabbitMQ .NET client](http://www.rabbitmq.com/dotnet.html).
The client is maintained by the [RabbitMQ team at Pivotal](http://github.com/rabbitmq/).


## Dependency (Binaries and Nuget Artifact)

There are two ways to consume the client:

 * [NuGet artifacts](https://www.nuget.org/packages/RabbitMQ.Client/) (`4.x` and `3.6.x` series)
 * [Binary releases](https://github.com/rabbitmq/rabbitmq-server/releases) (`3.6.x` series, distributed with RabbitMQ releases)

[Release archive up to 3.4.3](https://bintray.com/rabbitmq/archive/rabbitmq-dotnet-client) is available from Bintray.
