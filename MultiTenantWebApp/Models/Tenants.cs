using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantWebApp.Models;

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
