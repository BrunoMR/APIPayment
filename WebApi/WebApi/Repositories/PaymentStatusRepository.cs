namespace WebApi.Repositories
{
    using System;
    using System.Linq.Expressions;
    using ServiceStack.OrmLite;
    using WebApi.Models;
    using OrmLiteConnection = Connection.OrmLiteConnection;

    /// <summary>
    /// The Payment status repository.
    /// </summary>
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        /// <summary>
        /// The orm lite connection.
        /// </summary>
        private readonly OrmLiteConnection ormLiteConnection = OrmLiteConnection.GetInstance();

        /// <summary>The get first or default.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The Payment status found by predicate</returns>
        public PaymentStatus GetFirstOrDefault(Expression<Func<PaymentStatus, bool>> predicate)
        {
           return this.ormLiteConnection.OpenConnection().Single(predicate);
        }
    }
}