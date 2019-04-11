namespace WebApi.Models
{
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;

    public class Settings
    {
        /// <summary>
        /// Gets or sets the query url.
        /// </summary>
        public string QueryUrl { get; set; }

        /// <summary>
        /// Gets or sets the payment url.
        /// </summary>
        public string PaymentUrl { get; set; }

        /// <summary>
        /// Gets or sets the sql conn.
        /// </summary>
        public string SqlConn { get; set; }
    }
}