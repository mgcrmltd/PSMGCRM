<p># PSMGCRM</p>
<p>Dynamics 365 PowerShell Commandlets</p>

<p>Build this project. Copy the contents of the bin folder to a location.</p>
<p>For the sake of example we will copy to D:\TOOLS\POWERSHELL\PSMGCRM</p>

<p>Below are samples script to register the module and execute the steps.</p>

<p>##START SCRIPT TO REGISTER MODULE##</p>
<p>#Change path as needed</p>
<p>cd "D:\TOOLS\POWERSHELL\PSMGCRM"</p>
<p>Import-Module .\PSMGCRM.dll</p>
<p>##END SCRIPT TO REGISTER MODULE##</p>

<p>##START SCRIPT TO RUN COMMANDS##</p>
<p>#Change connection and CRM Plugin Assembly Name as needed</p>
<p>$connString = "AuthType=AD;Url=http://localhost:5555/ORG1"</p>
<p>$dllName = "MyProject.Plugins"</p>
<p>Remove-PluginSteps -ConnectionString $connString -DllName $dllName</p>
<p>Remove-Plugin -ConnectionString $connString -DllName $dllName</p>
<p>##END SCRIPT TO RUN COMMANDS##</p>