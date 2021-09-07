FROM mcr.microsoft.com/dotnet/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["ProductService.csproj", "."]
RUN dotnet restore "ProductService.csproj"
COPY . .
RUN dotnet build "ProductService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductService.dll"]
