using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProject
{
   // Inheritance
    class Country // parent class
    {
        public string countryName = "India"; // create filed

        public void voting()  // create method
        {
            Console.WriteLine("voting");
        }
    }
    class State : Country // child class
    {
        public string stateName = "Gujarat"; // create filed
    }
    class City : State // child class
    {
        public string cityName = "Junagadh"; // create filed
    }
}
