namespace INFRA.Constants.DBConstants;

public static class Constants
{
    public static readonly string ConnectionString = "data source=DESKTOP-ED3EJDE\\SQLEXPRESS;initial catalog=Hospital;trusted_connection=true;Encrypt=False";

    public enum StoredProcedure
    {
        sp_PacientesEstudiosConOS,
        sp_TopPacientesViejosPorApellido,
        sp_CantidadPeriodoEstudiosPactesyMedicos
    };

}


