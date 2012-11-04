<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="HousingConditionWebApp.Azure" generation="1" functional="0" release="0" Id="2f9aa162-4c7e-44cb-b724-6612aff14730" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="HousingConditionWebApp.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="HousingConditionWebApp:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/LB:HousingConditionWebApp:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="HousingConditionWebApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/MapHousingConditionWebApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="HousingConditionWebAppInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/MapHousingConditionWebAppInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:HousingConditionWebApp:Endpoint1">
          <toPorts>
            <inPortMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/HousingConditionWebApp/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapHousingConditionWebApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/HousingConditionWebApp/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapHousingConditionWebAppInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/HousingConditionWebAppInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="HousingConditionWebApp" generation="1" functional="0" release="0" software="F:\Semester 2\EAD\Mini-project\HousingConditionWebApp\HousingConditionWebApp.Azure\csx\Debug\roles\HousingConditionWebApp" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;HousingConditionWebApp&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;HousingConditionWebApp&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/HousingConditionWebAppInstances" />
            <sCSPolicyFaultDomainMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/HousingConditionWebAppFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="HousingConditionWebAppFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="HousingConditionWebAppInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="0c760191-65d5-42e4-bb29-15ae15272e34" ref="Microsoft.RedDog.Contract\ServiceContract\HousingConditionWebApp.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="10bdc99e-a340-42e9-8728-92bfdf6762fb" ref="Microsoft.RedDog.Contract\Interface\HousingConditionWebApp:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/HousingConditionWebApp.Azure/HousingConditionWebApp.AzureGroup/HousingConditionWebApp:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>