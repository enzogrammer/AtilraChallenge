namespace CORE.Models;

public class EstudiosRealizado
{
    private short _idEstudioReal;
    public short IdEstudioReal
    {
        get { return _idEstudioReal; }
        set { _idEstudioReal = value; }
    }

    private short _idEstudio;
    public short IdEstudio
    {
        get { return _idEstudio; }
        set { _idEstudio = value; }
    }

    private DateTime? _fecha;
    public DateTime? Fecha
    {
        get { return _fecha; }
        set { _fecha = value; }
    }

    private short _idInstituto;
    public short IdInstituto
    {
        get { return _idInstituto; }
        set { _idInstituto = value; }
    }

    private int _matricula;
    public int Matricula
    {
        get { return _matricula; }
        set { _matricula = value; }
    }

    private string _sigla;
    public string Sigla
    {
        get { return _sigla; }
        set { _sigla = value; }
    }

    private int _dni;
    public int Dni
    {
        get { return _dni; }
        set { _dni = value; }
    }

    private string? _resultadoEstudio;
    public string? ResultadoEstudio
    {
        get { return _resultadoEstudio; }
        set { _resultadoEstudio = value; }
    }

    private string? _abono;
    public string? Abono
    {
        get { return _abono; }
        set { _abono = value; }
    }

    private string? _estado;
    public string? Estado
    {
        get { return _estado; }
        set { _estado = value; }
    }

}
