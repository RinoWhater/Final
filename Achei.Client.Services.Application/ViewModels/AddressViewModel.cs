using System;
using System.Collections.Generic;
using System.Text;

namespace Achei.Client.Services.Application.ViewModels {
    public class AddressViewModel { 
        public int ID { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
