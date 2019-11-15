FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["IpInfo/IpInfo.csproj", "IpInfo/"]
RUN dotnet restore "IpInfo/IpInfo.csproj"
COPY . .
WORKDIR "/src/IpInfo"
RUN dotnet build "IpInfo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IpInfo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IpInfo.dll"]