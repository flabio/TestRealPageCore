namespace TestRealPageCore.IC.DTO.Querys
{
	using System;
	interface IPropertieQueryDTO
	{
		int IdPropertie { get; set; }
		string Name { get; set; }
		string Location { get; set; }
		decimal? Price { get; set; }
		int? IdUser { get; set; }
		string FullNameUser { get; set; }
		DateTime? Created { get; set; }
		DateTime? Modified { get; set; }
	}
}
