namespace CORE.Models;

public class EstudioInstituto
{
    private short _idEstudio;
    public short IdEstudio
    {
        get { return _idEstudio; }
        set { _idEstudio = value; }
    }

    private short _idInstituto;
    public short IdInstituto
    {
        get { return _idInstituto; }
        set { _idInstituto = value; }
    }

    private double? _precio;
    public double? Precio
    {
        get { return _precio; }
        set { _precio = value; }
    }

}
