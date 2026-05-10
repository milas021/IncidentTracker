FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY IncidentTracker.Api/IncidentTracker.Api.csproj IncidentTracker.Api
COPY IncidentTracker.Application/IncidentTracker.Application.csproj IncidentTracker.Application
COPY IncidentTracker.Infrastructure/IncidentTracker.Infrastructure.csproj IncidentTracker.Infrastructure
COPY IncidentTracker.Domain/IncidentTracker.Domain.csproj IncidentTracker.Domain
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IncidentTracker.Api.dll"]
