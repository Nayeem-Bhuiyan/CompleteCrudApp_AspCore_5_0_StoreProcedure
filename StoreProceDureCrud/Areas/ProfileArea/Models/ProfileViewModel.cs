using Microsoft.AspNetCore.Http;
using StoreProceDureCrud.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProceDureCrud.Areas.ProfileArea.Models
{
    public class ProfileViewModel
    {
        public int? ProfileId { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string websiteLink { get; set; }
        public string Password { get; set; }
        public string genderName { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public string countryName { get; set; }
        public string cityName { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string ProfileImage { get; set; }
        public IFormFile ImageUrl { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string Remarks { get; set; }
        public string StatementType { get; set; }


        public virtual Profile profile { get; set; }
        public virtual IEnumerable<Profile> profiles { get; set; }
        public virtual IEnumerable<Gender> genders { get; set; }
        public virtual IEnumerable<City> cities { get; set; }
        public virtual IEnumerable<Hobby> Hobbies { get; set; }
        public virtual IEnumerable<FavouriteHobby> favouriteHobbies { get; set; }
    }
}
