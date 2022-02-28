#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DataAccess.Example.WebApi/DataAccess.Example.WebApi.csproj", "DataAccess.Example.WebApi/"]
COPY ["DataAccess.Example.EntityFramework/DataAccess.Example.EntityFramework.csproj", "DataAccess.Example.EntityFramework/"]
COPY ["DataAccess.Example.Core/DataAccess.Example.Core.csproj", "DataAccess.Example.Core/"]
RUN dotnet restore "DataAccess.Example.WebApi/DataAccess.Example.WebApi.csproj"
COPY . .
WORKDIR "/src/DataAccess.Example.WebApi"
RUN dotnet build "DataAccess.Example.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataAccess.Example.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataAccess.Example.WebApi.dll"]
