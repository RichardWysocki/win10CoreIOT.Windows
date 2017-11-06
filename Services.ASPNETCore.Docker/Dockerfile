FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 1433
EXPOSE 5000
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Services.ASPNETCore.Docker.dll"]
