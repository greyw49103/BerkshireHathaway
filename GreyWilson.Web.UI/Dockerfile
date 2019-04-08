FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["GreyWilson.Web.UI/GreyWilson.Web.UI.csproj", "GreyWilson.Web.UI/"]
RUN dotnet restore "GreyWilson.Web.UI/GreyWilson.Web.UI.csproj"
COPY . .
WORKDIR "/src/GreyWilson.Web.UI"
RUN dotnet build "GreyWilson.Web.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GreyWilson.Web.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GreyWilson.Web.UI.dll"]