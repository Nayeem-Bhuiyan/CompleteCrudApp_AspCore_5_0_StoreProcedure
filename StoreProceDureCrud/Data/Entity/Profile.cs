using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProceDureCrud.Data.Entity
{
    public class Profile
    {
        public int? ProfileId { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string websiteLink { get; set; }
        public string Password { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string ProfileImage { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string Remarks { get; set; }
    }
}
