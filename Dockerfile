FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS Base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS Build
WORKDIR /app

COPY nuget.config .
COPY *.sln .
COPY Bookworm.Xapi/Bookworm.Xapi.csproj ./Bookworm.Xapi/Bookworm.Xapi.csproj
COPY Bookworm.Xapi.Tests/Bookworm.Xapi.Tests.csproj ./Bookworm.Xapi.Tests/Bookworm.Xapi.Tests.csproj
RUN dotnet restore

COPY . .

RUN dotnet build -c Release

LABEL test=true
RUN dotnet test --results-directory /test-results --logger "trx;LogFileName=test-results.xml"


LABEL publish=true
ARG Version
ARG Version=${Version:-1.0.0}
RUN dotnet publish ./Bookworm.Xapi/Bookworm.Xapi.csproj -c Release -o ./out -p:PublishReadyToRun=true -p:AssemblyVersion=$Version --runtime linux-musl-x64

FROM Base
COPY --from=Build /app/out .
ENTRYPOINT [ "dotnet", "Bookworm.Xapi.dll" ]