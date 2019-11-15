FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["IpInfo.Worker/IpInfo.Worker.csproj", "IpInfo.Worker/"]
RUN dotnet restore "IpInfo.Worker/IpInfo.Worker.csproj"
COPY . .
WORKDIR "/src/IpInfo.Worker"
RUN dotnet build "IpInfo.Worker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IpInfo.Worker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IpInfo.Worker.dll"]