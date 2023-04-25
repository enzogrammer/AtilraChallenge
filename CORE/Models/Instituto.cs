namespace CORE.Models;

public class Instituto
{
    private short _idInstituto;
    public short IdInstituto
    {
        get { return _idInstituto; }
        set { _idInstituto = value; }
    }

    private string? _nombreInstituto;
    public string? NombreInstituto
    {
        get { return _nombreInstituto; }
        set { _nombreInstituto = value; }
    }

    private string? _estado;
    public string? Estado
    {
        get { return _estado; }
        set { _estado = value; }
    }

}
