using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantWebApp.Models;

namespace MultiTenantWebApp.Interfaces;

public interface ITenantService
{
    Tenants GetTenantBySubDomain(string subDomain);
    Tenants GetTenantByEmail(string email);
}
