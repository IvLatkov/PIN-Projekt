using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PINprojekt_Ivan_Latkovic.Models
{
    public class DbKontekst : DbContext
    {
        public DbKontekst(DbContextOptions<DbKontekst> options) : base(options)
        {

        }
        public DbSet<Knjiga> Knjiga { get; set; }
    }
}
