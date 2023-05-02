using System;

namespace PracticeProject
{
    class Student
    {
        // Fildes
        public int studentId { get; set; }
        public string studentName { get; set; }
        public string studentAddress { get; set; }

        // Methods
        public void showDetalis()
        {
            Console.WriteLine("Student Detalis");
            Console.WriteLine("studentId : {0}, studentName : {1}, studentAddress : {2}", studentId, studentName, studentAddress);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine("Hello World!");

            // int data type
            int number = 10;
            Console.WriteLine(number);

            // string data type
            string name = "Yash";
            Console.WriteLine(name);

            // bool data type
            bool isValidate = true;
            Console.WriteLine(isValidate);

            // decalre array
            string[] Employee = { "Yash", "Chirag", "Bhavya", "Hemang","Vivek" };

            // array sort method
            Array.Sort(Employee);

            // loop through array using for loop
            for (int i = 0; i < Employee.Length; i++)
            {
                Console.WriteLine(Employee[i]);
            }
            Console.WriteLine(Employee[0]);

            // length method
            Console.WriteLine(Employee.Length);

            // loop through array using foreach loop
            // foreach(string i in Employee)
            // {
            //    Console.WriteLine(i);
            // }

            // Create student object
            Student st = new Student();
            st.studentId = 1;
            st.studentName = "Yash";
            st.studentAddress = "Junagadh";

            // call a method 
            st.showDetalis();

           // create a MyConstructor object
            MyConstructor.Program a = new MyConstructor.Program();

            // call a myMethod in Main method 
            a.myMethod();

            // create a calculator object
            Calculator c = new Calculator();

            // call a calc method in Main method
            c.Clac();

            // create a object of country, state and city
            Country c1 = new Country();
            State s = new State();
            City c2 = new City();

            // call a voting method in main method
            c1.voting();
            Console.WriteLine(c1.countryName + ":" + s.stateName + ":" + c2.cityName);

            Animal myAnimal = new Animal();  // Create a Animal object
            Cat myCat = new Cat();  // Create a Cat object
            Dog myDog = new Dog();  // Create a Dog object

            // call all method from the animal class
            myAnimal.animalSound();
            myCat.animalSound();
            myDog.animalSound();
        }
    }
}