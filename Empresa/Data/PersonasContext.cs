using Empresa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Data
{
    public class PersonasContext : DbContext
    {
        public PersonasContext(DbContextOptions<PersonasContext>options) : base(options)
        {

        }
        public DbSet<T_Empleado> T_Empleado { get; set; }
    }
}
