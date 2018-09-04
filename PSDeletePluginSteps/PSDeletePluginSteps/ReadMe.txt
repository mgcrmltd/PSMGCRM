Build this project. Copy the contents of the bin folder to a location.
For the sake of example we will copy to D:\TOOLS\POWERSHELL\PSMGCRM

Below are two sample script to register the module and execute the steps. It is necessary to register the module first

##START SCRIPT TO REGISTER MODULE##
cd "D:\TOOLS\POWERSHELL\PSMGCRM"
Import-Module .\PSMGCRM.dll
##END SCRIPT TO REGISTER MODULE##

##START SCRIPT TO RUN COMMANDS##
$connString = "AuthType=AD;Url=http://localhost:5555/ORG1"
$dllName = "PeabodyDynamics.Plugins"
Remove-PluginSteps -ConnectionString $connString -DllName $dllName
Remove-Plugin -ConnectionString $connString -DllName $dllName
##END SCRIPT TO RUN COMMANDS##