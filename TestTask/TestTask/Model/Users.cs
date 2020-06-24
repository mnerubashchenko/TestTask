using System;
using System.Collections.Generic;

namespace TestTask.Model
{
    public partial class Users
    {
        public Guid IdUser { get; set; }
        public string NameUser { get; set; }
        public string SurnameUser { get; set; }
        public string LastnameUser { get; set; }
        public Guid? PostId { get; set; }
        public Guid DepId { get; set; }
        public decimal? TelUser { get; set; }
        public string NationalityUser { get; set; }

        public virtual Departaments Dep { get; set; }
        public virtual Posts Post { get; set; }
    }
}
