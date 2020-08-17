# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /gbcashback
COPY *.sln .
COPY GBCashback.Tests/*.csproj GBCashback.Tests/
COPY GBCashback/*.csproj GBCashback/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /gbcashback/GBCashback
RUN dotnet build
WORKDIR /gbcashback/GBCashback.Tests
RUN dotnet test

# publish
FROM build AS publish
WORKDIR /gbcashback/GBCashback
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /gbcashback
COPY --from=publish /gbcashback/publish .
# ENTRYPOINT ["dotnet", "GBCashback.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet GBCashback.dll