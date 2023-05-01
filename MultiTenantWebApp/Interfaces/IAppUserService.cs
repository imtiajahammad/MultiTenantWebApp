using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantWebApp.Models;

namespace MultiTenantWebApp.Interfaces;

public interface IAppUserService
{
    public string GetTenantByEmail(string email);
    public string Signin(Signin model);
}
