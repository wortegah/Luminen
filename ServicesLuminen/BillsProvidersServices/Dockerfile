## Build Stage
## Build Stage
#FROM microsoft/aspnetcore-build as build-env
#WORKDIR /source
#COPY . .
##RUN dotnet restore
##RUN dotnet publish -o /publish --configuration Release
#
## Publish Stage
#FROM microsoft/aspnetcore
#WORKDIR /app
##COPY --from=build-env /publish .
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
#COPY *.sln ./
#COPY productServices/productServices.csproj productServices/
#RUN dotnet restore
COPY . .
#WORKDIR /src/productServices
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BillsProvidersServices.dll"]
