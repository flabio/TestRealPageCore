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

	public class PropertieBL : IPropertieAction
	{
		private readonly Lazy<PropertieDAL> _propertieDAL;

		#region Constructor
		public PropertieBL()
		{
			this._propertieDAL = new Lazy<PropertieDAL>();
		}
		#endregion
		#region Method public
		public bool AddPropertie(IPropertieDTO propertie)
		{
			this.PropertieValidateExist(propertie);
			this.PropertieValidateFields(propertie, ActionOp.Create);
			return this._propertieDAL.Value.AddPropertie(propertie);
		}
		public bool DeletePropertie(int id)
		{
			return this._propertieDAL.Value.DeletePropertie(id);
		}
		public bool EditPropertie(IPropertieDTO propertie)
		{
			this.PropertieValidateFields(propertie, ActionOp.Create);
			return this._propertieDAL.Value.EditPropertie(propertie);
		}
		public List<IPropertieQueryDTO> ListPropertie()
		{
			return this._propertieDAL.Value.ListPropertie();
		}
		#endregion
		#region Method private
		private void PropertieValidateExist(IPropertieDTO propertie)
		{
			List<IPropertieQueryDTO> result = this._propertieDAL.Value.ListPropertie();
			if (result.Where(x => x.Name == propertie.Name).Any())
			{
				throw new Exception(string.Format(FieldsRequired.AlreadyExist,"Name"));
			}
		}
		private void PropertieValidateFields(IPropertieDTO propertie, ActionOp action)
		{
			switch (action)
			{
				case ActionOp.Create:
					this.FieldsValidate(propertie);
					break;
				case ActionOp.Edit:
					if (propertie.IdPropertie == 0)
					{
						throw new Exception(string.Format(FieldsRequired.FieldRe,"Id"));
					}
					this.FieldsValidate(propertie);
					break;
			}
		}
		private void FieldsValidate(IPropertieDTO propertie)
		{
			if (propertie == null)
			{
				throw new Exception(string.Format(FieldsRequired.FieldsAreRequired));
			}
			if (propertie.Name == null)
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "Name"));
			}
			if (propertie.Location == null)
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "Location"));
			}
			if (propertie.Price == null)
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "Price"));
			}
			if (propertie.IdUser == null)
			{
				throw new Exception(string.Format(FieldsRequired.FieldRe, "owner"));
			}
		}
		#endregion
	}
}
