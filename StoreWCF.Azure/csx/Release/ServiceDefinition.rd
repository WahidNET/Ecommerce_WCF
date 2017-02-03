<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="StoreWCF.Azure" generation="1" functional="0" release="0" Id="366d8502-95cf-45a7-974e-ec7a8b3742c2" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="StoreWCF.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="StoreWCF:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/LB:StoreWCF:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="StoreWCF:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/MapStoreWCF:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="StoreWCFInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/MapStoreWCFInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:StoreWCF:Endpoint1">
          <toPorts>
            <inPortMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/StoreWCF/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapStoreWCF:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/StoreWCF/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapStoreWCFInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/StoreWCFInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="StoreWCF" generation="1" functional="0" release="0" software="C:\Users\Afghan\documents\visual studio 2013\Projects\StoreDal\StoreWCF.Azure\csx\Release\roles\StoreWCF" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;StoreWCF&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;StoreWCF&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/StoreWCFInstances" />
            <sCSPolicyUpdateDomainMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/StoreWCFUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/StoreWCFFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="StoreWCFUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="StoreWCFFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="StoreWCFInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="a52f48a3-715a-48cc-aa7f-beb4e2337ad3" ref="Microsoft.RedDog.Contract\ServiceContract\StoreWCF.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="21acc778-c371-4e02-b626-3ae35419e208" ref="Microsoft.RedDog.Contract\Interface\StoreWCF:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/StoreWCF.Azure/StoreWCF.AzureGroup/StoreWCF:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>