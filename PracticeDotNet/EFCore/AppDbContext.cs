using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                Password="sasa@123"
            };
            optionsBuilder.UseSqlServer(SqlConnection.ConnectionString);
        }
        public DbSet<Model> TestModel { get; set; }//Mapping
    }
 
}
