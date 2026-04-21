# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos de projeto
COPY ["EnergyMonitoringAPI.csproj", "./"]
RUN dotnet restore "EnergyMonitoringAPI.csproj"

# Copiar todo o código
COPY . .

# Build da aplicação
RUN dotnet build "EnergyMonitoringAPI.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "EnergyMonitoringAPI.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copiar arquivos publicados
COPY --from=publish /app/publish .

# Definir entrypoint
ENTRYPOINT ["dotnet", "EnergyMonitoringAPI.dll"]