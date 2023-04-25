namespace CORE.Models;

public class PacientePlan
{
    private short _idPlan;
    public short IdPlan
    {
        get { return _idPlan; }
        set { _idPlan = value; }
    }

    private int _dni;
    public int Dni
    {
        get { return _dni; }
        set { _dni = value; }
    }

}
