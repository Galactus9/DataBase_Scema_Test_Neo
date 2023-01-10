using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class Candidate
    {
        public int Id { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public string Gender { get; set; }
        public string NativeLanguage { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoIdType { get; set; }
        public string PhotoIdNumber { get; set; }
        public DateTime PhotoIdIssueDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int? PostalCode { get; set; }
        public string Country { get; set; }
        public string LandlineNumber { get; set; }
        public string MobileNumber { get; set; }
    }
}