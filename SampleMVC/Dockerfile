FROM microsoft/dotnet:2.1-sdk-alpine AS builder

WORKDIR /src

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish --configuration Release --output /output

FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime

WORKDIR /app
COPY --from=builder /output .
ENTRYPOINT ["dotnet", "SampleMVC.dll"]