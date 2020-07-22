using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetExerc2.Models
{
    public class Context : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
