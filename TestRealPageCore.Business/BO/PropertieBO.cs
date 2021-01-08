namespace TestRealPageCore.Business.BO
{
	using System;
	using TestRealPageCore.IC.DTO.Entitys;
	public class PropertieBO : IPropertieDTO
	{
		public int IdPropertie { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public decimal? Price { get; set; }
		public int? IdUser { get; set; }
		public DateTime? Created { get; set; }
		public DateTime? Modified { get; set; }
	}
}
