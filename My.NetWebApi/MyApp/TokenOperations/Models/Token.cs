using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.TokenOperations.Models
{
    public class Token
    {
        public string accesToken { get; set; } = null!;
        public DateTime expiration { get; set; }
        public string refreshToken { get; set; } = null!;
    }
}