using System;


namespace University_hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to our university database");
            while (true)
            {
                Console.WriteLine("1. Give a grade to student"
                    + "\n2. Look at student's information"
                        + " \n3. Rating by GPA"
                            + "\n4. Save information about students in txt");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Write name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Write surname");
                        string surname = Console.ReadLine();
                        /*if ( after business logic add checher if there is any student with such a name and then give grade ){
                            Console.WriteLine("Give grade for this student);
                            int grade = Console.ReadLine();
                            // Here I should implement something to save data in database
                        }
                        else if (){
                            Console.WriteLine("There is no such a student);
                        }*/
                        break;

                }
            }
        }
        }
    }

