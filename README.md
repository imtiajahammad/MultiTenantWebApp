# MultiTenantWebApp
<a name="readme-top"></a>
<!-- PROJECT LOGO -->
<br />
<div align="center">
  <!--a href="https://github.com/othneildrew/Best-README-Template">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a-->

  <h3 align="center">MultiTenantWebApp</h3>

  <p align="center">
    to build a multi-tenant applications with ASP.NET Core
    <!-- 
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Report Bug</a>    
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Request Feature</a>
    -->
  </p>
</div>


<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#what-is-tenant-application">What is Tenant Application</a>
    </li>
    <li><a href="#database-preparation">Database Preparation</a></li>
    <li><a href="#application-create-steps">Application Create Steps</a></li>
    <li><a href="#references">References</a></li>
  </ol>
</details>


<!-- What is Tenant Application -->
### What is Tenant Application

Simply tenant is a customer. Meaning each customer is called a tenant.
Multi-tenancy is an architecture in which a single software application instance serves multiple customers.
In this case, a single software will manage multiple customer databases. But you have needed a tenant database for multiple tenants. This process is also called SaaS (Software as a Service).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- What is Tenant Application -->


<!-- Database Preparation -->
### Database Preparation




<!-- Database Preparation -->
_For Database end, we are going to maintain 2 types of databases-
1. for managing the tenants
2. each one for each tenant/customer

For preparing the database with table structures and some seeding data, we are going to follow these steps-
1. create a tenant database where all the tenant/customer database info will be kept
```
CREATE DATABASE [TenantDB]
```
```
USE [TenantDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[CustomerId] [int] NOT NULL,
	[Customer] [varchar](50) NOT NULL,
	[Host] [varchar](50) NULL,
	[SubDomain] [varchar](50) NOT NULL,
	[Logo] [varchar](50) NULL,
	[ThemeColor] [varchar](50) NULL,
	[ConnectionString] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```
2. create tables for TenantUsers where all the tenant details are stored
```
USE [TenantDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantUsers](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```
3. add data for 3 dummy tenants
```
USE [TenantDB]
GO
INSERT [dbo].[Tenants] ([CustomerId], [Customer], [Host], [SubDomain], [Logo], [ThemeColor], [ConnectionString]) VALUES (1, N'Red Customer', N'localhost:5057', N'rc', NULL, N'Red', N'Server=Rohol;Database=App-DB1; user id=sa; password=123456; MultipleActiveResultSets=true')
GO
INSERT [dbo].[Tenants] ([CustomerId], [Customer], [Host], [SubDomain], [Logo], [ThemeColor], [ConnectionString]) VALUES (2, N'Green Customer', N'localhost:5057', N'gc', NULL, N'Green', N'Server=Rohol;Database=App-DB2; user id=sa; password=123456; MultipleActiveResultSets=true')
GO
INSERT [dbo].[TenantUsers] ([Id], [CustomerId], [Email]) VALUES (1, 1, N'rc@example.com')
GO
INSERT [dbo].[TenantUsers] ([Id], [CustomerId], [Email]) VALUES (2, 2, N'gc@example.com')
GO
```
4. For tenants data, we are keeping a single database for each single tenant. Here we are creating 2 dummy database for 2 tenants and seed some dummy data 
```
CREATE Database [App-DB1]
GO
USE [App-DB1]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserEmail] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [App-DB1]
GO
INSERT [dbo].[Users] ([UserId], [UserName], [UserEmail], [Password]) VALUES (1, N'Red Customer', N'rc@example.com', N'123456')
GO
```
```
CREATE Database [App-DB2]
GO
USE [App-DB2]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/15/23 5:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserEmail] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [App-DB2]
GO
INSERT [dbo].[Users] ([UserId], [UserName], [UserEmail], [Password]) VALUES (1, N'Green Customer', N'gc@example.com', N'123456')
GO
```
<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Database Preparation -->


<!-- Application Create Steps  -->
# Application Create Steps

