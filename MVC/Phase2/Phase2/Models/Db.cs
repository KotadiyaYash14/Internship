using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phase2.Models
{
    public class Db
    {
        public static List<StudentList> StudentLists = new List<StudentList>() {
            new Models.StudentList {
                StudentId = 1,
                StudentFirstName = "Yash",
                StudentLastName = "Kotadiya",
                StudentAge = 21,
                StudentAddress = "Junagadh"
            }
        };
    }
}