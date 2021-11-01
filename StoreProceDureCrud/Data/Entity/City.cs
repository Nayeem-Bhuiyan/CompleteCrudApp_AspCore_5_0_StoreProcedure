using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProceDureCrud.Data.Entity
{
    public class City
    {
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public int? CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}
