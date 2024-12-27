#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LibraryManagementDemo/LibraryManagementDemo.csproj", "LibraryManagementDemo/"]
COPY ["LibraryManagement/LibraryManagement.csproj", "LibraryManagement/"]
RUN dotnet restore "./LibraryManagementDemo/./LibraryManagementDemo.csproj"
COPY . .
WORKDIR "/src/LibraryManagementDemo"
RUN dotnet build "./LibraryManagementDemo.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LibraryManagementDemo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryManagementDemo.dll"]