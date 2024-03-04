// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//Run F5
//Ctrl + k + c => Disable
//Ctrl + k + u => Enable

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