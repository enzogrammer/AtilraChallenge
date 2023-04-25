namespace CORE.Models;

public class Estudio
{
    private short _idEstudio;
    public short IdEstudio
    {
        get { return _idEstudio; }
        set { _idEstudio = value; }
    }

    private string? _tipoDeEstudio;
    public string? TipoDeEstudio
    {
        get { return _tipoDeEstudio; }
        set { _tipoDeEstudio = value; }
    }

}
