FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DijitalErpAPI/DijitalErpAPI.csproj", "DijitalErpAPI/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Presentation/Presentation.csproj", "Presentation/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "DijitalErpAPI/DijitalErpAPI.csproj"
COPY . .
WORKDIR "/src/DijitalErpAPI"
RUN dotnet build "DijitalErpAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DijitalErpAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DijitalErpAPI.dll"]