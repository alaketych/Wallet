namespace Wallet.Domain.Entities
{
	public enum OperationType
	{
		/// <summary>
		/// Card top-up
		/// </summary>
		Payment,

		/// <summary>
		/// Spending from the card
		/// </summary>
		Credit
	}
}
