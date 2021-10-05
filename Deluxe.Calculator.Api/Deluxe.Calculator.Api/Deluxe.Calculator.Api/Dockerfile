#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Deluxe.Calculator.Api/Deluxe.Calculator.Api.csproj", "Deluxe.Calculator.Api/"]
RUN dotnet restore "Deluxe.Calculator.Api/Deluxe.Calculator.Api.csproj"
COPY . .
WORKDIR "/src/Deluxe.Calculator.Api"
RUN dotnet build "Deluxe.Calculator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deluxe.Calculator.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deluxe.Calculator.Api.dll"]