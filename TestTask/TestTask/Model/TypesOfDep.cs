using System;
using System.Collections.Generic;

namespace TestTask.Model
{
    public partial class TypesOfDep
    {
        public TypesOfDep()
        {
            Departaments = new HashSet<Departaments>();
        }

        public Guid IdType { get; set; }
        public string NameType { get; set; }

        public virtual ICollection<Departaments> Departaments { get; set; }
    }
}
