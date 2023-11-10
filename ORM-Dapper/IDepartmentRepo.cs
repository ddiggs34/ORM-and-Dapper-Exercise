using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    
    public interface IDepartmentRepo
    {
        //this makes it so we can see the list of departments and also so we can MAKE a department (and name it with the STRING newName)
        public IEnumerable<Department> GetAllDepartments();
        public void InsertDepartment(string newName);
    }
}
