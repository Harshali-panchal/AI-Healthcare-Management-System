FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["AIHealthcareManagement.csproj", "./"]
RUN dotnet restore "./AIHealthcareManagement.csproj"

COPY . .
RUN dotnet publish "AIHealthcareManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:$PORT

EXPOSE 8080

ENTRYPOINT ["dotnet", "AIHealthcareManagement.dll"]