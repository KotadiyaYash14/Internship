using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Helper.SignUpHelper
{
    public class StudentHelper
    {
        public StudentData ConvertCustomStudentToStudent(CustomStudent data)
        {
            StudentData sd = new StudentData() 
            { 
                StudentId = data.StudentId,
                StudentName = data.StudentName,
                StudentEmail = data.StudentEmail,
                StuentPhone = data.StuentPhone,
                StudentDOB = Convert.ToDateTime(data.StudentDOB),
                StudentGender = data.StudentGender,
                StudentAddress = data.StudentAddress,
                StudentCountry = data.StudentCountry,
                StudentState = data.StudentState,
                StudentCity = data.StudentCity
            };
            return sd;
        }

        public CustomStudent ConvertStudentToCustomStudent(StudentData data)
        {
            CustomStudent cs = new CustomStudent()
            {
                StudentId = data.StudentId,
                StudentName = data.StudentName,
                StudentEmail = data.StudentEmail,
                StuentPhone = data.StuentPhone,
                StudentDOB = data.StudentDOB,
                StudentGender = data.StudentGender,
                StudentAddress = data.StudentAddress,
                StudentCountry = (int)data.StudentCountry,
                StudentState = (int)data.StudentState,
                StudentCity = (int)data.StudentCity
            };
            return cs;
        }
    }
}
