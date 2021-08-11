#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TestBackEndApi.Api/TestBackEndApi.Api.csproj", "TestBackEndApi.Api/"]
COPY ["TextBackEndApi.Infrastructure.Ioc/TextBackEndApi.Infrastructure.Ioc.csproj", "TextBackEndApi.Infrastructure.Ioc/"]
COPY ["TestBackEndApi.Infrastructure.Services/TestBackEndApi.Infrastructure.Services.csproj", "TestBackEndApi.Infrastructure.Services/"]
COPY ["TestBackEndApi.Domain/TestBackEndApi.Domain.csproj", "TestBackEndApi.Domain/"]
COPY ["TestBackEndApi.Infrastructure.Data/TestBackEndApi.Infrastructure.Data.csproj", "TestBackEndApi.Infrastructure.Data/"]
COPY ["TestBackEndApi.Infrastructure.CrossCutting.Configuration/TestBackEndApi.Infrastructure.CrossCutting.Configuration.csproj", "TestBackEndApi.Infrastructure.CrossCutting.Configuration/"]
RUN dotnet restore "TestBackEndApi.Api/TestBackEndApi.Api.csproj"
COPY . .
WORKDIR "/src/TestBackEndApi.Api"
RUN dotnet build "TestBackEndApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestBackEndApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestBackEndApi.Api.dll"]
