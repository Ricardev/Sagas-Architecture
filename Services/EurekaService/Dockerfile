FROM mcr.microsoft.com/dotnet/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["EurekaService.csproj", "."]
RUN dotnet restore "EurekaService.csproj"
COPY . .
RUN dotnet build "EurekaService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EurekaService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EurekaService.dll"]
