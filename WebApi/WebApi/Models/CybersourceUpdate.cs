namespace WebApi.Models
{
	using PaymentCwi.Models.Enum;

	/// <summary>
	/// The cybersource update.
	/// </summary>
	public class CybersourceUpdate
	{
		/// <summary>
		/// Gets or sets the anti fraud transaction id.
		/// </summary>
		public string AntiFraudTransactionId { get; set; }

		/// <summary>
		/// Gets or sets the merchant reference number.
		/// </summary>
		public string MerchantReferenceNumber { get; set; }

		/// <summary>
		/// Gets or sets the original decision.
		/// </summary>
		public FraudAnalysisStatusEnum OriginalDecision { get; set; }

		/// <summary>
		/// Gets or sets the new decision.
		/// </summary>
		public FraudAnalysisStatusEnum NewDecision { get; set; }

		/// <summary>
		/// Gets or sets the reviewer.
		/// </summary>
		public string Reviewer { get; set; }

		/// <summary>
		/// Gets or sets the reviewer comments.
		/// </summary>
		public string ReviewerComments { get; set; }

		/// <summary>
		/// Gets or sets the queue.
		/// </summary>
		public string Queue { get; set; }

		/// <summary>
		/// Gets or sets the profile.
		/// </summary>
		public string Profile { get; set; }
	}
}