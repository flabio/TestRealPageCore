using System;
using System.Collections.Generic;

#nullable disable

namespace TestRealPageCore.Datas.Models
{
    public partial class User
    {
        public User()
        {
            Properties = new HashSet<Propertie>();
        }

        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? Active { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual ICollection<Propertie> Properties { get; set; }
    }
}
