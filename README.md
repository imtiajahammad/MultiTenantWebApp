# MultiTenantWebApp

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



<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Database Preparation -->
_For Database end, we are going to maintain 2 types of databases-
1. for managing the tenants
2. each one for each tenant/customer

For preparing the database with table structures and some seeding data, we are going to follow these steps-
1. create a tenant database where all the tenant/customer database info will be kept
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

<!-- Database Preparation -->


<!-- Application Create Steps  -->
# Application Create Steps

1. Create a MVC application using .NET6 framework
2. 

<!-- Application Create Steps  -->

<!-- reference -->

### References

1. [https://www.c-sharpcorner.com/article/how-to-building-a-multi-tenant-applications-with-asp-net-core/](https://www.c-sharpcorner.com/article/how-to-building-a-multi-tenant-applications-with-asp-net-core/)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- reference -->