1. Create a MVC application using .NET6 framework
2. Go to the NuGet Package Manager and install the SaasKit.Multitenancypackage. This SaasKit.Multitenancy package will manage a multi-tenancy strategy.
3. Add a new class "Tenants"
```
public class Tenants
    {
        [Key]
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public string Host { get; set; }
        public string SubDomain { get; set; }
        public string Logo { get; set; }
        public string ThemeColor { get; set; }
        public string ConnectionString { get; set; }
    }
```
4. Add a new class "TenantUsers"
```
public class TenantUsers
   {
       [Key]
       public int Id { get; set; }
       public int CustomerId { get; set; }
       public string Email { get; set; }
   }
```
5. Now add another class like TenantResolver. Here we will use TenantContext, which is come from SaasKit.Multitenancy package.
```
public interface ITenantResolver
    {
        Task<TenantContext<Tenants>> ResolveAsync(HttpContext context);
    }
public class TenantResolver : ITenantResolver<Tenants>
    {
      public async Task<TenantContext<Tenants>> ResolveAsync(HttpContext context)
        {
         throw new NotImplementedException();
        }
    }
```
6. Go to the program file and register the Tenant class with TenantResolver class
```
// Multitenancy
builder.Services.AddMultitenancy<Tenants, TenantResolver>();
```
7. Middleware Setup -> This Tenant middleware will call with every HTTP request.
```
app.UseMuttitenancy<Tenant>();
```
8. Install Entity Framework Core -> we will useEFCore ORM to access SQL Database. So, we need to install the required packages. 
<ul>
    <li>Microsoft.EntityFrameworkCore.SqlServer</li>
    <li>Microsoft.EntityFrameworkCore.Relational</li>
    <li>Microsoft.EntityFrameworkCore</li>
</ul>

9. After installing these three packages, I will add Two database contexts. One context is for Tenant-Database and another for App-Database. We will add the connection string for tenantConnection
```
{
  "ConnectionStrings": {
    "TenantConnection": "Server=Rohol;Database=TenantDB; user id=sa; password=123456; MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
```
// Sql Server TenantDb Connection
builder.Services.AddDbContextPool<TenantDbContext>(options => options.
        UseSqlServer(builder.Configuration.GetConnectionString("TenantConnection")));
```
10. Now add Signin class in the Models folder
```
public class Signin
    {
        [Required(ErrorMessage ="email address is required")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
```
11. add Users class in the Models folder
```
public class Users
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }

    }
```
12. Now time to implement Db contexts.
```
public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> option) : base(option)
        {
        }

        public DbSet<Tenants> Tenants { get; set; }
        public DbSet<TenantUsers> TenantUsers { get; set; }

    }
```
```
public class AppDbContext : DbContext
    {
        private readonly Tenants tenant;

        public AppDbContext(DbContextOptions<AppDbContext> options, Tenants tenant):base(options)
        {
            this.tenant = tenant;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(tenant.ConnectionString);
        }

        public DbSet<Users> Users { get; set; }

    }
```

13. We will use two services for this application in Services folder. One for tenant operation and another for application operation.

```
namespace MultiTenantApp.Services
{
    public interface ITenantService
    {
       Tenants GetTenantBySubDomain(string subDomain);
       Tenants GetTenantByEmail(string email);
    }

    public class TenantService : ITenantService
    {
        private readonly TenantDbContext tdbc;

        public TenantService(TenantDbContext tdbc)
        {
            this.tdbc = tdbc;
        }

        public Tenants GetTenantByEmail(string email)
        {
         throw new NotImplementedException();
        }

        public Tenants GetTenantBySubDomain(string subdomain)
        {
         throw new NotImplementedException();
        }
    }
}
```


<ul>
<li>GetTenantBySubDomain()- This method will return a tenant by sub-domain.</li>
<li>GetTenantByEmail ()- This method will return a tenant by email.</li>
</ul>

```
namespace MultiTenantApp.Services
{
    public interface IAppUserService
    {
        public string GetTenantByEmail(string email);
        public string Signin(Signin model);
    }
    public class AppUserService : IAppUserService
    {
        public string GetTenantByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public string Signin(Signin model)
        {
            throw new NotImplementedException();
        }
    }
}
```
<ul>
<li>GetTenantByEmail()- Here, this method will return a valid URL with a sub-domain.</li>
<li>Signin()- This method is used to sign in to this portal. It will return a URL as a string.</li>
</ul>

14. TenantResolver implementation

```
private readonly IConfiguration configuration;
// Gets or sets the current HttpContext. Returns null if there is no active HttpContext.
private readonly IHttpContextAccessor httpContextAccessor;
private readonly ITenantService tenantService;

