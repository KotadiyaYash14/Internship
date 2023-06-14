using SchoolManagement_340.Helper.SignUpHelper;
using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Services
{
    public class StudentServices : IStudentInterface
    {
        SchoolManagement_yk_340Entities db = new SchoolManagement_yk_340Entities();
        StudentHelper sh = new StudentHelper();

        public int DeleteStudent(int? id)
        {
           if(db.StudentData.Any(x => x.StudentId == id))
            {
                db.sp_delete_student(id);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<StudentData> GetAllStudent()
        {
           var success = db.StudentData.ToList();
           return success;
        }

        public CustomStudent GetStudentById(int? id)
        {
            StudentData sd = db.StudentData.Where(x => x.StudentId == id).FirstOrDefault();
            CustomStudent cs = sh.ConvertStudentToCustomStudent(sd);
            return cs;
        }

        public bool RegisterStudent(CustomStudent data, int? id)
        {
            if(data != null)
            {
                if(id == 0)
                {
                    db.sp_add_edit_student(0, data.StudentName, data.StudentEmail, data.StuentPhone, Convert.ToDateTime(data.StudentDOB), data.StudentGender, data.StudentAddress, data.StudentCountry, data.StudentState, data.StudentCity);
                    return true;
                }
                else
                {
                    db.sp_add_edit_student(data.StudentId, data.StudentName, data.StudentEmail, data.StuentPhone, Convert.ToDateTime(data.StudentDOB), data.StudentGender, data.StudentAddress, data.StudentCountry, data.StudentState, data.StudentCity);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
