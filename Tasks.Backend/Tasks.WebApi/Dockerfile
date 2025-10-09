FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Tasks.WebApi/Tasks.WebApi.csproj Tasks.WebApi/
COPY Tasks.Application/Tasks.Application.csproj Tasks.Application/
COPY Tasks.Domain/Tasks.Domain.csproj Tasks.Domain/
COPY Tasks.Security/Tasks.Security.csproj Tasks.Security/
COPY Tasks.Persistense/Tasks.Persistense.csproj Tasks.Persistense/
RUN dotnet restore Tasks.WebApi/Tasks.WebApi.csproj

COPY . .
RUN dotnet publish Tasks.WebApi/Tasks.WebApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5000

ENTRYPOINT ["dotnet", "Tasks.WebApi.dll"]