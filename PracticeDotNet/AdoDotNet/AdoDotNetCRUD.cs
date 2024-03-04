using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDotNet.AdoDotNet
{
    public class AdoDotNetCRUD
    {
        public void Read()//Read
        {
                SqlConnectionStringBuilder SqlConnect = new SqlConnectionStringBuilder();
                SqlConnect.DataSource = ".";
                SqlConnect.InitialCatalog = "C#TestDb";
                SqlConnect.UserID = "sa";
                SqlConnect.Password = "sasa@123";
                SqlConnection Build = new SqlConnection(SqlConnect.ConnectionString);

                Build.Open();

                string query = @"SELECT [Id]
                      ,[Customer_Name]
                      ,[Customer_Address]
                      ,[Item_Name]
                  FROM [dbo].[C#_Table]";

                SqlCommand Cmd = new SqlCommand(query,Build);

                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                DataTable Table = new DataTable();
                Adapter.Fill(Table);

                Build.Close();

                foreach(DataRow DR in Table.Rows )
                {
                    Console.WriteLine("Customer Name is "+ DR["Customer_Name"]);
                    Console.WriteLine("Customer Address is "+ DR["Customer_Address"]);
                    Console.WriteLine("Item Name is "+DR["Item_Name"]);
                }
        }//Read
        public void Edit(int id)//Edit
        {
            SqlConnectionStringBuilder SqlConnect = new SqlConnectionStringBuilder();
            SqlConnect.DataSource = ".";
            SqlConnect.InitialCatalog = "C#TestDb";
            SqlConnect.UserID = "sa";
            SqlConnect.Password = "sasa@123";
            SqlConnection Build = new SqlConnection(SqlConnect.ConnectionString);

            Build.Open();

            string query = @"SELECT [Id]
                      ,[Customer_Name]
                      ,[Customer_Address]
                      ,[Item_Name]
                  FROM [dbo].[C#_Table] Where Id = @ForId";//Where Condition

            SqlCommand Cmd = new SqlCommand(query, Build);
            Cmd.Parameters.AddWithValue("@ForId", id);//Get Id
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);

            Build.Close();

            if(Table.Rows.Count==0)
            {
                Console.WriteLine("No Data Found!");
                return;
            }
            DataRow DR = Table.Rows[0];
                Console.WriteLine("Customer Name is " + DR["Customer_Name"]);
                Console.WriteLine("Customer Address is " + DR["Customer_Address"]);
                Console.WriteLine("Item Name is " + DR["Item_Name"]);
        }//Edit
        public void Create(string CusName, string Address, string ItemName)//Create
        {
            SqlConnectionStringBuilder SqlConnect = new SqlConnectionStringBuilder();
            SqlConnect.DataSource = ".";
            SqlConnect.InitialCatalog = "C#TestDb";
            SqlConnect.UserID = "sa";
            SqlConnect.Password = "sasa@123";
            SqlConnection Build = new SqlConnection(SqlConnect.ConnectionString);

            Build.Open();

            string query = @"insert into [dbo].[c#_table]
           ([customer_name]
           ,[customer_address]
           ,[item_name])
     values
           (@Customer_Name
           ,@Customer_Address
           ,@Item_Name)";

            SqlCommand Cmd = new SqlCommand(query, Build);
            Cmd.Parameters.AddWithValue("@Customer_Name",CusName);
            Cmd.Parameters.AddWithValue("@Customer_Address",Address);
            Cmd.Parameters.AddWithValue("@Item_Name",ItemName);

            int result = Cmd.ExecuteNonQuery();

            Build.Close();
            string message = result > 0 ? "Creating Successful" : "Creating Failed";
            Console.WriteLine(message);

        }//Create
        public void Update(int id,string CusName, string Address, string ItemName)//Create
        {
            SqlConnectionStringBuilder SqlConnect = new SqlConnectionStringBuilder();
            SqlConnect.DataSource = ".";
            SqlConnect.InitialCatalog = "C#TestDb";
            SqlConnect.UserID = "sa";
            SqlConnect.Password = "sasa@123";
            SqlConnection Build = new SqlConnection(SqlConnect.ConnectionString);

            Build.Open();

            string query = @"UPDATE [dbo].[C#_Table]
            SET   [Customer_Name] = @TestCustomerName,
                  [Customer_Address] =@TestCustomerAddress,
                  [Item_Name] = @TestItemName
                   WHERE Id=@TestId";

            SqlCommand Cmd = new SqlCommand(query, Build);
            Cmd.Parameters.AddWithValue("@TestId", id);
            Cmd.Parameters.AddWithValue("@TestCustomerName", CusName);
            Cmd.Parameters.AddWithValue("@TestCustomerAddress", Address);
            Cmd.Parameters.AddWithValue("@TestItemName", ItemName);

            int result = Cmd.ExecuteNonQuery();

            Build.Close();
            string message = result > 0 ? "Updating Successful" : "Upaating Failed";
            Console.WriteLine(message);

        }//Update
        public void Delete(int id)//Delete
        {
            SqlConnectionStringBuilder SqlConnect = new SqlConnectionStringBuilder();
            SqlConnect.DataSource = ".";
            SqlConnect.InitialCatalog = "C#TestDb";
            SqlConnect.UserID = "sa";
            SqlConnect.Password = "sasa@123";
            SqlConnection Build = new SqlConnection(SqlConnect.ConnectionString);

            Build.Open();

            string query = @"DELETE FROM [dbo].[C#_Table]
      WHERE Id=@TestId";

            SqlCommand Cmd = new SqlCommand(query, Build);
            Cmd.Parameters.AddWithValue("@TestId", id);


            int result = Cmd.ExecuteNonQuery();

            Build.Close();
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);

        }//Delete
    }
}
