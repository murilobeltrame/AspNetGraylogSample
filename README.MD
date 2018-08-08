# AspNetGraylogSample

This is a very simple sample showing how to log an ASP.Net Core on Graylog

## Summary

- [Requirements](#requirements)
- [Running](#running)
   - [Dependencies](#dependencies)
   - [Application](#application)
- [Logging ASP.Net Core](#logging-aspnet-core)
- [Exploring Graylog](#exploring-graylog)
- [References](#references)

## Requirements

| Tool | Desc | Download |
| ---- | ---- | -------- |
| Docker | Specially to run the Compose to run up all the solution dependencies like Mongo, Graylog and Elastic Search | [https://store.docker.com/](https://store.docker.com/) |
| DotNet Core SDK | To run the sample application. You can optionally run the sample application on a container but you will need to deal with networking stuff | [https://www.microsoft.com/net/download](https://www.microsoft.com/net/download) |

## Running

### Dependencies

Run dependencies means run all stack required for Graylog (MongoDb, ElasticSearch and Graylog itself).
By default, Graylog locks some host ports:

| Ports | Desc |
| ----- | ---- |
| **9000** | Graylog web interface and REST API |
| **514** | Syslog TCP |
| **514/udp** | Syslog UDP |
| **12201** | GELF TCP |
| **12201/udp** | GELF UDP |

To run the solution dependencies, run the following command on project root:

```sh
docker-compose up -d
```

> The `-d` option is opitional and tells the command to run on background freeing up the terminal.

### Application

To run the sample application, just run the command

```sh
dotnet run -p ./SampleMVC
```

> By default, the sample application locks the **5000** port on host.

## Logging ASP.Net Core

The sample applications uses the [Gelf.Extensions.Logging](https://www.nuget.org/packages/Gelf.Extensions.Logging/) library, that relyes on [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/), enabling a very seamless integration to the application pipeline and enabling a very simple loggin implementation.
To log informations to Graylog just use the common pattern as described in the [ASP.Net Core Documentation](https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1).

## Exploring Graylog

The view logged information on Graylog, just access the web interface.
By default, it should be running on `http://localhost:9000`.

## References

- [https://hub.docker.com/r/graylog/graylog/](https://hub.docker.com/r/graylog/graylog/)
- [https://github.com/mattwcole/gelf-extensions-logging](https://github.com/mattwcole/gelf-extensions-logging)
- [https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1](https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1)