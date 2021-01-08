namespace TestRealPageCore.IC.DTO.Entitys
{
	using System;
	public interface IPropertieDTO
	{
		int IdPropertie { get; set; }
		string Name { get; set; }
		string Location { get; set; }
		decimal? Price { get; set; }
		int? IdUser { get; set; }
		DateTime? Created { get; set; }
		DateTime? Modified { get; set; }
	}
}
