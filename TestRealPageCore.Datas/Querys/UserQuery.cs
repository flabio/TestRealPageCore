namespace TestRealPageCore.Datas.Querys
{
	using System;
	using TestRealPageCore.IC.DTO.Querys;
	public class UserQuery : IUserQueryDTO
	{
		public int IdUser { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Adress { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public bool? Active { get; set; }
		public DateTime? Created { get; set; }
		public DateTime? Modified { get; set; }
	}
}
