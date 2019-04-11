namespace WebApi.Repositories
{
    using System;
    using System.Linq.Expressions;
    using WebApi.Models;

    /// <summary>
    /// The PaymentStatusRepository interface.
    /// </summary>
    public interface IPaymentStatusRepository
    {
        /// <summary>The get first or default.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The Payment status found by predicate</returns>
        PaymentStatus GetFirstOrDefault(Expression<Func<PaymentStatus, bool>> predicate);
    }
}