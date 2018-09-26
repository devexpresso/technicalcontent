FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY EmployeeManagement.Api/EmployeeManagement.Api.csproj EmployeeManagement.Api/
COPY EmployeeManagement.Model/EmployeeManagement.Model.csproj EmployeeManagement.Model/
COPY EmployeeManagement.Provider/EmployeeManagement.Provider.csproj EmployeeManagement.Provider/
COPY EmployeeManagement.Repository/EmployeeManagement.Repository.csproj EmployeeManagement.Repository/
RUN dotnet restore EmployeeManagement.Api/EmployeeManagement.Api.csproj
COPY . .
WORKDIR /src/EmployeeManagement.Api
RUN dotnet build EmployeeManagement.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EmployeeManagement.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeManagement.Api.dll"]
