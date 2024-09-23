param (
    [Parameter(Mandatory=$true, Position=0)]
    [string]$Operation = $(throw "Operation parameter is required!"),
	[Parameter(Mandatory=$false, Position=1)]
    [string]$Name = "",
	[Parameter(Mandatory=$false)]
    [string]$Env = "Localhost",
	[Parameter(Mandatory=$false)]
	[switch]$DebugMode
)

$customArgs = "--ef-cli"

try
{
	if ($DebugMode) {
		$customArgs = -join($customArgs, "-debug")
		Write-Host "# " -ForegroundColor White -NoNewline
		Write-Host "DEBUG MODE ON" -ForegroundColor Blue -NoNewline
		Write-Host " #" -ForegroundColor White
	}

	if ($Env.ToLower() -in @("development", "dev")) {
		$Env = "Development"
	} elseif ($Env.ToLower() -in @("staging", "stg")) {
		$Env = "Staging"
	} elseif ($Env.ToLower() -in @("production", "prd", "prod")) {
		$Env = "Production"
	}
	$customArgs = -join($customArgs, "-", $Env)
	Write-Host "# " -ForegroundColor White -NoNewline
	Write-Host "Migrating" $Env -ForegroundColor Blue -NoNewline
	Write-Host " #" -ForegroundColor White

    if ($Operation.ToLower() -eq "add") {
		if ([bool][string]::IsNullOrWhitespace($Name)) { 
			Write-Host "Add Operation demands Name parameter!" -ForegroundColor Red
			$(throw "Error") 
		}
		Write-Host "# " -ForegroundColor White -NoNewline
		Write-Host "Creating migration" $Name -ForegroundColor Blue -NoNewline
		Write-Host " #" -ForegroundColor White
		dotnet ef migrations add $Name -p ./Ds.Full.MySql/ -s ./Ds.Full.Grpc/ --context DsFullDatabaseContext --verbose -- $customArgs
	} elseif ($Operation.ToLower() -eq "remove") {
		Write-Host "# " -ForegroundColor White -NoNewline
		Write-Host "Removing migration" $Name -ForegroundColor Blue -NoNewline
		Write-Host " #" -ForegroundColor White
		dotnet ef migrations remove -p ./Ds.Full.MySql/ -s ./Ds.Full.Grpc/ --context DsFullDatabaseContext --verbose -- $customArgs
    } else {
		if ($Operation.ToLower() -eq "update") {
			if ([bool][string]::IsNullOrWhitespace($Name)) { 
				Write-Host "# " -ForegroundColor White -NoNewline
				Write-Host "Committing migration" $Name -ForegroundColor Blue -NoNewline
				Write-Host " #" -ForegroundColor White
				dotnet ef database update -p ./Ds.Full.MySql/ -s ./Ds.Full.Grpc/ --context DsFullDatabaseContext --verbose -- $customArgs
			} else {
				Write-Host "# " -ForegroundColor White -NoNewline
				Write-Host "Rollingback migration" $Name -ForegroundColor Blue -NoNewline
				Write-Host " #" -ForegroundColor White
				dotnet ef database update $Name -p ./Ds.Full.MySql/ -s ./Ds.Full.Grpc/ --context DsFullDatabaseContext --verbose -- $customArgs
			}
		}
		else
		{ Write-Host "Invalid Operation valid ones are: 'Add', 'Update' or 'Remove'" -ForegroundColor red }
    }
}
catch { Write-Host "Migration aborted due to an error" -ForegroundColor red }