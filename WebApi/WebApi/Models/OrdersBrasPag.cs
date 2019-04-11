namespace WebApi.Models
{
    using System;
    using ServiceStack.DataAnnotations;

    public class OrdersBrasPag
    {
        /// <summary>
        /// Gets or sets the orders braspag id.
        /// </summary>
        [AutoIncrement]
        public long? OrderBraspagId { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the cart id.
        /// </summary>
        public long CartId { get; set; }

        /// <summary>
        /// Gets or sets the branch id.
        /// </summary>
        public long BranchId { get; set; }

        /// <summary>
        /// Gets or sets the individual id.
        /// </summary>
        public long IndividualId { get; set; }

        /// <summary>
        /// Gets or sets the payment status id.
        /// </summary>
        public long PaymentStatusId { get; set; }

        /// <summary>
        /// Gets or sets the sales order id.
        /// </summary>
        public long SalesOrderId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the payment guid.
        /// </summary>
        public string PaymentGuid { get; set; }

        /// <summary>
        /// Gets or sets the fraud analysis id.
        /// </summary>
        public string FraudAnalysisId { get; set; }

	    /// <summary>
	    /// Gets or sets the fraud analysis status.
	    /// </summary>
	    public virtual int? FraudAnalysisStatus { get; set; }

	    /// <summary>
	    /// Gets or sets the fraud analysis score.
	    /// </summary>
	    public virtual int? FraudAnalysisScore { get; set; }

	    /// <summary>
	    /// Gets or sets the nsu.
	    /// </summary>
	    public virtual string Nsu { get; set; }
	}
}