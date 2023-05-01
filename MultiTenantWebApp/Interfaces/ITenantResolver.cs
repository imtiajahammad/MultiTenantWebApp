using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantWebApp.Models;
using SaasKit.Multitenancy;

namespace MultiTenantWebApp.Interfaces;

public interface ITenantResolver
{
    Task<TenantContext<Tenants>> ResolveAsync(HttpContext context);
}
