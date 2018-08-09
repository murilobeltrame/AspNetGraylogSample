FROM microsoft/dotnet:2.1-sdk-alpine AS builder

WORKDIR /src

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish --configuration Release --output /out

FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime

WORKDIR /app

COPY --from=builder /out .

ENTRYPOINT [ "dotnet", "SampleMVCCore.dll" ]