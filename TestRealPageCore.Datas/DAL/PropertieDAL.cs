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

	public class PropertieDAL : IPropertieAction
	{
		#region Method public
		public bool AddPropertie(IPropertieDTO propertie)
		{
			bool result = false;
			using (RealPageDBContext context = new RealPageDBContext())
			{
				using (var transation = context.Database.BeginTransaction())
				{
					try
					{
						Propertie newPropertie = new Propertie();
						newPropertie = propertie.MapeadorPropertie<Propertie>();
						context.Properties.Add(newPropertie);
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

		public bool DeletePropertie(int id)
		{
			bool result = false;
			using (RealPageDBContext context = new RealPageDBContext())
			{
				using (var transation = context.Database.BeginTransaction())
				{
					try
					{
						Propertie deletePropertie = context.Properties.Find(id);
						context.Properties.Remove(deletePropertie);
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

		public bool EditPropertie(IPropertieDTO propertie)
		{
			bool result = false;
			using (RealPageDBContext context = new RealPageDBContext())
			{
				using (var transation = context.Database.BeginTransaction())
				{
					try
					{
						Propertie editPropertie = context.Properties.Find(propertie.IdPropertie);
						editPropertie = propertie.MapeadorPropertie<Propertie>(editPropertie);
						context.Properties.Update(editPropertie);
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

		public List<IPropertieQueryDTO> ListPropertie()
		{
			List<IPropertieQueryDTO> result = new List<IPropertieQueryDTO>();
			using (RealPageDBContext context = new RealPageDBContext())
			{
				try
				{
					result = (from p in context.Properties
							  select new PropertieQuery()
							  {
								  IdPropertie = p.IdPropertie,
								  Name = p.Name,
								  Location = p.Location,
								  Price = p.Price,
								  IdUser = p.IdUser
							  }).ToList<IPropertieQueryDTO>();
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
