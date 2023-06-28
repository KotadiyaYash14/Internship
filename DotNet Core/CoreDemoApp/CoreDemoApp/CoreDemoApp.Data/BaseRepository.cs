using Dapper;
using CoreDemoApp.Model.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data
{
    public class BaseRepository
    {
        #region Fields
        public readonly IOptions<DataConfig> _ConnectionString;
        public readonly IConfiguration configuration;
        #endregion

        #region Constructor
        public BaseRepository(IOptions<DataConfig> connectionString, IConfiguration config = null)
        {
            _ConnectionString = connectionString;
            configuration = config;
        }
        #endregion

        #region SQl Methods
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string? conString = ConfigurationExtensions.GetConnectionString(this.configuration, "DefaultConnection");
            using (SqlConnection _db = new SqlConnection(conString))
            {
                await _db.OpenAsync();
                return await _db.QueryFirstOrDefaultAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> ExecuteAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string? conString = ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection");
            using (SqlConnection _db = new SqlConnection(conString))
            {
                await _db.OpenAsync();
                return await _db.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string? conString = ConfigurationExtensions.GetConnectionString(this.configuration, "DefaultConnection");
            using (SqlConnection con = new SqlConnection(conString))
            {
                await con.OpenAsync();
                return await con.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

    }
}
