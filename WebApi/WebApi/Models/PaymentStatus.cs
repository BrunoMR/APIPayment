namespace WebApi.Models
{
    using PaymentCwi.Models.Enum;

    /// <summary>
    /// The payment status.
    /// </summary>
    public class PaymentStatus
    {
        /// <summary>
        /// Gets or sets the payment status id.
        /// </summary>
        public long PaymentStatusId { get; set; }

        /// <summary>
        /// Gets or sets the gateway response code.
        /// </summary>
        public TransactionStatus GatewayResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the complement.
        /// </summary>
        public string Complement { get; set; }
    }
}