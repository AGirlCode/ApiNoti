using ApiNoti.Configuration;
using ApiNoti.Utilities;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace ApiNoti.Services
{
    public class DatabaseService : IDatabaseService
    {
        readonly string _connString;
        private readonly IConfiguration _configuration;
        private OracleConnection _oracleConnection;

        public DatabaseService(IConfiguration configuration)
        {
            _connString = configuration.GetValue<string>("ConnectionString"); 
            _oracleConnection = new OracleConnection(_connString);
        }

        public long GetCountUnreadNotiSent(string clientCode, string appName) 
        {
            try
            {
                _oracleConnection.Open();

                var parameters = new OracleParameter[]
                    {new OracleParameter("P_OUT", OracleDbType.RefCursor, ParameterDirection.Output)};

                var ds = OracleHelper.ExecuteDataset(_oracleConnection, CommandType.StoredProcedure, AppConstants.SP_GetCountUnreadNoti,
                    parameters);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    var count = 0;
                     
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                    }

                    return count;
                }  
                    return 0;
            } catch (Exception e)
            { 
                return 0;
            } finally
            {
                _oracleConnection.Close();
            }

            return 0;
        }
    }
}
