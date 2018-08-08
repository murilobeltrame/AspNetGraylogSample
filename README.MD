# AspNetGraylogSample

This is a very simple sample showing how to log an ASP.Net Core on Graylog

## Summary

- Requirements
- Running
   - Dependencies
   - Application
- Logging on ASP.Net Core
- Exploring Graylog
- References

## Requirements

| Tool | Desc | Download |
| ---- | ---- | -------- |
| Docker | Specially to run the Compose to bring up all the solution dependencies like Mongo, Graylog and Elastic Search | [https://store.docker.com/](https://store.docker.com/) |
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

> The `-d` option is opitional and tells the command to run on background freeing up the terminal

### Application

To run the sample application, just run the command

```sh
dotnet run -p ./SampleMVC
```