# BaGet Server Docker Setup

## Acquiring BaGet's latest docker image:

* Execute the command:
```powershell
docker pull loicsharma/baget
```

## Baget Server appsettings.json:

* (Optional) Change the file: **appsettings.json** to meet your needs or leave as is;

```json
{
  "ApiKey": "X7BhV45nYz8TjQZ0WL9PgCsKFd2iHxJR57bd2dsa",
  "PackageDeletionBehavior": "Unlist",
  "AllowPackageOverwrites": false,
  "Database": {
    "Type": "Sqlite",
    "ConnectionString": "Data Source=baget.db"
  },
  "Storage": {
    "Type": "FileSystem",
    "Path": ""
  },
  "Search": {
    "Type": "Database"
  },
  "Mirror": {
    "Enabled": false,
    "PackageSource": "https://api.nuget.org/v3/index.json"
  },
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://+:80"
      },
      "Https": {
        "Url": "https://+:443",
        "Certificate": {
          "Path": "/app/baget-server.pfx",
          "KeyPassword": ""
        }
      }
    }
  },
  "Logging": {
    "Debug": {
      "LogLevel": {
        "Default": "Warning"
      }
    },
    "Console": {
      "LogLevel": {
        "Microsoft.Hosting.Lifetime": "Information",
        "Default": "Warning"
      }
    }
  }
}
```

## Baget Server Configurations:

* (Optional) Change the file: **baget.env** to meet your needs or leave as is;

```txt
ApiKey=X7BhV45nYz8TjQZ0WL9PgCsKFd2iHxJR57bd2dsa
Storage__Type=FileSystem
Storage__Path=/var/baget/packages
Database__Type=Sqlite
Database__ConnectionString=Data Source=/var/baget/baget.db
Search__Type=Database
```

## Create SelfSigned Certificate for HTTPS BaGet

* Open a PowerShell at: **DummySolutions** root folder;
* Navigate to the folder **assets**;
* Generate a private key:
    ```powershell
    openssl genpkey -algorithm RSA -out BagetServerKey.pem
    ```
* Generate a self-signed certificate using the private key:
    ```powershell
    openssl req -new -x509 -key BagetServerKey.pem -out BagetServerCert.pem -days 999 -subj "/CN=localhost"
    ```
* Package the certificate and the key into a single **pfx** File:
    * **Set NO password**;
    * **Set NO passphrase**;
    * Both should be blank/empty;
    ```powershell
    openssl pkcs12 -export -out BagetServer.pfx -inkey BagetServerKey.pem -in BagetServerCert.pem -passout pass:
    ```

* Import the certificate to Window's CertStore at CurrentUser's Root Trusted Certificates
    ```powershell
    Import-PfxCertificate -FilePath "$(pwd)\BagetServer.pfx" -CertStoreLocation "Cert:\CurrentUser\Root"
    ```

## Start Baget Server:
```powershell
docker run -d --restart=unless-stopped --network=docker-network --name baget-server -p 5555:80 -p 5556:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORTS=5556 -e ASPNETCORE_Kestrel__Certificates__Default__KeyStorageFlags=EphemeralKeySet -e ASPNETCORE_Kestrel__Certificates__Default__Password="" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/app/BagetServer.pfx -v app:/https/ --env-file "$(pwd)/baget/baget.env" -v "$(pwd)/baget/baget-data:/var/baget" -v "$(pwd)/baget/appsettings.json:/app/appsettings.json" -v "$(pwd)/BagetServer.pfx:/app/BagetServer.pfx" loicsharma/baget:latest
```

## Setup BaGet as Valid Nuget Source for Visual Studio
* Execute both commands below
```powershell
nuget sources add -Name "BagetServer" -Source https://localhost:5556/v3/index.json -ConfigFile $env:userprofile\AppData\Roaming\NuGet\NuGet.Config
nuget setapikey X7BhV45nYz8TjQZ0WL9PgCsKFd2iHxJR57bd2dsa -Source https://localhost:5556/v3/index.json -ConfigFile $env:userprofile\AppData\Roaming\NuGet\NuGet.Config
```

## Check your baget server running instance:
* Open your browser and navigate to [BagetServer](https://localhost:5556/);
---