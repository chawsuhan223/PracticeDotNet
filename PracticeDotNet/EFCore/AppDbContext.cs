using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticeDotNet.Models;

namespace PracticeDotNet.EFCore
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder SqlConnection = new SqlConnectionStringBuilder()
            {
                DataSource=".",
                InitialCatalog="C#TestDb",
                UserID="sa",
                Password="sasa@123",
                TrustServerCertificate=true,
            };
            optionsBuilder.UseSqlServer(SqlConnection.ConnectionString);
        }
        public DbSet<TestModel> Model { get; set; }//Mapping
    }
 
}
