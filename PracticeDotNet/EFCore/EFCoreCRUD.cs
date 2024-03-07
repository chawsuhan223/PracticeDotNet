using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticeDotNet.Models;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
namespace PracticeDotNet.EFCore
{
    public class EFCoreCRUD
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();//Because AppDbContext include SqlConnectionStringBuilder
            List<TestModel> lst = db.Model.ToList();

            foreach (TestModel item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Customer_Name);
                Console.WriteLine(item.Customer_Address);
                Console.WriteLine(item.Item_Name);
            }
        }
    }
}
