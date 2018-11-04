# TTracker
### Startup

Install and configure your own MySQL server.
Install package references with NuGet.

 ```pwsh
PM> Install-Package Microsoft.EntityFrameworkCore
PM> Install-Package Pomelo.EntityFrameworkCore.MySql
```

Filup connectionString in Startup.cs with your config

```cs
connectionString = "server=YOUR_SERVER;database=YOUR_DB;uid=YOUR_USER;pwd=YOUR_PASS";
```
Apply already generaed migration.

```pwsh
> Update-Database
```

Build solution.
Done.

Also you can execute fakedata.sql to to fill db with some data.

### APIs
Basic
```api
GET api/countries
GET api/countries/{countryId}

GET api/tourists
GET api/tourists/{touristId}

GET api/visits/touristId/{visit.year}
GET api/visits/touristId/{visit.year}/{visit.mounth}
GET api/visits/touristId/{visit.year}/{visit.mounth}/{visit.day}
```
Dev
```api
GET api/dev/genvisits/{chance} - generates fake visits data
```

License
----

MIT
