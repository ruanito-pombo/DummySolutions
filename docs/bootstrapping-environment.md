# Bootstrapping your environment

## Prerequisites

* You must have PowerShell with Admin Privileges installed in your computer;
* You must have **Visual Studio 2022** or newest installed in your computer:
    * Download from: [Microsoft Visual Studio Community Edition Downloads](https://visualstudio.microsoft.com/en-us/vs/community/);
* You must have **nuget** client tools configured in system's **PATH** variables:
    * Download from: [Nuget.exe client Downloads](https://www.nuget.org/downloads);
    * Copy the file to any folder in system's **PATH** variable or add the folder of your choice in system's **PATH** variable;    
* You must have **dotnet-ef** client tools configured in system's **PATH** variables:
    * Execute the command: 
        ```powershell 
        dotnet tool install --global dotnet-ef
        ```
* You must have **openssl** installed and configured inside a system's **PATH** folder:
    * Execute the command:
        ```powershell
        winget install ShiningLight.OpenSSL.Light
        ```
* You must have **Docker** installed in your computer and the privileges needed to use it as well
* Default password to **MySql Server** local instance is: **```!MySqlRoot1234```**

## Create a Docker network
*
    ```powershell
    docker network create docker-network
    ```

## Follow this docs in order
* [BaGet Server Docker Setup (Windows)](/baget-setup.md)
* [MySql Server Docker Setup (Windows)](/mysql-setup.md)

---