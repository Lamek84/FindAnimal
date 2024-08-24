using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool isMale { get; set; }
        public DateTime? birthday { get; set; }
        public string? street { get; set; }
        public string? houseNo { get; set; }
        public string? zipCode { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? description { get; set; }
        public string? PhoneNo { get; set; }
        public string? Mobil { get; set; }
        public string? Email { get; set; }
    }
}
