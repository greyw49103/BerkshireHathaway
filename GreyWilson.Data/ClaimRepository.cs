using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace GreyWilson.Data
{
    public class ClaimRepository
    {
        private string _ConnectionString;

        public ClaimRepository()
        {
            _ConnectionString = @"Data Source=database.sqlite;Version = 3;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SQLiteConnection(_ConnectionString);
            }
        }

        public void Create(Claim claim)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = "INSERT INTO Claim (CustomerNumber, LastName, Description, ClaimAmount, CreatedOn)"
                                + " VALUES(@CustomerNumber, @LastName, @Description, @ClaimAmount, @CreatedOn)";
                dbConnection.Open();
                dbConnection.Execute(sql, claim);
            }
        }

        public IEnumerable<Claim> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Claim>("SELECT * FROM Claim");
            }
        }

        public Claim GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = "SELECT * FROM Claim WHERE ID = @id";
                dbConnection.Open();
                return dbConnection.Query<Claim>(sql, new { id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = "DELETE FROM Claim WHERE ID = @id";
                dbConnection.Open();
                dbConnection.Execute(sql, new { id });
            }
        }

        public void Update(Claim claim)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = "UPDATE Claim "
                               + "SET CustomerNumber = @CustomerNumber,"
                               + "LastName = @LastName,"
                               + "Description = @Description,"
                               + "ClaimAmount = @ClaimAmount, " 
                               + "CreatedOn = @CreatedOn"
                               + "WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Query(sql, claim);
            }
        }
    }
}
