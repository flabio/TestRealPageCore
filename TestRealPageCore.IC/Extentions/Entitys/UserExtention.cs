namespace TestRealPageCore.IC.Extentions.Entitys
{
	using System;
	using TestRealPageCore.IC.DTO.Entitys;
	public static class UserExtention
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TR"></typeparam>
		/// <param name="origin"></param>
		/// <returns></returns>
		public static TR MapeadorUser<TR>(this IUserDTO origin) where TR : IUserDTO, new()
		{
			return origin.MapeadorUser(new TR());
		}
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TR"></typeparam>
		/// <param name="origin"></param>
		/// <param name="destination"></param>
		/// <returns></returns>
		public static TR MapeadorUser<TR>(this IUserDTO origin, TR destination) where TR : IUserDTO, new()
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
					destination.FirstName = origin.FirstName;
					destination.LastName = origin.LastName;
					destination.Adress = origin.Adress;
					destination.Phone = origin.Phone;
					destination.Email = origin.Email;
					destination.Active = origin.Active;
					if (origin.IdUser > 0)
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
