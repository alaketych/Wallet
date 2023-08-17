namespace Wallet.API.Models
{
	public class DtoResponse<TResult>
	{
		public string Error { get; set; }

		public TResult Result { get; set; }
	}

}
