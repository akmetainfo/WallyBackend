# Wally — simple home finance app.

> ### This repository contains server-side (backend). For client-side (frontend) see [WallyFrontend](https://github.com/akmetainfo/WallyFrontend)

# How it works

This application is using ASP.NET Core 3.1 with:

- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/),
- CQRS and [MediatR](https://github.com/jbogard/MediatR),
- JWT authentication using [ASP.NET Core JWT Bearer Authentication](https://github.com/aspnet/Security/tree/master/src/Microsoft.AspNetCore.Authentication.JwtBearer).

# Installation

Quick guide:

- Modify DefaultConnection param in appsettings.json to point at your SQL server
- Open Visual Studio Nuget console and run Update-Database
- Run users.sql (see credentials inside)
- Run currencies.sql

# License

Licenced under an MIT licence.