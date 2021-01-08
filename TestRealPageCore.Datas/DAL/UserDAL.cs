namespace TestRealPageCore.Datas.DAL
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TestRealPageCore.Datas.Models;
	using TestRealPageCore.Datas.Querys;
	using TestRealPageCore.IC.Action;
	using TestRealPageCore.IC.DTO.Entitys;
	using TestRealPageCore.IC.DTO.Querys;
	using TestRealPageCore.IC.Extentions.Entitys;

	public class UserDAL : IUserAction
	{
		#region method public
		public bool AddUser(IUserDTO user)
		{
			bool result = false;
			using (RealPageDBContext context = new RealPageDBContext())
			{
				using (var transation = context.Database.BeginTransaction())
				{
					try
					{
						User newUser = new User();
						newUser = user.MapeadorUser<User>();
						context.Users.Add(newUser);
						context.SaveChanges();
						transation.Commit();
						result = true;
					}
					catch (Exception ex)
					{
						transation.Rollback();
						throw new Exception(ex.Message);
					}
				}
			}
			return result;
		}

		public bool DeleteUser(int id)
		{
			bool result = false;
			using (RealPageDBContext context = new RealPageDBContext())
			{
				using (var transation = context.Database.BeginTransaction())
				{
					try
					{
						User deleteUser = context.Users.Find(id);
						context.Users.Remove(deleteUser);
						context.SaveChanges();
						transation.Commit();
						result = true;
					}
					catch (Exception ex)
					{
						transation.Rollback();
						throw new Exception(ex.Message);
					}
				}

			}
			return result;
		}

		public bool EditUser(IUserDTO user)
		{
			bool result = false;
			using (RealPageDBContext context = new RealPageDBContext())
			{
				using (var transation = context.Database.BeginTransaction())
				{
					try
					{
						User editUser = context.Users.Find(user.IdUser);
						editUser = user.MapeadorUser<User>(editUser);
						context.Users.Update(editUser);
						context.SaveChanges();
						transation.Commit();
						result = true;
					}
					catch (Exception ex)
					{
						transation.Rollback();
						throw new Exception(ex.Message);
					}
				}

			}
			return result;
		}

		public List<IUserQueryDTO> ListUser()
		{
			List<IUserQueryDTO> result = new List<IUserQueryDTO>();
			using (RealPageDBContext context = new RealPageDBContext())
			{

				try
				{
					result = (from u in context.Users
							  select new UserQuery()
							  {
								  IdUser = u.IdUser,
								  FirstName = u.FirstName,
								  LastName = u.LastName,
								  Adress = u.Adress,
								  Phone = u.Phone,
								  Email = u.Email,
								  Active = u.Active

							  }).ToList<IUserQueryDTO>();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
			return result;
		}
		#endregion
	}
}
