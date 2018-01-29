using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review3_.NET.Models
{
    public class UserRole : IdentityRole
    {
        public UserRole(string roleName):base(roleName)
        {
            
        }
    }
}
