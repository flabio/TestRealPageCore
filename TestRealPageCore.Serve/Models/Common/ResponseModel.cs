namespace TestRealPageCore.Serve.Models.Common
{
	using TestRealPageCore.IC.DTO.Common;
	public class ResponseModel : IResponseDTO
	{
		public ResponseModel()
		{
			this.IsSuccessfull = false;
			this.Result = null;
		}

		public bool IsSuccessfull { get; set; }
		public string Message { get; set; }
		public object Result { get; set; }
	}
}
