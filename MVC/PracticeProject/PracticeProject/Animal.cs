using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProject
{
    class Animal // Parent class 
    {
        public virtual void animalSound()
        {
            Console.WriteLine("The animal makes a sound");
        }
    }
    class Cat : Animal  // Derived class (child) 
    {
        public override void animalSound()
        {
            Console.WriteLine("The pig says: meow meow");
        }
    }

    class Dog : Cat  // Derived class (child) 
    {
        public override void animalSound()
        {
            Console.WriteLine("The dog says: bow wow");
        }
    }

}