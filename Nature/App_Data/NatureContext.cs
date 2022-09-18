using Nature.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nature.App_Data
{
    public class NatureContext : DbContext
    {
        public NatureContext() : base("ConnNature")
        {

        }

        public DbSet<Genero> Gens { get; set; }
        public DbSet<SerVivo> Sers { get; set; }
    }
}
