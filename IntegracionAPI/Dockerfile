FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IntegracionAPI/IntegracionAPI.csproj", "IntegracionAPI/"]
RUN dotnet restore "IntegracionAPI/IntegracionAPI.csproj"
COPY . .
WORKDIR "/src/IntegracionAPI"
RUN dotnet build "IntegracionAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegracionAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegracionAPI.dll"]
