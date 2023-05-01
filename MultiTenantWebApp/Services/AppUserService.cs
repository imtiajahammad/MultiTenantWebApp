using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantWebApp.Interfaces;
using MultiTenantWebApp.Models;

namespace MultiTenantWebApp.Services;

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
