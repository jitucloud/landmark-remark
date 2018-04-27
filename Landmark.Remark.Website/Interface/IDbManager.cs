using System.Data;

namespace Landmark.Remark.Website.Interface
{
    public interface IDbManager
    {
        /// <summary>
        /// Create and return a db connection, using the provided connection string details
        /// </summary>
        IDbConnection GetConnection();
        /// <summary>
        /// Create and return an open db connection, using the provided connection string details
        /// </summary>
        IDbConnection GetOpenConnection();
    }
}
