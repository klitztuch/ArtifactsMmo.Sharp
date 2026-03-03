FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ArtifactsMmo.Sharp/ArtifactsMmo.Sharp.csproj", "ArtifactsMmo.Sharp/"]
RUN dotnet restore "ArtifactsMmo.Sharp/ArtifactsMmo.Sharp.csproj"
COPY . .
WORKDIR "/src/ArtifactsMmo.Sharp"
RUN dotnet build "ArtifactsMmo.Sharp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ArtifactsMmo.Sharp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtifactsMmo.Sharp.dll"]
