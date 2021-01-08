namespace TestRealPageCore.IC.DTO.Entitys
{
	using System;
	public interface IUserDTO
	{
		int IdUser { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		string Adress { get; set; }
		string Phone { get; set; }
		string Email { get; set; }
		bool? Active { get; set; }
		DateTime? Created { get; set; }
		DateTime? Modified { get; set; }
	}
}
