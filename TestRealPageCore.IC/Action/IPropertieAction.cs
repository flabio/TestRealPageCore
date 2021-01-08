namespace TestRealPageCore.IC.Action
{
	using System.Collections.Generic;
	using TestRealPageCore.IC.DTO.Entitys;
	using TestRealPageCore.IC.DTO.Querys;

	public interface IPropertieAction
	{
		bool AddPropertie(IPropertieDTO propertie);
		bool EditPropertie(IPropertieDTO propertie);
		bool DeletePropertie(int id);
		List<IPropertieQueryDTO> ListPropertie();
	}
}
