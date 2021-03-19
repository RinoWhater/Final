using System;
using System.Collections.Generic;
using System.Text;

namespace Achei.Client.Services.Domain.Entities {
    public class AddressEntity {
        public int ID { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public int CityID { get; set; }

        public virtual CityEntity City { get; set; }
    }
}
