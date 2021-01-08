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

	public class UserController : ControllerBase
	{
		private readonly Lazy<UserBL> _userBL;

		#region constructor
		public UserController()
		{
			this._userBL = new Lazy<UserBL>();
		}
		#endregion
		#region method public
		// GET: api/<UserController>
		[HttpGet("user/listuser")]
		public ActionResult<List<IUserQueryDTO>> ListUser()
		{
			return this._userBL.Value.ListUser();
		}

		// POST api/<UserController>
		[HttpPost("user/add")]
		public ActionResult<ResponseModel> AddUser([FromBody] UserBO user)
		{
			try
			{
				bool resultado = this._userBL.Value.AddUser(user);

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

		// PUT api/<UserController>/5
		[HttpPut("user/edit")]
		public ActionResult<ResponseModel> EditUser([FromBody] UserBO user)
		{
			try
			{
				bool resultado = this._userBL.Value.EditUser(user);

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

		// DELETE api/<UserController>/5
		[HttpDelete("user/remove")]
		public ActionResult<ResponseModel> RemoveUser(int id)
		{
			try
			{
				bool resultado = this._userBL.Value.DeleteUser(id);

				return StatusCode(StatusCodes.Status200OK, new ResponseModel()
				{
					IsSuccessfull = true,
					Message = resultado ? rscMessagesCommon.NotSuccessfulDelete : rscMessagesCommon.NotSuccessfulDelete,
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
