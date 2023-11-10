using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ORM_Dapper
{

    //inherits from the IDepartment repo - means that it follows the rules of having to GET ALL the departments and INSERT a new department
    //BUT in order to do it, you HAVE to have a connection to the database (IDbConnection)
    public class DepartmentRepo : IDepartmentRepo

        
    {
        private readonly IDbConnection _connection;

        //this makes it so that the user has to give a database and the department repo wont work unless they give it 
        public DepartmentRepo(IDbConnection connection)
        {
            _connection = connection;
        }
        //IEnumerable is a list
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments;");
        }

       
        public void InsertDepartment(string newName)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@newName)",
                new { newName });
        }
        public void DeleteDepartment(int id) 
        {
          _connection.Execute("DELETE FROM departments WHERE DepartmentID = @id", new { id });
        }
    }
}
