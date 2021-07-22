using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccesss
{
    public static class SqlDataAccess
    {
        //getting connection string
        //connectionName is in webconfig(<connectionString><connectionString>)
        public static string GetConnectionString(string connectionName = "MVCDemoDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        //loading data from db
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        //saving data in db
        public static int SaveData<T>(string sql,T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql,data);
            }
        }

    }
}
