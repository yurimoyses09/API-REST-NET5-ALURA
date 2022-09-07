using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosAPI.Data
{
    public class UsuarioDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opt) : base (opt)
        {

        }
    }
}
