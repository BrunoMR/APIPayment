using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    using ServiceStack.DataAnnotations;

    public class Branchs
    {
        /// <summary>
        /// Gets or sets the branch id.
        /// </summary>
        [AutoIncrement]
        public long BranchId { get; set; }

        /// <summary>
        /// Gets or sets the branch code.
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// Gets or sets the branch state.
        /// </summary>
        public string BranchState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the cnpj.
        /// </summary>
        public string Cnpj { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the full address.
        /// </summary>
        public string FullAddress { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the state subscription.
        /// </summary>
        public string StateSubscription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is distribution center.
        /// </summary>
        public bool IsDistributionCenter { get; set; }

        /// <summary>
        /// Gets or sets the validade.
        /// </summary>
        public int Validade { get; set; }

        /// <summary>
        /// Gets or sets the merchant id.
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets the merchant key.
        /// </summary>
        public string MerchantKey { get; set; }

        /// <summary>
        /// Gets or sets the merchant id cyber.
        /// </summary>
        public string MerchantIdCyber { get; set; }

        /// <summary>
        /// Gets or sets the merchant key cyber.
        /// </summary>
        public string MerchantKeyCyber { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        public int Provider { get; set; }
    }
}