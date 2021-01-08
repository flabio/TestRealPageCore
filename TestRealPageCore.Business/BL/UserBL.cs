namespace TestRealPageCore.Business.BL
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TestRealPageCore.Business.Configuracion.Entitys;
	using TestRealPageCore.Datas.DAL;
	using TestRealPageCore.IC.Action;
	using TestRealPageCore.IC.DTO.Entitys;
	using TestRealPageCore.IC.DTO.Querys;
	using TestRealPageCore.IC.Enuneration;

	public class UserBL : IUserAction
	{
		private readonly Lazy<UserDAL> _userDAL;

		#region constructor
		public UserBL()
		{
			this._userDAL = new Lazy<UserDAL>();
		}
		#endregion
		#region method public
		public bool AddUser(IUserDTO user)
		{
			this.UserValidateExist(user);
			this.UserValidateFields(user,ActionOp.Create);
			return this._userDAL.Value.AddUser(user);
		}

		public bool DeleteUser(int id)
		{
			return this._userDAL.Value.DeleteUser(id);
		}

		public bool EditUser(IUserDTO user)
		{
			this.UserValidateFields(user,ActionOp.Edit);
			return this._userDAL.Value.EditUser(user);
		}

		public List<IUserQueryDTO> ListUser()
		{
			return this._userDAL.Value.ListUser();
		}

		#endregion

		#region method private
		private void UserValidateExist(IUserDTO user)
		{
			List<IUserQueryDTO> result = this._userDAL.Value.ListUser();
			if (result.Where(x => x.Email == user.Email).Any())
			{
				throw new Exception(string.Format(FieldsRequired.AlreadyExist,"Email"));
			}
		}
		private void UserValidateFields(IUserDTO user, ActionOp action)
		{
			switch (action)
			{
				case ActionOp.Create:
					this.FieldsValidate(user);
					break;
				case ActionOp.Edit:
					if (user.IdUser == 0)
					{
						throw new Exception(string.Format(FieldsRequired.FieldRe,"Id"));
					}
					this.FieldsValidate(user);
					break;
			}
		}
		private void FieldsValidate(IUserDTO user)
		{
			if (user == null)
			{
				throw new Exception(string.Format(FieldsRequired.FieldsAreRequired));
			}
			if (string.IsNullOrEmpty(user.FirstName))
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "FirstName"));
			}
			if (string.IsNullOrEmpty(user.LastName))
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "LastName"));
			}
			if (string.IsNullOrEmpty(user.Adress))
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "Adress"));
			}
			if (string.IsNullOrEmpty(user.Phone))
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "Phone"));
			}
			if (string.IsNullOrEmpty(user.Email))
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "Email"));
			}
		}
		#endregion
	}
}
