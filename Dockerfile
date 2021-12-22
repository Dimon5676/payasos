FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Payasos.sln ./
COPY Payasos.Core/Payasos.Core.csproj Payasos.Core/
COPY Payasos.Infrastructure/Payasos.Infrastructure.csproj Payasos.Infrastructure/
COPY Payasos.Web/Payasos.Web.csproj Payasos.Web/

RUN dotnet restore
COPY . .
WORKDIR /src/Payasos.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 7250
ENTRYPOINT ["dotnet", "Payasos.Web.dll"]