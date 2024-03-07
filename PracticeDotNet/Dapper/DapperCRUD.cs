using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PracticeDotNet.Models;

namespace PracticeDotNet.Dapper
{
    public class DapperCRUD
    {
        private readonly SqlConnectionStringBuilder SqlConnect = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "C#TestDb",
            UserID = "sa",
            Password = "sasa@123"
        };//Connect SQL DataBase
        public void Read()//Read
        {
            string query = @"SELECT [Id]
                ,[Customer_Name]
                ,[Customer_Address]
                ,[Item_Name]
            FROM [dbo].[C#_Table]";
            using IDbConnection Test = new SqlConnection(SqlConnect.ConnectionString);//Create SQL Connection
            List<BlogModel> lst = Test.Query<BlogModel>(query).ToList();//equal Fill(Mapping)

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Customer_Name);
                Console.WriteLine(item.Customer_Address);
                Console.WriteLine(item.Item_Name);
            }
        }//Read

        public void Edit(int id)//Edit
        {

            string query = @"SELECT [Id]
                      ,[Customer_Name]
                      ,[Customer_Address]
                      ,[Item_Name]
                  FROM [dbo].[C#_Table] Where Id = @Id";//Where Condition

            using IDbConnection Db = new SqlConnection(SqlConnect.ConnectionString);
            var item = Db.Query<BlogModel>(query, new { Id = id }).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Customer_Name);
            Console.WriteLine(item.Customer_Address);
            Console.WriteLine(item.Item_Name);
        }//Edit

        public void Create(string CusName, string Address, string ItemName)//Create
        {
            string query = @"insert into [dbo].[c#_table]
           ([customer_name]
           ,[customer_address]
           ,[item_name])
     values
           (@Customer_Name
           ,@Customer_Address
           ,@Item_Name)";

            BlogModel model = new BlogModel()
            {
                Customer_Name = CusName,
                Customer_Address = Address,
                Item_Name = ItemName
            };
            using IDbConnection dbconnection = new SqlConnection(SqlConnect.ConnectionString);
            int result = dbconnection.Execute(query, model);//mapping
            //int result = dbconnection.Execute(query, new { Customer_Name = CusName, Customer_Address = Address, Item_Name = ItemName });
            string message = result > 0 ? "Creating Successful" : "Creating Failed";
            Console.WriteLine(message);

        }//Create

        public void Update(int id, string CusName, string Address, string ItemName)//Create
        {
            string query = @"UPDATE [dbo].[C#_Table]
            SET   [Customer_Name] = @Customer_Name,
                  [Customer_Address] =Customer_Address,
                  [Item_Name] = @Item_Name
                   WHERE Id=@id";
            BlogModel model = new BlogModel()
            {
                Id = id,
                Customer_Name = CusName,
                Customer_Address = Address,
                Item_Name = ItemName
            };
            using IDbConnection dbconnection = new SqlConnection(SqlConnect.ConnectionString);
            int result1 = dbconnection.Execute(query, model);//mapping
            string message1 = result1 > 0 ? "Updating Successful" : "Upaating Failed";
            Console.WriteLine(message1);

        }//Update

        public void Delete(int id)//Delete
        {
            //      string query = @"DELETE FROM [dbo].[C#_Table]
            //WHERE Id=@TestId";
            string query = @"DELETE FROM [dbo].[C#_Table]
      WHERE Id=@Id";
            BlogModel model = new BlogModel()
            {
                Id = id,
            };
            using IDbConnection dbConnection = new SqlConnection(SqlConnect.ConnectionString);
            var result2 = dbConnection.Execute(query, model);
            //var result = dbConnection.Execute(query, new { TestId = id });
            string message2 = result2 > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message2);

        }//Delete
    }
}
