FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Neazza.OpenAI.Transalot/Neazza.OpenAI.Transalot.csproj", "Neazza.OpenAI.Transalot/"]
RUN dotnet restore "Neazza.OpenAI.Transalot/Neazza.OpenAI.Transalot.csproj"
COPY . .
WORKDIR "/src/Neazza.OpenAI.Transalot"
RUN dotnet build "Neazza.OpenAI.Transalot.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Neazza.OpenAI.Transalot.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Neazza.OpenAI.Transalot.dll"]
