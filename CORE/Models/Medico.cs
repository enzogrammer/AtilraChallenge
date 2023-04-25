namespace CORE.Models;

public class Medico
{
    private int _matricula;
    public int Matricula
    {
        get { return _matricula; }
        set { _matricula = value; }
    }

    private string? _nombre;
    public string? Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    private string? _apellido;
    public string? Apellido
    {
        get { return _apellido; }
        set { _apellido = value; }
    }

    private string? _sexo;
    public string? Sexo
    {
        get { return _sexo; }
        set { _sexo = value; }
    }

    private string? _estado;
    public string? Estado
    {
        get { return _estado; }
        set { _estado = value; }
    }

}
