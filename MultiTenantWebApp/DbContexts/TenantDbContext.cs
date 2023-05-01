using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiTenantWebApp.Models;

namespace MultiTenantWebApp.DbContexts;

public class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> option) : base(option)
    {
    }

    public DbSet<Tenants> Tenants { get; set; }
    public DbSet<TenantUsers> TenantUsers { get; set; }
}
