namespace TestRealPageCore.Datas.Querys
{
	using System;
	using TestRealPageCore.IC.DTO.Querys;
	public class PropertieQuery : IPropertieQueryDTO
	{
		public int IdPropertie { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public decimal? Price { get; set; }
		public int? IdUser { get; set; }
		public string FullNameUser { get; set; }
		public DateTime? Created { get; set; }
		public DateTime? Modified { get; set; }
	}
}
