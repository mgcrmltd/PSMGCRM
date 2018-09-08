Build this project. Copy the contents of the bin folder to a location.
For the sake of example we will copy to D:\TOOLS\POWERSHELL\PSMGCRM

Below are sample scripts to register the module and execute the steps.

##START SCRIPT TO REGISTER MODULE##
#Change path as needed
cd "D:\TOOLS\POWERSHELL\PSMGCRM"
Import-Module .\PSMGCRM.dll
##END SCRIPT TO REGISTER MODULE##

##START SCRIPT TO RUN COMMANDS##
#Change connection and CRM Plugin Assembly Name as needed
$connString = "AuthType=AD;Url=http://localhost:5555/ORG1"
$dllName = "MyProject.Plugins"
Remove-PluginSteps -ConnectionString $connString -DllName $dllName
Remove-Plugin -ConnectionString $connString -DllName $dllName
##END SCRIPT TO RUN COMMANDS##