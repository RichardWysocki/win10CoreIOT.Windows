FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Core.WebManagement/Core.WebManagement.csproj", "Core.WebManagement/"]
RUN dotnet restore "Core.WebManagement/Core.WebManagement.csproj"
COPY . .
WORKDIR "/src/Core.WebManagement"
RUN dotnet build "Core.WebManagement.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Core.WebManagement.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Core.WebManagement.dll"]