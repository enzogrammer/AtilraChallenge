using INFRA.Services.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;
using static INFRA.Constants.DBConstants.Constants;

namespace INFRA.Services;

public class DataBaseServices : IDataBaseServices
{
    private string connectionString;
    private readonly ILogger<DataBaseServices> _logger;

    public DataBaseServices(ILogger<DataBaseServices> logger)
    {
        this.connectionString = ConnectionString;
        _logger = logger;
    }

    public async Task<DataTable?> GetData(string spName, Dictionary<string,object>? parameters)
    {
        DataTable? dt = null;

        using (SqlConnection connection = new (connectionString))
        {
            // Create the Command
            SqlCommand command = new (spName, connection);
            command.CommandType = CommandType.StoredProcedure;

            // Add params
            if (parameters is object)
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = $"@{parameter.Key}";
                    param.DbType = GetDBType(parameter.Value);
                    param.Value = GetObjectValue(parameter.Value, GetObjectType(parameter.Value));
                    command.Parameters.Add(param);
                }
            try
            {
                // open conn
                connection.Open();
                // fill dt
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    dt = new DataTable("Results");
                    dt.Load(reader);
                }
            }
            catch (SqlException sqex)
            {
                _logger.LogError($"Ocurrió un error de base de datos. {sqex.Message} . {sqex.StackTrace} .");
                throw new Exception($"Ocurrió un error de base de datos. {sqex.Message} . {sqex.StackTrace} .");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrió un error. {ex.Message} . {ex.StackTrace} .");
                throw new Exception($"Ocurrió un error. {ex.Message} . {ex.StackTrace} .");
            }
        }
        return dt;
    }

    private Type GetObjectType(object value)
    {
        return int.TryParse(value.ToString(), out _) ? typeof(int) : typeof(string);
    }

    private DbType GetDBType(object value)
    {
        Type t = GetObjectType(value);
        DbType dbt;
        if (t == typeof(int))
            dbt = DbType.Int32;
        else
            dbt = DbType.String;
        return dbt;
    }

    private object GetObjectValue(object value, Type t)
    {
        object obj;
        if (t == typeof(int))
            obj = Convert.ToInt32(value);
        else
            obj = Convert.ToString(value);
        return obj;
    }

}
