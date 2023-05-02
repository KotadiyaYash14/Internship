using System;
using System.Linq;

namespace Loops
{
    class Loops
    {
        
       static void Main(string[] args)
        {
            int n,sum=0;
         Console.Write("Input the number of elements to store in the array :");
            n = Convert.ToInt32(Console.ReadLine());
            int[] answer = new int[n];
            Console.WriteLine("Enter Element ");
            for (int i = 0; i < n; i++)
            {
                answer[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("array - ");
               
                for (int j = 0; j <= i; j++)
                {
                    
                    Console.WriteLine(answer[j]);

                }
                if (i < (n-1)) { 
                    Console.WriteLine("Enter Element "); 
                }
            }
            for (int i = 0; i < n; i++)
            {
                sum += answer[i];
            }

            Console.Write("Sum of all elements stored in the array is : {0} \n", sum);


            Console.WriteLine("Enter day of Week : ");
            int day = Convert.ToInt32(Console.ReadLine());
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday is First day of Week \n");
                    break;
                case 2:
                    Console.WriteLine("Tuesday is Second day of Week \n");
                    break;
                case 3:
                    Console.WriteLine("Wednesday is Third day of Week \n");
                    break;
                case 4:
                    Console.WriteLine("Thursday is Fourth day of Week \n");
                    break;
                case 5:
                    Console.WriteLine("Friday is Fifth day of Week \n");
                    break;
                case 6:
                    Console.WriteLine("Saturday is Sixth day of Week \n");
                    break;
                case 7:
                    Console.WriteLine("Sunday is Seventh day of Week \n");
                    break;
                default:
                    Console.WriteLine("Invalid Input. \n");
                   
                    break;
            }
            
            var list = new[]
        {
            new { Number = 10, Name = "Smith" },
            new { Number = 1, Name = "John" }
         }.ToList();

            while (true)
            {
                
                Console.WriteLine("0.Enter 0 to Exit");
                Console.WriteLine("1.Enter 0 to show Data");
                Console.WriteLine("2.Enter 0 to add Data");
                Console.WriteLine("3.Enter 0 to delte Data");

                string press = (Console.ReadLine());
                if (press != "1" && press != "2" && press != "3" && press != "0")
                {
                    Console.WriteLine("Enter Valid Number");
                }
                else if (press == "1")
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (press == "2")
                {
                    Console.WriteLine("Enter Number");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Name");
                    string name = (Console.ReadLine());
                    list.Add(new { Number = number, Name = name });
                }
                else if (press == "3")
                {
                    Console.WriteLine("Enter Number");
                    int digit = Convert.ToInt32(Console.ReadLine());
                    list.RemoveAll(list => list.Number == digit);

                }
                else if (press == "0")
                {
                    Environment.Exit(0);
                }
                
            }
        }
    }
}
