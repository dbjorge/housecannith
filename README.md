# House Cannith

This project is a collection of tools for use by my gaming group's D&D campaign.

# Contributing

## Technology Stack

The basic stack in use is:
* [ASP.NET Core](https://get.asp.net/) and [C#](https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx) for cross-platform server-side code
* [React](https://facebook.github.io/react/) and [TypeScript](http://www.typescriptlang.org/) for client-side code
* [Webpack](https://webpack.github.io/) for building and bundling client-side resources
* [Bootstrap](http://getbootstrap.com/) for layout and styling
* [Azure SQL Server](https://azure.microsoft.com/en-us/services/sql-database/) for data storage
* [Azure App Service](https://azure.microsoft.com/en-us/services/app-service/) for the hosting platform
* [Visual Studio Team Services](https://www.visualstudio.com/team-services/) for [CI builds](https://housecannith.visualstudio.com/HouseCannith/_build/index?definitionId=1) and [CD deployments](https://housecannith.visualstudio.com/HouseCannith/_release?definitionId=1&_a=releases)

This page follows the guidance and conventions from the [*Using ASP.NET Core to Build Single-page Applications* Pluralsight course](https://pluralsight.com/courses/aspnet-core-build-single-page-applications) and Microsoft's [JavaScriptServices SpaTemplates](https://blogs.msdn.microsoft.com/webdev/2017/02/14/building-single-page-applications-on-asp-net-core-with-javascriptservices/). Those are excellent starting points if you're unfamiliar with parts of the stack.

## One-Time Setup

You'll need to do these steps once per development machine

* Get the necessary credentials and secrets from @dbjorge
* In the [Azure portal](https://portal.azure.com), go to the *comprendium* SQL server's Firewall settings and add your dev box's IP
* Install [Node.js LTS](https://nodejs.org) (at time of writing, 6.11.1)
* Install the [.NET Core SDK](https://www.microsoft.com/net/download/core) (at time of writing, 1.0.4)
* Clone the repo
* ```dotnet restore```
* ```npm install```
* Generate your own self-signed development https certificate (this doesn't get checked in). From an admin powershell prompt in the ```/HouseCannith.Frontend``` directory:
```
$cert = New-SelfSignedCertificate $cert = New-SelfSignedCertificate -Subject localhost -DnsName localhost -FriendlyName "HouseCannith Development (self-signed)" -KeyUsage DigitalSignature -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.1") -CertStoreLocation 'cert:/CurrentUser/Root'
Export-PfxCertificate -Cert $cert -FilePath 'developmentHttpsCert.pfx' -Password (ConvertTo-SecureString -String 'insecure-development-cert-password' -Force -AsPlainText)
```
* Set up access to the content database from your local machine. From a powershell prompt in the ```/HouseCannith.Frontend``` directory:
```
dotnet user-secrets set COMPRENDIUM_DATABASE_CONNECTION_STRING "Server=tcp:comprendium.database.windows.net,1433;Initial Catalog=comprendium;Persist Security Info=False;User ID=ComprendiumDev;Password=PASSWORD_FROM_KEYPASS;MultipleActiveResultSets=False;Encrypt=True"
```

## Building and Running Locally

* ```dotnet watch run```
* Navigate to https://localhost:5001
* Changes to both client and server code will take effect as you save files

## Deploying to Production

* push to master (Continuous Integration and Continuous Deployment via [VSTS](https://housecannith.visualstudio.com/HouseCannith))