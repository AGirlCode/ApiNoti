using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace ApiNoti.Controllers
{
    public class AccountController : IAccountController
    {
        private readonly string _connString;
        private readonly IConfiguration _configuration;
        private OracleConnection _oracleConnection;


        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = configuration.GetValue<string>("ConnectionString");
            _oracleConnection = new OracleConnection(_connString);
        }
        public object UpdateDeviceInfo(string clientCode, string deviceId, string userAgent, string appName)
        {
            object result = null;
            try
            {
                var p_clientCode = new OracleParameter("p_clientcode", OracleDbType.Varchar2);
                p_clientCode.Value = clientCode;

                var p_deviceID = new OracleParameter("p_deviceid", OracleDbType.Varchar2);
                p_deviceID.Value = deviceId;

                var p_userAgent = new OracleParameter("p_useragent", OracleDbType.Varchar2);
                p_userAgent.Value = userAgent;

                var p_appName = new OracleParameter("p_appname", OracleDbType.Varchar2);
                p_appName.Value = appName;

                var parameters = new OracleParameter[]
                {
                   p_clientCode, p_deviceID, p_userAgent, p_appName
                };

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                   // var query = "USP_GETEMPLOYEEDETAILS";

                  //  result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            } catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = _configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
