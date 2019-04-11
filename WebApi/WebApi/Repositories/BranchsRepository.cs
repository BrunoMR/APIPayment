namespace WebApi.Repositories
{
    using System;
    using System.Linq.Expressions;
    using ServiceStack.OrmLite;
    using WebApi.Models;
    using OrmLiteConnection = Connection.OrmLiteConnection;

    /// <summary>
    /// The branchs repository.
    /// </summary>
    public class BranchsRepository : IBranchsRepository
    {
        /// <summary>
        /// The orm lite connection.
        /// </summary>
        private readonly OrmLiteConnection ormLiteConnection = OrmLiteConnection.GetInstance();

        /// <summary>The get first or default.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The Branchs found by predicate</returns>
        public Branchs GetFirstOrDefault(Expression<Func<Branchs, bool>> predicate)
        {
           return this.ormLiteConnection.OpenConnection().Single(predicate);
        }
    }
}