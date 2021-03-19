using System;
using System.Collections.Generic;
using System.Text;

namespace Achei.Client.Services.Application.Configurations {
    public class AppConfiguration {
        public string PrincipalDomain { get; set; }
        public int ExpireTimeCacheSeconds { get; set; } 
        public int ExpireTimeCacheSecondsDefault { get; set; }
    }
}
