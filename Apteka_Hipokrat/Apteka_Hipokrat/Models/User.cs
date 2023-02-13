using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace Apteka_Hipokrat.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public ICollection<Shopping> Shoppings { get; set; }
    }
}
