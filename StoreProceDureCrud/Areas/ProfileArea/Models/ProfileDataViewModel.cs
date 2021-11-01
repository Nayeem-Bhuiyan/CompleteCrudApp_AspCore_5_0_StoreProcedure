using StoreProceDureCrud.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProceDureCrud.Areas.ProfileArea.Models
{
    public class ProfileDataViewModel
    {
        public IEnumerable<ProfileViewModel> profileViewModels { get; set; }
        public IEnumerable<Country> countries { get; set; }
        public IEnumerable<Gender> genders { get; set; }
        public IEnumerable<Hobby> hobbies { get; set; }
    }
}
