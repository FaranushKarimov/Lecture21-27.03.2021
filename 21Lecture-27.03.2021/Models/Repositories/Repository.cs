using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace _21Lecture_27._03._2021.Models.Repositories
{
    public abstract class Repository<UModel>
    {
        public string connectionString { get; set; }

        public Repository()
        {
            connectionString = "Data Source=KARIMOVFARAMUSH;Initial Catalog=ASP.NET;Integrated Security=True;";
        }
        public virtual List<UModel>? GetInfo()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    string command = $"SELECT * FROM {typeof(UModel).Name}";
                    var result = db.Query<UModel>(command).ToList();
                    db.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
