using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review3.NET.Models
{
    public class UserRole : IdentityRole
    {
        UserRole(string roleName):base(roleName)
        {
            
        }
    }
}
