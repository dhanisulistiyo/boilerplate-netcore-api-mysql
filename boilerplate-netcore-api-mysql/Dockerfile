#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 8080/tcp
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["boilerplate-netcore-api-mysql/boilerplate-netcore-api-mysql.csproj", "boilerplate-netcore-api-mysql/"]
RUN dotnet restore "boilerplate-netcore-api-mysql/boilerplate-netcore-api-mysql.csproj"
COPY . .
WORKDIR "/src/boilerplate-netcore-api-mysql"
RUN dotnet build "boilerplate-netcore-api-mysql.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "boilerplate-netcore-api-mysql.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "boilerplate-netcore-api-mysql.dll"]