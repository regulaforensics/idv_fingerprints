FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

#Copy all the source code into the Build Container
COPY src .
# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "fingerprint_service.csproj"


# Run dotnet publish in the Build Container
# Generates output available in /app/build
# Since the current directory is /app
WORKDIR /src
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish



FROM base AS runtime

WORKDIR /app

# Copy the dlls generated under /app/out of the previous step
# With alias build onto the current directory
# Which is /app in runtime
COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "fingerprint_service.dll" ]