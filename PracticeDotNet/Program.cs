// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Data.SqlClient;
using PracticeDotNet.AdoDotNet;
using PracticeDotNet.Dapper;

//Console.WriteLine("Hello, World!");

//Run F5
//Ctrl + k + c => Disable
//Ctrl + k + u => Enable
/*#region Read
SqlConnectionStringBuilder ConnectSql = new SqlConnectionStringBuilder();//Connect SQl
ConnectSql.DataSource = ".";
ConnectSql.InitialCatalog = "C#TestDb";
ConnectSql.UserID = "sa";
ConnectSql.Password = "sasa@123";

string DataFromTable = "select * from C#_Table";//Data From Table
SqlConnection BuildSqlConnection = new SqlConnection(ConnectSql.ConnectionString);//Build SqlConnection
BuildSqlConnection.Open();
SqlCommand CreateCommand = new SqlCommand(DataFromTable, BuildSqlConnection);//prepare
SqlDataAdapter GetData = new SqlDataAdapter(CreateCommand);//prepare

DataTable TableData = new DataTable();//Store Data
GetData.Fill(TableData);//GetData
BuildSqlConnection.Close();

foreach(DataRow TableRow in TableData.Rows)//Rows of Table
{
    Console.WriteLine(TableRow["Id"]);
    Console.WriteLine(TableRow["Customer_Name"]);
    Console.WriteLine(TableRow["Customer_Address"]);
    Console.WriteLine(TableRow["Item_Name"]);

}
#endregion*/


//CRUD

/*SqlConnectionStringBuilder SqlConnect = new SqlConnectionStringBuilder();
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
*/

//For AdoDotNet
//AdoDotNetCRUD ForTest = new AdoDotNetCRUD();
//ForTest.Read();
//ForTest.Edit(1);
//ForTest.Edit(10);
//ForTest.Create("Khant Htet Linn", "Yangon", "T_Shirt");
//ForTest.Update(9,"Khant Htet ", "Hlaing", "Jeans");
//ForTest.Delete(8);

//For Dapper
DapperCRUD ForTest = new DapperCRUD();
//ForTest.Read();
//ForTest.Edit(1);
//ForTest.Edit(10);
//ForTest.Create("Mg Khant Htet Linn", "Yangon", "T_Shirt");
//ForTest.Create("Chaw ", "Yangon", "T_Shirt");
 //ForTest.Update(14, "Chaw Su Han ", "Hlaing", "Jeans");
//ForTest.Delete(14);
ForTest.Delete(13);