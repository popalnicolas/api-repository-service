FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["POPAPP.DK.API/POPAPP.DK.API.csproj", "POPAPP.DK.API/"]
RUN dotnet restore "POPAPP.DK.API/POPAPP.DK.API.csproj"
COPY . .
WORKDIR "/src/POPAPP.DK.API"
RUN dotnet build "POPAPP.DK.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POPAPP.DK.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POPAPP.DK.API.dll"]
