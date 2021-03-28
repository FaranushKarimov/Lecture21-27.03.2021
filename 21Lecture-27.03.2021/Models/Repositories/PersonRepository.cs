using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace _21Lecture_27._03._2021.Models.Repositories
{
    public class PersonRepository : Repository<Person>
    {

        public int? Insert(Person person)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    string command = $"INSERT INTO PERSON(LastName, FirstName, MiddleName) VALUES('{person.LastName}', '{person.FirstName}', '{person.MiddleName}')";
                    var result = db.Query<int>(command + " SELECT CAST(SCOPE_IDENTITY() as int)").FirstOrDefault();
                    db.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Person>? GetInfo(int ID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    string command = $"SELECT * FROM Person WHERE Id = {ID}";
                    var result = db.Query<Person>(command).ToList();
                    db.Close();
                    return result;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Person>? GetInfo(Person person)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    string command = $"SELECT * FROM Person WHERE Lastname = '{person.LastName}' and " +
                        $"Firstname = '{person.FirstName}' and " +
                        $"MiddleName = '{person.MiddleName}'";

                    var result = db.Query<Person>(command).ToList();
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
