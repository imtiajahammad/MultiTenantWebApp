using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantWebApp.Models;

public class TenantUsers
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Email { get; set; }
}
