FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/myproj.Web.Host/myproj.Web.Host.csproj", "src/myproj.Web.Host/"]
COPY ["src/myproj.Web.Core/myproj.Web.Core.csproj", "src/myproj.Web.Core/"]
COPY ["src/myproj.Application/myproj.Application.csproj", "src/myproj.Application/"]
COPY ["src/myproj.Core/myproj.Core.csproj", "src/myproj.Core/"]
COPY ["src/myproj.EntityFrameworkCore/myproj.EntityFrameworkCore.csproj", "src/myproj.EntityFrameworkCore/"]
WORKDIR "/src/src/myproj.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/myproj.Web.Host", "src/myproj.Web.Host"]
COPY ["src/myproj.Web.Core", "src/myproj.Web.Core"]
COPY ["src/myproj.Application", "src/myproj.Application"]
COPY ["src/myproj.Core", "src/myproj.Core"]
COPY ["src/myproj.EntityFrameworkCore", "src/myproj.EntityFrameworkCore"]
WORKDIR "/src/src/myproj.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "myproj.Web.Host.dll"]
