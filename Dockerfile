FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["bulk-sequence-file-renamer.csproj", "./"]
RUN dotnet restore "bulk-sequence-file-renamer.csproj"
COPY . .
WORKDIR "/src/bulk-sequence-file-renamer"
RUN dotnet build "bulk-sequence-file-renamer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bulk-sequence-file-renamer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bulk-sequence-file-renamer.dll"]