public TenantResolver(IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        ITenantService tenantService)
{
  this.httpContextAccessor = httpContextAccessor;
  this.tenantService = tenantService;
  this.configuration = configuration;
}
public async Task<TenantContext<Tenants>> ResolveAsync(HttpContext context)
{   
  // get sub-domain form browser current url. if sub-domain is not exists then will set empty string
  string subDomainFromUrl = context.Request.Host.Value.ToLower().Split(".")[0] ?? string.Empty;
  // checking has any tenant by current sub-domain.
  var result = this.tenantService.GetTenantBySubDomain(subDomainFromUrl);
  Tenants tenant = new();
  // checking has any subdomain is exists in current url
  if (!string.IsNullOrEmpty(result.SubDomain))
  {
    // checking orginal sub-domain and current url sub-domain
    if (!result.SubDomain.Equals(subDomainFromUrl)) return null; // if sub-domain is different then return null
    else
      {
        tenant.CustomerId = result.CustomerId;
        tenant.Customer = result.Customer;
        tenant.Host = result.Host;
        tenant.SubDomain = result.SubDomain;
        tenant.Logo = result.Logo;
        tenant.ThemeColor = result.ThemeColor;
        tenant.ConnectionString = result.ConnectionString;
        return await Task.FromResult(new TenantContext<Tenants>(tenant));
      }
  }
  else return await Task.FromResult(new TenantContext<Tenants>(tenant));

}
```
This resolver will resolve a multitenant strategy in each HTTP request. If the tenant is valid, then the HTTP request will execute else. The application will show an error. Here I am checking the sub-domain in each request. So, if the sub-domain exists and is valid, the app will work fine; otherwise shows an error. This is a demo and my logic and implementation so anyone can implement his logic.

15. add a Signin action in HomeController for view
```
public IActionResult Signin(string emailid="")
        {
            ViewBag.Email = emailid;
            return View();
        }
```
16. add Signin Post Action for Signin
```
[HttpPost]
        public IActionResult Signin(Signin model)
        {
            // checking model state
            if (ModelState.IsValid)
            {
                // checking email at first time
                if (model.Password is null)
                {
                    // retrieve tenant information by user email
                    var result = this.appUserService.GetTenantByEmail(model.Email);
                    // if valid email then redirect for password
                    if (result is not null) return Redirect(result + "?emailid=" + model.Email);
                    else // if email is invalid then clear Email-ViewBag to stay same page and get again email
                    {
                        ViewBag.Email = string.Empty;
                        ViewBag.Error = "Provide valid email";
                    }
                }
                else // this block for password verification, when user provide password to signin
                {
                    var result = this.appUserService.Signin(model);
                    if (result is null) // if password is wrong then again provide valid password
                    {
                        ViewBag.Email = model.Email;
                        ViewBag.Error = "Provide valid password";
                    }
                    else return Redirect(result); // if password is valid then portal will open for user access
                }
            }
            else ViewBag.Email = ""; // if email is invalid then clear Email-ViewBag to stay same page and get again email
            return View();
        }
```

17. Logout action
```
public IActionResult Logout()
        {
            return Redirect("http://localhost:5057");
        }
```
18. Go to the master _Layout.cshtml page and inject the Tenant class to access the required property. I will use the ThemeColor property to change the theme according to the user's colour. Like,
```
@inject Tenants tenants;

<body style="background-color:@tenants.ThemeColor">
```
19. Same as the index and privacy files. we will use the Customer name from the tenant class
```
@inject Tenants tenants;
@{
    ViewData["Title"] = "Home Page";
}

<h1>@ViewData["Title"]</h1>

<h4>of @tenants.Customer</h4>
```

20. Run the project and sign in by different users.



<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Application Create Steps  -->

<!-- reference -->

### References

1. [https://www.c-sharpcorner.com/article/how-to-building-a-multi-tenant-applications-with-asp-net-core/](https://www.c-sharpcorner.com/article/how-to-building-a-multi-tenant-applications-with-asp-net-core/)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- reference -->

