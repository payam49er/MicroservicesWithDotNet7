FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AzureContainer/AzureContainer.csproj", "AzureContainer/"]
RUN dotnet restore "AzureContainer/AzureContainer.csproj"
COPY . .
WORKDIR "/src/AzureContainer"
RUN dotnet build "AzureContainer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzureContainer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureContainer.dll"]
