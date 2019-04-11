namespace WebApi.Repositories
{
    using System;
    using System.Linq.Expressions;
    using WebApi.Models;

    /// <summary>
    /// The BranchsRepository interface.
    /// </summary>
    public interface IBranchsRepository
    {
        /// <summary>The get first or default.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The Branchs found by predicate</returns>
        Branchs GetFirstOrDefault(Expression<Func<Branchs, bool>> predicate);
    }
}