# Publishing Nugets to BaGet Server

## Building

* Set Build Mode to Release in Visual Studio;
* Build it;

## Publishing

* Open a PowerShell at: **DummySolutions** root folder;
* Navigate to the folder **Ds.Base**;
* Execute the publish script below:
```powershell
.\baget-local-push.ps1 VersionNumber
```
* Replace **VersionNumber** with the proper version;
