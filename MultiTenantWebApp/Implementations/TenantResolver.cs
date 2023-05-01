using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantWebApp.Models;
using SaasKit.Multitenancy;

namespace MultiTenantWebApp.Implementations;

public class TenantResolver : ITenantResolver<Tenants>
{
    public async Task<TenantContext<Tenants>> ResolveAsync(HttpContext context)
        {
         throw new NotImplementedException();
        }
}
