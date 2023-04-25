using System.Data;

namespace CORE.Services.Contracts;

public interface IDataProviderServices
{
    public Task<DataTable> GetDataTableFromTargetAsync(string target, string? parameters = null);
}
