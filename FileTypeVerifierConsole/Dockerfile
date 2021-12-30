#step-1 
#creates the intermediate image from base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#step-2 
#copies the code into working source directory.
#restores then nugest packages and builds the code
#and publishes code into the publish directory
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FileTypeVerifierApi/FileTypeVerifierApi.csproj", "FileTypeVerifierApi/"]
COPY ["FileTypeVerifierLib/FileTypeVerifierLib.csproj", "FileTypeVerifierLib/"]
RUN dotnet restore "FileTypeVerifierApi/FileTypeVerifierApi.csproj"
COPY . .
WORKDIR "/src/FileTypeVerifierApi"
RUN dotnet build "FileTypeVerifierApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileTypeVerifierApi.csproj" -c Release -o /app/publish

#step-3
#copies the publish directory of step-2 into the final stage directory
#which creates the final production ready image which run once container is started running
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileTypeVerifierApi.dll"]
#CMD dotnet FileTypeVerifierApi.dll --urls "http://*:$PORT"