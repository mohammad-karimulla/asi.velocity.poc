using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Data.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("MySqlConnectionString")
        {

        }

        public DbSet<ProductDetails> ProductDetails { get; set; }
    }
}
