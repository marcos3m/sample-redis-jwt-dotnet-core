# sample-redis-jwt-dotnet-core
This project is a JSON web token authenticator API.

**Content** 

  - [Install](#install)
  - [Test](#test)
  - [Basic Usage](#basic-usage)
  - [Paths](#paths)
  - [Examples](#examples)

## Install

Prerequisities:

```bash
https://www.microsoft.com/net/core#windowsvs2017 (Windows)
https://www.microsoft.com/net/core#linuxredhat (Linux)
https://www.microsoft.com/net/core#macos (MacOS)
https://www.microsoft.com/net/core#dockercmd (Docker)

https://github.com/MicrosoftArchive/redis/releases (Redis)
```

Run Linux / MacOS:

```bash
dotnet restore 
dotnet build 
dotnet [assembly]
```

Run Windows VS Code:

```bash
dotnet restore 
dotnet build 
dotnet run
```

Run Windows Visual Studio:

```bash
dotnet restore + build (CTRL + B)
dotnet run (debug - F5)
dotnet run (release - CTRL + F5)
```

## Test

This API uses MSTest as a test framework. It can be tested by running the commands below:

```bash
dotnet test (bash / cmd)
run tests (Visual Studio - 2015+)
dotnet test (Visual Studio Code Integrated Terminal)
```

## Basic Usage

This API works through the url's shown below:

```bash
http://localhost:<random_port>/ (API documentation)
http://localhost:<random_port>/api/version/<resource> (API)
```
    
## Paths

Available entities:

Resource | Entity | HTTP Verbs | Query Strings
--------- | ----------- | --------------- | ---------------------
/token | Token | GET POST
 
## Examples:

```
http://localhost:<random_port>/api/v1/token
http://localhost:<random_port>/api/v1/token/{key}
```
