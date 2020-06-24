using System;
using System.Collections.Generic;

namespace TestTask.Model
{
    public partial class Posts
    {
        public Posts()
        {
            Users = new HashSet<Users>();
        }

        public Guid IdPost { get; set; }
        public string NamePost { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
