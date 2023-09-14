using System.Runtime.Intrinsics.Arm;
using Boletin;
using Boletin.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Estudiante> ListaEst = new Dictionary<string, Estudiante>();
        Estudiante student = new Estudiante();
        bool run = true;
        ListaEst = MisFunciones.LoadData();
        while (run)
        {
            Console.Clear();
            Console.WriteLine("1. Registro de estudiantes");
            Console.WriteLine("2. Registro de notas");
            Console.WriteLine("3. Reportes e informes");
            Console.WriteLine("4. Eliminar estudiante");
            Console.WriteLine("5. Editar Estudiante");
            Console.WriteLine("6. Buscar Estudiante");
            Console.WriteLine("7. Salir");
            Console.Write("> ");
            byte opc = Convert.ToByte(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    student.AgregarEstudiante(ListaEst);
                    MisFunciones.SaveData(ListaEst);
                    Console.ReadKey();
                    break;
                case 2:
                    bool menuNotas = true;
                    while (menuNotas)
                    {
                        Console.Clear();
                        byte OpcNotas = MisFunciones.MenuNotas();
                        if(OpcNotas != 0 || OpcNotas > 3){
                            Console.Clear();
                                student.RegistroNota(ListaEst, OpcNotas);
                                MisFunciones.SaveData(ListaEst);
                        }
                        else{
                            menuNotas = false;
                        }
                        
                    }

                    break;
                case 3:
                    bool Menureportes = true;
                    while (Menureportes)
                    {
                        Console.Clear();
                        byte OpcReportes = MisFunciones.Reportes();
                        switch (OpcReportes)
                        {
                            case 1:
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                Menureportes = false;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("opcion no valida");
                                Console.WriteLine("Seleccione una opcion valida");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 4:
                    Console.Clear();
                    student.RemoveItem(ListaEst);
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    student.EditItem(ListaEst);
                    Console.ReadKey();
                    break;
                case 6:
                    Console.Clear();
                    student.SearchItem(ListaEst);
                    Console.ReadKey();
                    break;
                case 7:
                    Console.Clear();
                    run = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("opcion no valida");
                    Console.WriteLine("Seleccione una opcion valida");
                    Console.ReadKey();
                    break;
            }

        }

    }
}