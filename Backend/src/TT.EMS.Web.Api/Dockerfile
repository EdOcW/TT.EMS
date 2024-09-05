FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5054

ENV ASPNETCORE_URLS=http://+:5054

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Backend/src/TT.EMS.Web.Api/TT.EMS.Web.Api.csproj", "Backend/src/TT.EMS.Web.Api/"]
RUN dotnet restore "Backend/src/TT.EMS.Web.Api/TT.EMS.Web.Api.csproj"
COPY . .
WORKDIR "/src/Backend/src/TT.EMS.Web.Api"
RUN dotnet build "TT.EMS.Web.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TT.EMS.Web.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TT.EMS.Web.Api.dll"]
