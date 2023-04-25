namespace CORE.Models;

public class especialidad
{
    private short _idEspecialidad;
    public short IdEspecialidad
    {
        get { return _idEspecialidad; }
        set { _idEspecialidad = value; }
    }

    private string? _descripcion;
    public string? Descripcion
    {
        get { return _descripcion; }
        set { _descripcion = value; }
    }

}
