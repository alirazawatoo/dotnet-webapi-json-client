using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_test_project.Models
{
    public class Person
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public Int64? Age { get; set; }
        public decimal Cost { get; set; }
        public List<string> Emails { get; set; }
        public string FavoriteFeature { get; set; }
        public List<string> Features { get; set; }
        public List<Location> AddressInfo { get; set; }
        public Location HomeAddress { get; set; }
    }

}
