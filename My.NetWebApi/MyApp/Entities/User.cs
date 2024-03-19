using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string surName { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
        public string? refreshToken { get; set; }
        public DateTime? refreshTokenExpireDate { get; set; }
    }
}