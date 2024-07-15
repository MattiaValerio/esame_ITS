FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY ["Client/Client.csproj", "Client/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore Client/Client.csproj
COPY . .
WORKDIR "/app/Client"
RUN dotnet build Client.csproj -c Release -o /app/build 
 
FROM build AS publish
RUN dotnet publish Client.csproj -c Release -o /app/publish /p:UseAppHost=false
 
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .