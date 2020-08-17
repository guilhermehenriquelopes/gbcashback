FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS final
WORKDIR /app
COPY --from=build /app .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet GBCashback.dll