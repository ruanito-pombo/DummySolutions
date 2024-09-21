param(
	[string]$version = $( throw "Version is required" ),
	[string]$buildType
)

$apiKey = "X7BhV45nYz8TjQZ0WL9PgCsKFd2iHxJR57bd2dsa"
$source = "https://localhost:5556/v3/index.json"
$build = "Release"

if ($buildType.ToUpper().Trim() -eq "DEBUG") { 
	$build = "Debug"
}

# DomainNuget
$domain = "Ds.Base.Domain"
$domainPath = ".\Ds.Base.Domain\bin\$build"
$domainNuget = "$domainPath\$domain.$version.nupkg"
Write-Host "Checking $domain..."
if (Test-Path -Path "$domainNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$domainNuget" --skip-duplicate
	Write-Host "$domainNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $domainNuget found" -ForegroundColor red }

# ProtoNuget
$proto = "Ds.Base.Proto"
$protoPath = ".\Ds.Base.Proto\bin\$build"
$protoNuget = "$protoPath\$proto.$version.nupkg"
Write-Host "Checking $proto..."
if (Test-Path -Path "$protoNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$protoNuget" --skip-duplicate
	Write-Host "$protoNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $protoNuget found" -ForegroundColor red }

# InjectionNuget
$injection = "Ds.Base.Injection"
$injectionPath = ".\Ds.Base.Injection\bin\$build"
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
$entityFrameworkPath = ".\Ds.Base.EntityFramework\bin\$build"
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
$consolePath = ".\Ds.Base.Console\bin\$build"
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
$grpcPath = ".\Ds.Base.Grpc\bin\$build"
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
$webApiPath = ".\Ds.Base.webApi\bin\$build"
$webApiNuget = "$webApiPath\$webApi.$version.nupkg"
Write-Host "Checking $webApi..."
if (Test-Path -Path "$webApiNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$webApiNuget" --skip-duplicate
	Write-Host "$webApiNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $webApiNuget found" -ForegroundColor red }