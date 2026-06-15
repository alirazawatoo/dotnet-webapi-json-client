using dotnet_test_project.Api;
using dotnet_test_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_test_project.BLL
{
    public class PeopleBLL
    {
        static readonly string url = "https://services.odata.org/TripPinRESTierService/People";
        public static async Task<People> GetPeoples()
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                People people = await response.Content.ReadAsAsync<People>();

                return people;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public static async Task<People> FilterPeople(string firstName)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url + $"?$filter=FirstName eq '{firstName}'");
            if (response.IsSuccessStatusCode)
            {
                People people = await response.Content.ReadAsAsync<People>();

                return people;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public static async Task<Person> GetSpecificPeople(string userName)
        {
            string uri = url + $"('{userName}')";
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Person people = await response.Content.ReadAsAsync<Person>();

                return people;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public static bool ValidInput(int option)
        {
            if (option == 1 || option == 2 || option == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
