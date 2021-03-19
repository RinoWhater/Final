using Achei.Client.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achei.Client.Services.Domain2.Entities {
    public class ClientEntity {
        public int ID { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }
        public int AddressID { get; set; }
        public AddressEntity Address { get; set; }
    }
}
