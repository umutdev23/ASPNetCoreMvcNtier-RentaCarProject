using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace RentACar_Entity.Entities
{
    public class CustomerUser : IdentityUser<int>
    {
        public int Id {  get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        
        public DateTime BirthDay { get; set; }
        public int LicenceYear { get; set; }
        public string IdentityNumber { get; set; }

    }
}
