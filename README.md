# BookList_RazorPostgres
Razor Pages BookList project from Bhrugen Patel's .Net Core 2.1 Udemy course using PostgreSQL instead of MS SQL Server.

To use PostgreSQL as your db, first install the EntityFrameworkCore NuGet package:

```bash
$ dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 2.1.0
```

Then, update the **ApplicationDbContext.cs** file to include the below method:

```C#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseNpgsql("Host=server;Database=dbName;Username=username;Password=password");
```

In **Startup.cs**, add the following to the ConfigureServices method, above services.AddMvc()

```C#
            services.AddEntityFrameworkNpgsql()
            .AddDbContext<ApplicationDbContext>(
                options => options
                .UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
```

Finally, your connection string in the **appsettings.json** file should be:

```JSON
"ConnectionStrings": {
    "DefaultConnection" : "Host=servername;Port=portnumber;Username=username;Password=password;Database=DBname;"
  }
```
