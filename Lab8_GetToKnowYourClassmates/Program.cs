//Mina Stanton
//Jauary 28, 2020
//Program description: This program will output student data based on the user selection. It will recognize
// invalid user inputs when the user requests information about students in a class.

using System;

namespace Lab8_GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            //data stored in string array of student data
            string[] studentNames = { "John", "Jane", "Jack", "Jill", "Jim" };
            string[] city = { "West Bloomfield", "Royal Oak", "Birmingham", "Bloomfield Hills", "Detroit" };
            string[] favAnimal = { "Dog", "Cat", "Horse", "Turtle", "Llama" };
            string[] favDrink = { "Dark and Stormy", "Moscow Mule", "Margarita", "Martini with extra olives", "Frose" };
            string[] horoscope = { "Libra", "Scorpio", "Cancer", "Virgo", "Capricorn" };
            //greeting user 
            Console.WriteLine("Hello and welcome to our class! You can find out more about the following students:");
            //utilizing a while loop so the user can continue to find out about different students
            bool userContinue = true;
            while (userContinue)
            {
                PrintNames(studentNames);//printing off the names of the students for selection
                //prompting user to select a number or write out the name
                int userSelect = ValidateSelection(studentNames, "Enter the number or write the name of the student you would like to find out more about: (exp. 5 or type Jim) ");
                //sending data to method to print the information the user selected to view
                PrintInfoSelected(studentNames[userSelect], city[userSelect], favAnimal[userSelect], favDrink[userSelect], horoscope[userSelect]);
                //prompting the user to select another student
                Console.WriteLine("Would you like to select another student? (y/n)");
                string userInput = Console.ReadLine().ToLower();
                while (userInput != "y" && userInput != "n")
                {
                    Console.WriteLine("Please enter (y) to continue or (n) to exit.");
                    userInput = Console.ReadLine().ToLower();
                }
                //if the user doesn't want to continue then it will exit the while loop
                if (userInput == "n")
                {
                    break;
                }
            }
            Console.WriteLine("Thanks for visiting!");
        }

        //this method will get input for the user and return it as a string
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        //This method will print out the elements in a string array
        public static void PrintNames(string[] output)
        {
            int j = 1;
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine($"{j}. {output[i]}");
                j++;
            }
        }

        //This method validates the selection of the user
        public static int ValidateSelection(string[] array, string message)
        {
            int userSelectedNum = 0;
            bool correct = true;
            while (correct)
            {
                try
                {
                    string userStudentSelected = GetUserInput(message);

                    if (userStudentSelected == array[0])
                    {
                        userSelectedNum = 0;
                    }
                    else if (userStudentSelected == array[1])
                    {
                        userSelectedNum = 1;
                    }
                    else if (userStudentSelected == array[2])
                    {
                        userSelectedNum = 2;
                    }
                    else if (userStudentSelected == array[3])
                    {
                        userSelectedNum = 3;
                    }
                    else if (userStudentSelected == array[4])
                    {
                        userSelectedNum = 4;
                    }
                    else
                    {
                        userSelectedNum = int.Parse(userStudentSelected) - 1;
                        Console.WriteLine("You selected: " + array[userSelectedNum]);
                    }
                    correct = false;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("That was an invalid numeric entry!");
                    correct = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please type the name exactly as written!");
                    correct = true;
                }
            }
            return userSelectedNum;
        }

        public static void PrintInfoSelected(string name, string city, string favAnimal, string favDrink, string horoscope)
        {
            bool invalid = true;
            while (invalid)
            {
                invalid = false;
                string userSelect = GetUserInput("What would you like to know? (Enter \"city\", \"favorite animal\", \"favorite drink\" or \"birth sign\") ");
                if (userSelect == "city")
                {
                    Console.WriteLine($"{name}, lives in {city}.");
                }
                else if (userSelect == "favorite animal")
                {
                    Console.WriteLine($"{name}, favorite animal is {favAnimal}.");
                }
                else if (userSelect == "favorite drink")
                {
                    Console.WriteLine($"{name}, favorite drink is {favDrink}.");
                }
                else if (userSelect == "birth sign")
                {
                    Console.WriteLine($"{name}, is a {horoscope}.");
                }
                else
                {
                    Console.WriteLine("Invalid entry");
                    invalid = true; 
                }

                Console.WriteLine($"Would you like to know more about {name}? (y/n)");
                string userInput = Console.ReadLine().ToLower();
                while (userInput != "y" && userInput != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter (y) to continue or (n) to exit.");
                    userInput = Console.ReadLine().ToLower();
                }
                invalid = true; 
                //if the user doesn't want to continue then it will exit the while loop
                if (userInput == "n")
                {
                    break;
                }
            }
        }
    }
}
