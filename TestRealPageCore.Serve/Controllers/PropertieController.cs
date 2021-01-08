using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRealPageCore.Business.BL;
using TestRealPageCore.Business.BO;
using TestRealPageCore.Business.Configuracion.MsgAlert;
using TestRealPageCore.IC.DTO.Querys;
using TestRealPageCore.Serve.Models.Common;



namespace TestRealPageCore.Serve.Controllers
{
	[Produces("application/json")]
	[ApiController]
	public class PropertieController : ControllerBase
	{
		private readonly Lazy<PropertieBL> _propertieBL;

		#region constructor
		public PropertieController()
		{
			this._propertieBL = new Lazy<PropertieBL>();
		}
		#endregion
		#region method public
		[HttpGet("propertie/listpropertie")]
		public ActionResult<List<IPropertieQueryDTO>> ListPropertie()
		{
			return this._propertieBL.Value.ListPropertie();
		}

		[HttpPost("propertie/add")]
		public ActionResult<ResponseModel> AddPropertie([FromBody] PropertieBO propertie)
		{
			try
			{
				bool resultado = this._propertieBL.Value.AddPropertie(propertie);

				return StatusCode(StatusCodes.Status200OK, new ResponseModel()
				{
					IsSuccessfull = true,
					Message = resultado ? rscMessagesCommon.SuccessfulAdd : rscMessagesCommon.NotSuccessfulAdd,
					Result = resultado
				});
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
			}
		}

		[HttpPut("propertie/edit")]
		public ActionResult<ResponseModel> EditPropertie([FromBody] PropertieBO propertie)
		{
			try
			{
				bool resultado = this._propertieBL.Value.EditPropertie(propertie);

				return StatusCode(StatusCodes.Status200OK, new ResponseModel()
				{
					IsSuccessfull = true,
					Message = resultado ? rscMessagesCommon.SuccessfulEdit : rscMessagesCommon.NotSuccessfulEdit,
					Result = resultado
				});
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
			}
		}

		[HttpDelete("propertie/remove")]
		public ActionResult<ResponseModel> RemovePropertie(int id)
		{
			try
			{
				bool resultado = this._propertieBL.Value.DeletePropertie(id);

				return StatusCode(StatusCodes.Status200OK, new ResponseModel()
				{
					IsSuccessfull = true,
					Message = resultado ? rscMessagesCommon.SuccessfulDelete : rscMessagesCommon.NotSuccessfulDelete,
					Result = resultado
				});
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
			}
		}
		#endregion
	}
}
