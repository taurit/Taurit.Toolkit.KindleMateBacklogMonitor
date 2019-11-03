FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Taurit.Toolkit.KindleMateBacklogMonitor/Taurit.Toolkit.KindleMateBacklogMonitor.csproj", "Taurit.Toolkit.KindleMateBacklogMonitor/"]
RUN dotnet restore "Taurit.Toolkit.KindleMateBacklogMonitor/Taurit.Toolkit.KindleMateBacklogMonitor.csproj"
COPY . .
WORKDIR "/src/Taurit.Toolkit.KindleMateBacklogMonitor"
RUN dotnet build "Taurit.Toolkit.KindleMateBacklogMonitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Taurit.Toolkit.KindleMateBacklogMonitor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taurit.Toolkit.KindleMateBacklogMonitor.dll"]