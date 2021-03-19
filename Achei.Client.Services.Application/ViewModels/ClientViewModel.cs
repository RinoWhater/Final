using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Achei.Client.Services.Application.ViewModels {
    public class ClientViewModel {
        public int ID { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Required]
        public int? AddressID { get; set; }
        [Required]
        public int? CityID { get; set; }
        [Required]
        public int? StateID { get; set; }
        [Required]
        public int? CountryID { get; set; }
    }
}
