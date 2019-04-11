namespace WebApi.Models
{
	using System.Xml.Serialization;

	/// <summary>
	/// The case management order status to post to client.
	/// </summary>
	[XmlRoot(ElementName = "CaseManagementOrderStatusToPostToClient")]
	public class CaseManagementOrderStatusToPostToClient
	{
		/// <summary>
		/// Gets or sets the notes.
		/// </summary>
		[XmlElement(ElementName = "Notes")]
		public string Notes { get; set; }

		/// <summary>
		/// Gets or sets the anti fraud transaction id.
		/// </summary>
		[XmlElement(ElementName = "AntiFraudTransactionId")]
		public string AntiFraudTransactionId { get; set; }

		/// <summary>
		/// Gets or sets the merchant reference number.
		/// </summary>
		[XmlElement(ElementName = "MerchantReferenceNumber")]
		public string MerchantReferenceNumber { get; set; }

		/// <summary>
		/// Gets or sets the original decision.
		/// </summary>
		[XmlElement(ElementName = "OriginalDecision")]
		public string OriginalDecision { get; set; }

		/// <summary>
		/// Gets or sets the new decision.
		/// </summary>
		[XmlElement(ElementName = "NewDecision")]
		public string NewDecision { get; set; }

		/// <summary>
		/// Gets or sets the reviewer.
		/// </summary>
		[XmlElement(ElementName = "Reviewer")]
		public string Reviewer { get; set; }

		/// <summary>
		/// Gets or sets the reviewer comments.
		/// </summary>
		[XmlElement(ElementName = "ReviewerComments")]
		public string ReviewerComments { get; set; }

		/// <summary>
		/// Gets or sets the queue.
		/// </summary>
		[XmlElement(ElementName = "Queue")]
		public string Queue { get; set; }

		/// <summary>
		/// Gets or sets the profile.
		/// </summary>
		[XmlElement(ElementName = "Profile")]
		public string Profile { get; set; }

		/// <summary>
		/// Gets or sets the xsd.
		/// </summary>
		[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsd { get; set; }

		/// <summary>
		/// Gets or sets the xsi.
		/// </summary>
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
	}
}