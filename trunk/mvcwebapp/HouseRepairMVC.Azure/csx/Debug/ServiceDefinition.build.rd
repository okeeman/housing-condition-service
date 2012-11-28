<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="HouseRepairMVC.Azure" generation="1" functional="0" release="0" Id="065b4dbd-e3a0-4f12-be8f-73425cb49abd" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="HouseRepairMVC.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="HouseRepairMVC:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/LB:HouseRepairMVC:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="HouseRepairMVC:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/MapHouseRepairMVC:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="HouseRepairMVCInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/MapHouseRepairMVCInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:HouseRepairMVC:Endpoint1">
          <toPorts>
            <inPortMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/HouseRepairMVC/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapHouseRepairMVC:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/HouseRepairMVC/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapHouseRepairMVCInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/HouseRepairMVCInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="HouseRepairMVC" generation="1" functional="0" release="0" software="F:\Semester 2\EAD\Mini-project\HouseRepairMVC\HouseRepairMVC.Azure\csx\Debug\roles\HouseRepairMVC" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;HouseRepairMVC&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;HouseRepairMVC&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/HouseRepairMVCInstances" />
            <sCSPolicyFaultDomainMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/HouseRepairMVCFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="HouseRepairMVCFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="HouseRepairMVCInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="02d03ddc-d43c-4ddf-8bb1-ea52991b3eab" ref="Microsoft.RedDog.Contract\ServiceContract\HouseRepairMVC.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="695809d4-ec7c-4986-9547-bf20ea9e07e2" ref="Microsoft.RedDog.Contract\Interface\HouseRepairMVC:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/HouseRepairMVC.Azure/HouseRepairMVC.AzureGroup/HouseRepairMVC:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>