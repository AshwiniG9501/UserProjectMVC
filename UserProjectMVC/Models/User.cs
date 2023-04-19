using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace UserProjectMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }  
        public string Number { get; set; }
        public int CityId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public List<User> Users { get; set; }


    }
}