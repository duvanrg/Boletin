using System.Runtime.Intrinsics.Arm;
using Boletin.Entities;
using Newtonsoft.Json;

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

    public static Dictionary<string, Estudiante> SaveData(Dictionary<string, Estudiante> lstListado)
    {
        string json = JsonConvert.SerializeObject(lstListado, Formatting.Indented);
        File.WriteAllText("data/boletin.json", json);
        return lstListado;
    }

    public static Dictionary<string, Estudiante> LoadData()
    {
        using (StreamReader reader = new StreamReader("data/boletin.json"))
        {
            string json = reader.ReadToEnd();
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Estudiante>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? new Dictionary<string, Estudiante>();
        }
    }
}
