using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GreyWilson.Web.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SQLiteConnection sqlite_conn;
            //sqlite_conn = CreateConnection();
            //CreateTable(sqlite_conn);
            //InsertData(sqlite_conn);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqLiteConnection;
            sqLiteConnection = new SQLiteConnection("Data Source=database.sqlite; Version = 3;");
            try
            {
                sqLiteConnection.Open();
            }
            catch (Exception ex)
            {

            }
            return sqLiteConnection;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            //Clear table everytime the application restarts 
            var sqLiteCommand = new SQLiteCommand("DROP TABLE IF EXISTS Claim", conn);
            sqLiteCommand.ExecuteNonQuery();

            string sql = "CREATE TABLE Claim  (ID INTEGER PRIMARY KEY, CustomerNumber VARCHAR(25), LastName VARCHAR(50), Description VARCHAR(255), ClaimAmount DOUBLE, CreatedOn VARCHAR(50))";
            sqLiteCommand = conn.CreateCommand();
            sqLiteCommand.CommandText = sql;
            sqLiteCommand.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection conn)
        {
            string sql = "INSERT INTO Claim (CustomerNumber, LastName, Description, ClaimAmount, CreatedOn) VALUES('1234567', 'Wilson', 'I got in a crash.', 1000000, '" + DateTime.Now.ToString() + "');";
            SQLiteCommand sqLiteCommand;
            sqLiteCommand = conn.CreateCommand();
            sqLiteCommand.CommandText = sql;
            sqLiteCommand.ExecuteNonQuery();

            sql = "INSERT INTO Claim (CustomerNumber, LastName, Description, ClaimAmount, CreatedOn) VALUES('2345678', 'Bell', 'I fell and cant get up.', 500000, '" + DateTime.Now.ToString() + "');";
            sqLiteCommand = conn.CreateCommand();
            sqLiteCommand.CommandText = sql;
            sqLiteCommand.ExecuteNonQuery();

            sql = "INSERT INTO Claim (CustomerNumber, LastName, Description, ClaimAmount, CreatedOn) VALUES('4567890', 'Martinez', 'I slipped at work.', 750000, '" + DateTime.Now.ToString() + "');";
            sqLiteCommand = conn.CreateCommand();
            sqLiteCommand.CommandText = sql;
            sqLiteCommand.ExecuteNonQuery();




        }


    }
}
