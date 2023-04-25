namespace CORE.Extensions;

/// <summary> Enum Extension Methods </summary>
/// <typeparam name="T"> type of Enum </typeparam>
public class Enum<T> where T : struct, IConvertible
{
    public static string? GetName(int value)
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be an enumerated type");

        return Enum.GetName(typeof(T), value);
    }
}
