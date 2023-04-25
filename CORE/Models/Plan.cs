namespace CORE.Models;

public class Plan
{
    private short _idPlan;
    public short IdPlan
    {
        get { return _idPlan; }
        set { _idPlan = value; }
    }

    private string _sigla;
    public string Sigla
    {
        get { return _sigla; }
        set { _sigla = value; }
    }

    private string? _estado;
    public string? Estado
    {
        get { return _estado; }
        set { _estado = value; }
    }

}
