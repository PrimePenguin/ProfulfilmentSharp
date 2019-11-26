dotnet restore;
dotnet build -c Release;
dotnet pack --no-build -c Release ProfulfilmentSharp/ProfulfilmentSharp.csproj;

$nupkg = (Get-ChildItem ProfulfilmentSharp/bin/Release/*.nupkg)[0];

# Push the nuget package to AppVeyor's artifact list.
Push-AppveyorArtifact $nupkg.FullName -FileName $nupkg.Name -DeploymentName "ProfulfilmentSharp.nupkg";