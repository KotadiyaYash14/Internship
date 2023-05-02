using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProject
{
    class MyConstructor 
    { 
            // create a fildes
            public int studentId { get; set; }
            public string studentName { get; set; }
            public string studentAddress { get; set; }

            // create default student constructor
            public MyConstructor()
            {
                studentAddress = "Junagadh";
            }

            // create parameterized constructor
            public MyConstructor(int studentId, string studentName, string studentAddress)
            {
                this.studentId = studentId;
                this.studentName = studentName;
                this.studentAddress = studentAddress;
            }
            public class Program
            {
               public void myMethod()
                {
                // MyConstructor mc = new  MyConstructor();
                // Console.WriteLine("studentId : {0}, studentName : {1}, studentAddress : {2}", mc.studentId, mc.studentName, mc.studentAddress);

                MyConstructor mc = new MyConstructor(2, "Chirag", "Siddhpur");
                Console.WriteLine("studentId : {0}, studentName : {1}, studentAddress : {2}", mc.studentId, mc.studentName, mc.studentAddress);
                }
            }
    }
}
