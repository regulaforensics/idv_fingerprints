FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["fingerprint_service/fingerprint_service.csproj", "fingerprint_service/"]
RUN dotnet restore "fingerprint_service/fingerprint_service.csproj"
COPY . .
WORKDIR "/src/fingerprint_service"
RUN dotnet build "fingerprint_service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fingerprint_service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fingerprint_service.dll"]
