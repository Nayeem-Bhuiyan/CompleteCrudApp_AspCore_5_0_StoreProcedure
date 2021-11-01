using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProceDureCrud.Data.Entity
{
    public class FavouriteHobby
    {
        public int? FavouriteHobbyId { get; set; }
        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public int? HobbyId { get; set; }
        public virtual Hobby Hobby { get; set; }
    }
}
