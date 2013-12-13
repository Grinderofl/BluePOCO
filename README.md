# BluePOCO

Generate POCOs from Blueprint syntax

# Usage:

Get the APITransformer package from https://www.nuget.org/packages/BlueprintApiTransformer/ (or clone this project and compile your own!)

Add the transformer file to your project, edit as appropriate, use "Debug T4 Template" to generate (for some reason, standard running seems to yield a newtonsoft JSON error - I haven't gotten around to figuring out why, it doesn't happen in debug) - and enjoy your newly usable POCOs!


This project is created to complement a RestSharper extension to provide domain oriented design for fetching restul data.

Github: https://github.com/Grinderofl/Restcoration
NuGet: https://www.nuget.org/packages/Restcoration/

Issues:
T4 template generator loves locking assemblies, which means that after generating the POCOs, the files used by it remain locked and copying build files will fail. I've tried getting around it, but it's a whole lot of hustle which is just not worth it. So, I've gone for brute force solution which works quite well. Simply add this to your pre-build script:

`taskkill /f /fi "pid gt 0" /im T4VsHostProcess.exe`

This will kill the T4 transformer and release the assemblies.

# Credits

antiufo / Xamasoft for JSON C# Class Generator

http://jsonclassgenerator.codeplex.com/
http://www.xamasoft.com/json-class-generator/
