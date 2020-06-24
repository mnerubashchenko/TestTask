using System;
using System.Collections.Generic;

namespace TestTask.Model
{
    public partial class Departaments
    {
        public Departaments()
        {
            Users = new HashSet<Users>();
        }

        public Guid IdDep { get; set; }
        public string FullNameDep { get; set; }
        public string ShortNameDep { get; set; }
        public Guid? TypeId { get; set; }

        public virtual TypesOfDep Type { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
