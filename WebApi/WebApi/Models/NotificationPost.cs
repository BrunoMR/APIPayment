namespace WebApi.Models
{
	using PaymentCwi.Models.Enum;

	/// <summary>
    /// The model of notification post.
    /// </summary>
    public class NotificationPost
    {
        /// <summary>
        /// Gets or sets the recurrent payment id.
        /// </summary>
        public string RecurrentPaymentId { get; set; }

        /// <summary>
        /// Gets or sets the payment id.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the change type.
        /// </summary>
        public ChangeTypeNotificationEnum ChangeType { get; set; }
    }
}