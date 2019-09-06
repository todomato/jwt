using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT.Models
{
    public class JwtAuthObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime Expiration { get; set; }
    }
}