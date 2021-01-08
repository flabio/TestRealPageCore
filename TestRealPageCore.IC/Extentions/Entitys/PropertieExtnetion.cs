namespace TestRealPageCore.IC.Extentions.Entitys
{
	using System;
	using TestRealPageCore.IC.DTO.Entitys;
	public static class PropertieExtnetion
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TR"></typeparam>
		/// <param name="origin"></param>
		/// <returns></returns>
		public static TR MapeadorPropertie<TR>(this IPropertieDTO origin) where TR : IPropertieDTO, new()
		{
			return origin.MapeadorPropertie(new TR());
		}
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TR"></typeparam>
		/// <param name="origin"></param>
		/// <param name="destination"></param>
		/// <returns></returns>
		public static TR MapeadorPropertie<TR>(this IPropertieDTO origin, TR destination) where TR : IPropertieDTO, new()
		{
			if (destination == null)
			{
				destination = default(TR);
			}
			else
			{
				if (destination == null)
				{
					destination = new TR();
				}
				else
				{
					destination.Name = origin.Name;
					destination.Location = origin.Location;
					destination.Price = origin.Price;
					destination.IdUser = origin.IdUser;
					if (origin.IdPropertie > 0)
					{
						destination.Modified = DateTime.Now;
					}
					else
					{
						destination.Created = DateTime.Now;
					}
				}
			}
			return destination;
		}
	}
}
