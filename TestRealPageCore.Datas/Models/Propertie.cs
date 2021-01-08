using System;
using System.Collections.Generic;

#nullable disable

namespace TestRealPageCore.Datas.Models
{
    public partial class Propertie
    {
        public int IdPropertie { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal? Price { get; set; }
        public int? IdUser { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
