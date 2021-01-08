namespace TestRealPageCore.IC.Action
{
	using System.Collections.Generic;
	using TestRealPageCore.IC.DTO.Entitys;
	using TestRealPageCore.IC.DTO.Querys;

	public interface IUserAction
	{
		bool AddUser(IUserDTO user);
		bool EditUser(IUserDTO user);
		bool DeleteUser(int id);
		List<IUserQueryDTO> ListUser();
	}
}
