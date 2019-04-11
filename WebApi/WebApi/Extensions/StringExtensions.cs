namespace WebApi.Extensions
{
	using PaymentCwi.Models.Enum;
	using ServiceStack;

	/// <summary>
	/// The string extension.
	/// </summary>
	public static class StringExtension
	{
		/// <summary>The convert to anti fraud enum.</summary>
		/// <param name="_this">The string to convert.</param>
		/// <returns>The FraudAnalysisStatusEnum or null.</returns>
		public static FraudAnalysisStatusEnum? ConvertToAntiFraudEnum(this string _this)
		{
			if (_this == null)
			{
				return null;
			}

			if (System.Enum.TryParse<FraudAnalysisStatusEnum>(_this.ToLower().ToTitleCase(), out var result))
			{
				return result;
			}

			return null;
		}
	}
}