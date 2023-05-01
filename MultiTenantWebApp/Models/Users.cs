using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantWebApp.Models;

public class Users
{
    [System.ComponentModel.DataAnnotations.Key]
    public int UserId { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string UserEmail { get; set; }
    [Required]
    public string Password { get; set; }
}
