namespace WebApi.Repositories
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using WebApi.Models;

    /// <summary>
    /// The OrderBraspagRepository interface.
    /// </summary>
    public interface IOrderBraspagRepository
    {
        /// <summary>The get first or default.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The OrdersBrasPag found by predicate</returns>
        OrdersBrasPag GetFirstOrDefault(Expression<Func<OrdersBrasPag, bool>> predicate);

        /// <summary>The Insert of OrdersBrasPag.</summary>
        /// <param name="ordersBrasPag">The orders bras pag.</param>
        /// <returns>The id just insert.</returns>
        Task<long> Insert(OrdersBrasPag ordersBrasPag);
    }
}