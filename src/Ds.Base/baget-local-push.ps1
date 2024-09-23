param(
    [Parameter(Mandatory=$true, Position=0)]
	[string]$Version = $( throw "Version parameter is required" ),
	[Parameter(Mandatory=$false)]
	[switch]$DebugMode
)

$apiKey = "X7BhV45nYz8TjQZ0WL9PgCsKFd2iHxJR57bd2dsa"
$source = "https://localhost:5556/v3/index.json"
$vsConfiguration = "Release"

if ($DebugMode) { 
	$vsConfiguration = "Debug"
}

# DomainNuget
$domain = "Ds.Base.Domain"
$domainPath = ".\"+$domain+"\bin\$vsConfiguration"
$domainNuget = "$domainPath\$domain.$Version.nupkg"
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
$protoPath = ".\"+$proto+"\bin\$vsConfiguration"
$protoNuget = "$protoPath\$proto.$Version.nupkg"
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
$injectionPath = ".\"+$injection+"\bin\$vsConfiguration"
$injectionNuget = "$injectionPath\$injection.$Version.nupkg"
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
$entityFrameworkPath = ".\"+$entityFramework+"\bin\$vsConfiguration"
$entityFrameworkNuget = "$entityFrameworkPath\$entityFramework.$Version.nupkg"
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
$consolePath = ".\"+$console+"\bin\$vsConfiguration"
$consoleNuget = "$consolePath\$console.$Version.nupkg"
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
$grpcPath = ".\"+$grpc+"\bin\$vsConfiguration"
$grpcNuget = "$grpcPath\$grpc.$Version.nupkg"
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
$webApiPath = ".\"+$webApi+"\bin\$vsConfiguration"
$webApiNuget = "$webApiPath\$webApi.$Version.nupkg"
Write-Host "Checking $webApi..."
if (Test-Path -Path "$webApiNuget")
{
	dotnet nuget push -s $source -k $apiKey  "$webApiNuget" --skip-duplicate
	Write-Host "$webApiNuget was successfully pushed" -ForegroundColor green
} 
else 
{ Write-Host "No $webApiNuget found" -ForegroundColor red }