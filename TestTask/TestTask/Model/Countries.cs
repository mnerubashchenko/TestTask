using System;
using System.Collections.Generic;

namespace TestTask.Model
{
    public partial class Countries
    {
        public Countries()
        {
            Users = new HashSet<Users>();
        }

        public int IdCountry { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
