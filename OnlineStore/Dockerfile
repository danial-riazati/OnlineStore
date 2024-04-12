FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OnlineStore/OnlineStore.csproj", "OnlineStore/"]
COPY ["OnlineStore.Application/OnlineStore.Application.csproj", "OnlineStore.Application/"]
COPY ["OnlineStore.Domain/OnlineStore.Domain.csproj", "OnlineStore.Domain/"]
COPY ["OnlineStore.Infrastructure/OnlineStore.Infrastructure.csproj", "OnlineStore.Infrastructure/"]
RUN dotnet restore "OnlineStore/OnlineStore.csproj"
COPY . .
WORKDIR "/src/OnlineStore"
RUN dotnet build "OnlineStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineStore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineStore.dll"]
