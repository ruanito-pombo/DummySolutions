![DummySolutions Logo](./assets/imgs/dummy-solutions-logo.png)

# DummySolutions: The "Guinea Pig" place to play with SharpScaffolder

This Solution package consists basically into a Base project that makes up to whatever private nuget package dependencies an enterprise solution may need.
It also have two more solutions: One simple solution hosted as single project with its own InMemory database, Entity Relationship Diagram and console application.
And other is a multi project solution that have lot's of stuff you may find in any enterprise class solution. The sole purpose of these solutions are to give you a consistent ambient to practice, play with, learn how to take the best advantage from SharpScaffolder. Feel free to mess around these solutions using SharpScaffolder so you may use it in your real world live solutions as well.

# Disclaimer
I could never stress this enough... READ THE DAMN DOCS... I take absolutely NO RESPONSABILITY at all if you mess this up, just because you didn't paid proper attention to your job

## [Ds.Base (Nuget) Solution](./src/Ds.Base/readme.md)
This is the base project it builds up into a nuget package that you can publish anywhere you want (in this version BaGet is the place of choice) and import the Nugets into both projects below to play with inheritance and other extensible properties/functions that SharpScaffolder can scaffold for you.

## [Ds.Simple (Single Project) Solution](./src/Ds.Simple/readme.md)
If you want to test sharpscaffolder against less complex solutions, start here.

## [Ds.Full (Multi Project) Solution](./src/Ds.Full/readme.md)
If you want to test sharpscaffolder against **nightly built** real world enterprise solutions, start here.

---