# Usa la imagen base de .NET para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY *.csproj .
RUN dotnet restore

# Copia el resto de los archivos del proyecto y construye la aplicación
COPY . .
RUN dotnet publish -c Release -o out

# Usa una imagen base más ligera para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Abre el Dockerfile original
RUN apt-get update && apt-get install -y iputils-ping

# Expone el puerto en el contenedor
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "SmartFlow-Platform.dll"]
