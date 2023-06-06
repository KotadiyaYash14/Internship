using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Repository
{
    public interface IStudentInterface
    {
        bool RegisterStudent(CustomStudent data, int? id);
        CustomStudent GetStudentById(int? id);
        List<StudentData> GetAllStudent();
        int DeleteStudent(int? id);
    }
}
