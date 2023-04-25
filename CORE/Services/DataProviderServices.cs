using CORE.Services.Contracts;
using INFRA.Services.Contracts;
using Microsoft.Data.SqlClient;
using System.Data;
using static INFRA.Constants.DBConstants.Constants;

namespace CORE.Services;

public class DataProviderServices : IDataProviderServices
{
	private readonly IDataBaseServices _dataBase;
	public DataProviderServices(IDataBaseServices dataBase)
	{
		this._dataBase = dataBase;
	}
    public async Task<DataTable> GetDataTableFromTargetAsync(string target, string? parameters = null)
    {
		try
		{
            var spName = GetSpNameBasedOnTarget(target) ?? throw new ArgumentException("sp name is required");
            var spParams = GetSpParamsBasedOnTarget(target, parameters ?? string.Empty);
            var data = await _dataBase.GetData(spName, spParams);
            if (data is null)
            {
                data = new DataTable("Results");
                data.Columns.Add("col1", typeof(string));
                DataRow row = data.NewRow();
                row["col1"] = "(Vacío)";
            }
            return data;
		}
        catch (SqlException)
        {
            throw;
        }
        catch (Exception)
		{
			throw;
		}
    }

	private Dictionary<string, object>? GetSpParamsBasedOnTarget(string target, string parameters)
	{
		Dictionary<string,object>? dict = new ();
        string omited = "consulta1;";

        if (omited.Contains(target))
            return dict;
        else if (!omited.Contains(target) && string.IsNullOrEmpty(parameters)) //add omited queries
            throw new ArgumentException("parameters required");

        var paramsNames = GetSpParamsNameBasedOnTarget(target);
        string[] p = parameters.Split(';');

        for (int i = 0; i < p.Length; i++)
            if (!string.IsNullOrEmpty(p[i]))
                dict.Add(paramsNames[i], p[i]);

        return dict;
	}

    private List<string> GetSpParamsNameBasedOnTarget(string target) =>
        target.ToLower() switch
        {
            "consulta2" => new List<string> () { "MaxQ","Pattern" },
            "consulta3" => new List<string>() { "Month", "Year" },
            "consulta4" => new List<string>() { "NombreOS", "PeriodoMes", "PeriodoAnio" },
            _ => throw new ArgumentException(message: "invalid target option", paramName: nameof(target)),
        };

    private string? GetSpNameBasedOnTarget(string target) =>
        target.ToLower() switch
        {
            "consulta1" => Enum.GetName(StoredProcedure.sp_PacientesEstudiosConOS),
            "consulta2" => Enum.GetName(StoredProcedure.sp_TopPacientesViejosPorApellido),
            "consulta3" => Enum.GetName(StoredProcedure.sp_CantidadPeriodoEstudiosPactesyMedicos),
            "consulta4" => Enum.GetName(StoredProcedure.sp_TotalFacturarYEstudiosObraSocial),
            _ => throw new ArgumentException(message: "invalid target option", paramName: nameof(target)),
        };
    

}
