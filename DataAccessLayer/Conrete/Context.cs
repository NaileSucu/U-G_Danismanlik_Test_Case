using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NAILE\\SQLEXPRESS;Database=UG_Danismanlik_Fatura_Test_Case;User Id=sa;Password=1;TrustServerCertificate=True;");
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice_Detail> Invoices { get; set; }
    }
}
