param(
	[string]$version = $( throw "Version is required" )
)

$apiKey = "X7BhV45nYz8TjQZ0WL9PgCsKFd2iHxJR57bd2dsa"
$source = "http://localhost:5555/v3/index.json"

# DomainNuget
$domain = "Ds.Base.Domain"
$domainPath = ".\Ds.Base.Domain\bin\Release"
$domainNuget = "$domainPath\$domain.$version.nupkg"
Write-Host "Checking $domain..."
if (Test-Path -Path "$domainNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$domainNuget" --skip-duplicate
	Write-Host "$domainNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $domainNuget found" -ForegroundColor red }

# InjectionNuget
$injection = "Ds.Base.Injection"
$injectionPath = ".\Ds.Base.Injection\bin\Release"
$injectionNuget = "$injectionPath\$injection.$version.nupkg"
Write-Host "Checking $injection..."
if (Test-Path -Path "$injectionNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$injectionNuget" --skip-duplicate
	Write-Host "$injectionNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $injectionNuget found" -ForegroundColor red }

# EntityFrameworkNuget
$entityFramework = "Ds.Base.EntityFramework"
$entityFrameworkPath = ".\Ds.Base.EntityFramework\bin\Release"
$entityFrameworkNuget = "$entityFrameworkPath\$entityFramework.$version.nupkg"
Write-Host "Checking $entityFramework..."
if (Test-Path -Path "$entityFrameworkNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$entityFrameworkNuget" --skip-duplicate
	Write-Host "$entityFrameworkNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $entityFrameworkNuget found" -ForegroundColor red }

# ConsoleNuget
$console = "Ds.Base.Console"
$consolePath = ".\Ds.Base.Console\bin\Release"
$consoleNuget = "$consolePath\$console.$version.nupkg"
Write-Host "Checking $console..."
if (Test-Path -Path "$consoleNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$consoleNuget" --skip-duplicate
	Write-Host "$consoleNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $consoleNuget found" -ForegroundColor red }

# GrpcNuget
$grpc = "Ds.Base.Grpc"
$grpcPath = ".\Ds.Base.Grpc\bin\Release"
$grpcNuget = "$grpcPath\$grpc.$version.nupkg"
Write-Host "Checking $grpc..."
if (Test-Path -Path "$grpcNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$grpcNuget" --skip-duplicate
	Write-Host "$grpcNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $grpcNuget found" -ForegroundColor red }

# webApiNuget
$webApi = "Ds.Base.webApi"
$webApiPath = ".\Ds.Base.webApi\bin\Release"
$webApiNuget = "$webApiPath\$webApi.$version.nupkg"
Write-Host "Checking $webApi..."
if (Test-Path -Path "$webApiNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$webApiNuget" --skip-duplicate
	Write-Host "$webApiNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $webApiNuget found" -ForegroundColor red }