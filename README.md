# Invoice application with [Dapper](https://en.wikipedia.org/wiki/Dapper_ORM) and [SQLite](https://www.sqlite.org/index.html)

`SQLite` is a database library.     <br/>
No need to start, stop or configure any server processes to use it.     <br/>
To use SQLite, an administrator does not need to create a new database instance or grant access to users.   <br/>

[Source](https://sqlitebrowser.org/dl/) for SQLite download.    <br/>
In order to use SQLite, the `DB Browser for SQLite` PortableApp must be installed.

A ready-made SQLite Sample Database named [Chinook.db](https://www.sqlitetutorial.net/sqlite-sample-database/) >> `Download SQLite Sample Database` is used.

### [NuGet Gallery](https://github.com/AtakanTurgut/InvoiceApp_SQLite/tree/main/EmployeeLite/packages)
Some packages can be installed from the "[NuGet Gallery](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)" with the help of the `Tools > NuGet Package Manager > Package Manager Console`.

- [System.Configuration.ConfigurationManager 7.0.0](https://www.nuget.org/packages/System.Configuration.ConfigurationManager/7.0.0)
```
    PM>  NuGet\Install-Package System.Configuration.ConfigurationManager -Version 7.0.0
```
- [System.Data.SQLite 1.0.118](https://www.nuget.org/packages/System.Data.SQLite/1.0.118)
```
    PM>  NuGet\Install-Package System.Data.SQLite -Version 1.0.118
```
- [Dapper 2.0.151](https://www.nuget.org/packages/Dapper/2.0.151) | [github](https://github.com/DapperLib/Dapper)
```
    PM>  NuGet\Install-Package Dapper -Version 2.0.151
```

![](/pictures/employeeLite.gif)
