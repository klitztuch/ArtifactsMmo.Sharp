FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ArtifactsMmo.Sharp.Client/ArtifactsMmo.Sharp.Client.csproj", "ArtifactsMmo.Sharp.Client/"]
COPY ["ArtifactsMmo.Sharp.Core/ArtifactsMmo.Sharp.Core.csproj", "ArtifactsMmo.Sharp.Core/"]
COPY ["ArtifactsMmo.Sharp.Demo/ArtifactsMmo.Sharp.Demo.csproj", "ArtifactsMmo.Sharp.Demo/"]
RUN dotnet restore "ArtifactsMmo.Sharp.Demo/ArtifactsMmo.Sharp.Demo.csproj"
COPY . .
WORKDIR "/src/ArtifactsMmo.Sharp.Demo"
RUN dotnet build "ArtifactsMmo.Sharp.Demo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ArtifactsMmo.Sharp.Demo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtifactsMmo.Sharp.Demo.dll"]
