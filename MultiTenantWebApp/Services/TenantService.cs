using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantWebApp.DbContexts;
using MultiTenantWebApp.Interfaces;
using MultiTenantWebApp.Models;

namespace MultiTenantWebApp.Services;

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
