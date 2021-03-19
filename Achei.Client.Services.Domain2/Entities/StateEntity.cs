using System;
using System.Collections.Generic;
using System.Text;

namespace Achei.Client.Services.Domain.Entities {
    public class StateEntity {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public int CountryID { get; set; }
        public virtual CountryEntity Country { get; set; }
    }
}
