using dotnet_test_project.BLL;
using dotnet_test_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_test_project.View
{
    public class PeopleView
    {
        public static void DisplayOptions()
        {
            Console.WriteLine("Please select from below");
            Console.WriteLine("1-Show Peoples");
            Console.WriteLine("2-Search People");
            Console.WriteLine("3-Show Details of Specific Person");
            Console.WriteLine("Press 1,2 or 3 from Above...");
            SelectOption();
        }
        public static void SelectOption()
        {
            int option;

            String input = Console.ReadLine();

            while (!Int32.TryParse(input, out option))
            {
                Console.WriteLine("Not a valid number, try again.");
                input = Console.ReadLine();
            }
            if (PeopleBLL.ValidInput(option))
            {
                if (option == 1)
                {
                    ShowAllPeoples();
                }
                else if (option == 2)
                {
                    SearchPeople();
                }
                else
                {
                    ShowSpecificPersonDetails();
                }
            }
            else
            {
                Console.WriteLine("Invalid Option");
            }
        }
        public static void ShowAllPeoples()
        {
            DisplayPeoples().GetAwaiter().GetResult();
        }
        public static void ShowSpecificPersonDetails()
        {
            Console.Write("Enter User Name : ");
            string userName = Console.ReadLine();
            DisplaySpecificPerson(userName).GetAwaiter().GetResult();
        }
        public static void SearchPeople()
        {
            Console.Write("Enter First Name : ");
            string firstName = Console.ReadLine();
            DisplaySearchPeople(firstName).GetAwaiter().GetResult();
        }
        static async Task DisplayPeoples()
        {
            try
            {
                People peoples = await PeopleBLL.GetPeoples();
                foreach (Person person in peoples.Value)
                {
                    DisplayPerson(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error is occured with exception {ex.Message}");
            }


        }
        public static async Task DisplaySpecificPerson(string userName)
        {
            try
            {
                Person person = await PeopleBLL.GetSpecificPeople(userName);
                if (person != null)
                {
                    DisplayDetailed(person);
                }
                else
                {
                    Console.WriteLine("No Record Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error is occured with exception {ex.Message}");
            }
        }
        public static async Task DisplaySearchPeople(string firstName)
        {
            try
            {
                People peoples = await PeopleBLL.FilterPeople(firstName);
                if (peoples.Value.Count > 0)
                {
                    foreach (Person person in peoples.Value)
                    {
                        DisplayPerson(person);
                    }
                }
                else
                {
                    Console.WriteLine("No Record Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error is occured with exception {ex.Message}");
            }
        }
        public static void DisplayPerson(Person person)
        {
            Console.WriteLine($"User Name : {person.UserName}");
            Console.WriteLine($"\tName : {person.FirstName} {person.LastName}");
            Console.WriteLine($"\tAge : {person.Age}");
            Console.Write($"\tEmail : ");
            person.Emails.ForEach(email => Console.Write($"{email} ,"));
            Console.WriteLine("");
        }
        public static void DisplayDetailed(Person person)
        {
            try
            {
                DisplayPerson(person);
                Console.WriteLine($"\tFavourite Feature : {person.Gender}");
                Console.WriteLine($"\tFavourite Feature : {person.FavoriteFeature}");
                Console.Write($"\tFeatures : ");
                person.Features.ForEach(feature => Console.Write($"{feature} ,"));
                Console.Write($"\n\tAddress : ");
                person.AddressInfo.ForEach(address => Console.Write($"{address.Address} ,"));
                if (person.HomeAddress != null)
                {
                    Console.WriteLine($"\tHome Address : {person.HomeAddress.Address}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error is occured with exception {ex.Message}");
            }
        }
    }
}
