using System;
using System.Collections.Generic;
using System.Text;

namespace Achei.Client.Services.Domain.Entities {
    public class CityEntity {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StateID { get; set; }
        public virtual StateEntity State { get; set; }
    }
}
