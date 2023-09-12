using System.Runtime.Intrinsics.Arm;

namespace Boletin;
public class MisFunciones
{
    public static byte MenuNotas()
    {
        Console.WriteLine("1. Registro de Quices");
        Console.WriteLine("2. Registro de Trabajos");
        Console.WriteLine("3. Registro de Parciales");
        Console.WriteLine("4. Salir al menu principal");
        Console.Write("> ");
        return Convert.ToByte(Console.ReadLine());
    }

    public static byte Reportes()
    {
        Console.WriteLine("1. Notas de grupo");
        Console.WriteLine("2. Notas Finales");
        Console.WriteLine("3. salir");
        Console.Write("> ");
        return Convert.ToByte(Console.ReadLine());
    }
}
