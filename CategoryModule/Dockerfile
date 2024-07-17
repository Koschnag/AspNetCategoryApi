# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CategoryModule.csproj", "./CategoryModule/"]
RUN dotnet restore "CategoryModule/CategoryModule.csproj"
COPY . ./CategoryModule
WORKDIR /src/CategoryModule
RUN dotnet build "CategoryModule.csproj" -c Release -o /app/build
RUN dotnet publish "CategoryModule.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY entrypoint.sh ./
RUN chmod +x ./entrypoint.sh
COPY --from=build /app/publish .
RUN apt-get update && apt-get install -y postgresql-client
