namespace WebApi.Repositories
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using ServiceStack.OrmLite;
    using WebApi.Models;
    using OrmLiteConnection = Connection.OrmLiteConnection;

    /// <summary>
    /// The order braspag repository.
    /// </summary>
    public class OrderBraspagRepository : IOrderBraspagRepository
    {
        /// <summary>
        /// The orm lite connection.
        /// </summary>
        private readonly OrmLiteConnection ormLiteConnection = OrmLiteConnection.GetInstance();
        
        /// <summary>The get first or default.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The OrdersBrasPag found by predicate</returns>
        public OrdersBrasPag GetFirstOrDefault(Expression<Func<OrdersBrasPag, bool>> predicate)
        {
           return this.ormLiteConnection.OpenConnection().Single(predicate);
        }

        /// <summary>The Insert of OrdersBrasPag.</summary>
        /// <param name="ordersBrasPag">The orders bras pag.</param>
        /// <returns>The id just insert.</returns>
        public async Task<long> Insert(OrdersBrasPag ordersBrasPag)
        {
            return await this.ormLiteConnection.OpenConnection().InsertAsync(ordersBrasPag, true);
        }
    }
}