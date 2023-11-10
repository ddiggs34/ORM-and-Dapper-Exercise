using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper;

//this emulates/represents the departments table that is in the SQL database
public class Department
    {
    
        //these represent the columns that are in the Departments
        public int DepartmentID { get; set; }
        public string Name { get; set; }

    }

