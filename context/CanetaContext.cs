using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_C_.entidades;
using Microsoft.EntityFrameworkCore;

namespace CRUD_C_.context
{
    public class CanetaContext : DbContext
    {
        public CanetaContext(DbContextOptions<CanetaContext> options) : base(options) { }

        public DbSet<Caneta> Canetas { get; set; }
    }
}