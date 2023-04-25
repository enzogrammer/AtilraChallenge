namespace CORE.Models;

public class PlanCobEstudio
{
    private short _idPlan;
    public short IdPlan
    {
        get { return _idPlan; }
        set { _idPlan = value; }
    }

    private short _idEstudio;
    public short IdEstudio
    {
        get { return _idEstudio; }
        set { _idEstudio = value; }
    }

    private double? _porcentaje;
    public double? Porcentaje
    {
        get { return _porcentaje; }
        set { _porcentaje = value; }
    }

}
