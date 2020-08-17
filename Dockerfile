# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY GBCashback.Tests/*.csproj GBCashback.Tests/
COPY GBCashback/*.csproj GBCashback/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/GBCashback
RUN dotnet build
WORKDIR /src/GBCashback.Tests
RUN dotnet test

# publish
FROM build AS publish
WORKDIR /src/GBCashback
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "GBCashback.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet GBCashback.dll