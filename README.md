# ShareSession-Demo

 1. Go to IIS, add 2 Website
 
 ![WebApplication1](/Images/WebApplication1.png?raw=true "WebApplication1")
 ![WebApplication2](/Images/WebApplication2.png?raw=true "WebApplication2")
 
 2. Add reference to SharedSessionModule
 3. Edit Web.config as below
 
```xml
<configuration>
  <system.web>
    <sessionState mode="SQLServer" sqlConnectionString="Data Source=.\;User ID=sa;Password=Password12!;" />
  </system.web>
  <appSettings>
    <add key="ApplicationName" value="MySampleWebSite" />
    <add key="RootDomain" value=".pec.it" />
  </appSettings>
  <system.webServer>
    <modules>
      <add name="SharedSessionModule"
           type="SharedSessionModule.SharedSessionModule, SharedSessionModule, Version=1.0.0.0, Culture=neutral" />
    </modules>
  </system.webServer>
</configuration>
```
