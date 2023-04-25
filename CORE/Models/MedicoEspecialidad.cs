namespace CORE.Models;

public class MedicoEspecialidad
{
    private short _idEspecialidad;
    public short IdEspecialidad
    {
        get { return _idEspecialidad; }
        set { _idEspecialidad = value; }
    }

    private int _matricula;
    public int Matricula
    {
        get { return _matricula; }
        set { _matricula = value; }
    }

}
