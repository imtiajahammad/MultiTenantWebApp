using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantWebApp.Models;

public class Signin
{
    [Required(ErrorMessage ="email address is required")]
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
