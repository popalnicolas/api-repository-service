FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PopApp.dk.Api/PopApp.dk.Api.csproj", "PopApp.dk.Api/"]
RUN dotnet restore "PopApp.dk.Api/PopApp.dk.Api.csproj"
COPY . .
WORKDIR "/src/PopApp.dk.Api"
RUN dotnet build "PopApp.dk.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PopApp.dk.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PopApp.dk.Api.dll"]
