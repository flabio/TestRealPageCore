namespace TestRealPageCore.IC.DTO.Common
{
	public interface IResponseDTO
	{
		bool IsSuccessfull{ get; set; }

		string Message { get; set; }

		object Result { get; set; }
	}
}
