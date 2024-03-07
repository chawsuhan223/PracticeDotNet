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
        public void Read()//Read
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
        }//Read

        public void Edit(int id)//Edit
        {
            AppDbContext db = new AppDbContext();//Because AppDbContext include SqlConnectionStringBuilder
            //TestModel Item = db.Model.Where(item => item.Id == id).FirstOrDefault();
            TestModel item = db.Model.FirstOrDefault(item => item.Id == id);
            if (item is null)
                {
                Console.WriteLine("No Data Found!");
                return;
            };
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Customer_Name);
                Console.WriteLine(item.Customer_Address);
                Console.WriteLine(item.Item_Name);
        }//Edit

        public void Create(string CustomerName,string Address,string ItemName)//Create
        {
            TestModel model = new TestModel()
            {
                Customer_Name = CustomerName,
                Customer_Address = Address,
                Item_Name = ItemName
            };
            AppDbContext Db = new AppDbContext();
            Db.Model.Add(model);
            int result = Db.SaveChanges();//Execute
            string message = result > 0 ? "Creating Successful" : "Creating Failed";
            Console.WriteLine(message);
        }//Create

        public void Update(int id, string CustomerName, string Address, string ItemName)//Update
        {
            AppDbContext db = new AppDbContext();//Because AppDbContext include SqlConnectionStringBuilder
            TestModel item = db.Model.FirstOrDefault(item => item.Id == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            };
            item.Customer_Name = CustomerName;
            item.Customer_Address = Address;
            item.Item_Name = ItemName;

            int result = db.SaveChanges();//Execute
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }//Update
        public void Delete(int id)//Delete
        {
            AppDbContext db = new AppDbContext();//Because AppDbContext include SqlConnectionStringBuilder
            TestModel item = db.Model.FirstOrDefault(item => item.Id == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            };
            db.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
