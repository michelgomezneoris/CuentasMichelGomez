FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR cuentasmichelgomez

EXPOSE 80
EXPOSE 5024

#COPY PROJECT FILES
COPY ./*.csproj ./
RUN dotnet restore

#COPY EVERYTHING ELSE
COPY . .
RUN dotnet publish -c Release -o production

#Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /cuentasmichelgomez
COPY --from=build /cuentasmichelgomez/production .
ENTRYPOINT ["dotnet", "CuentasMichelGomez.dll"]