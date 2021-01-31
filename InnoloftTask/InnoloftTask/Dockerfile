FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY published/InnoloftTask.dll ./
ENTRYPOINT ["dotnet", "InnoloftTask.dll"]