using System.Data;

namespace INFRA.Services.Contracts;

public interface IDataBaseServices
{
    public Task<DataTable?> GetData(string spName, Dictionary<string, object>? parameters);
}
