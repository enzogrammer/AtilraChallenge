namespace CORE.Models;

public class Paciente
{
    private int _dni;
    public int Dni
    {
        get { return _dni; }
        set { _dni = value; }
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

    private DateTime? _fechaNac;
    public DateTime? FechaNac
    {
        get { return _fechaNac; }
        set { _fechaNac = value; }
    }

}
