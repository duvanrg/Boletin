using System.Runtime.Intrinsics.Arm;
using Boletin;
using Boletin.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Estudiante> ListaEst = new List<Estudiante>();
        bool run = true;
        while (run)
        {
            Estudiante student = new Estudiante();
            Console.Clear();
            Console.WriteLine("1. Registro de estudiantes");
            Console.WriteLine("2. Registro de notas");
            Console.WriteLine("3. Reportes e informes");
            Console.WriteLine("4. Salir");
            Console.Write("> ");
            byte opc = Convert.ToByte(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    student.AgregarEstudiante(ListaEst);
                    foreach (Estudiante item in ListaEst)
                    {
                        Console.WriteLine($"{item.Code}");
                        Console.WriteLine($"{item.Nombre}");
                        Console.WriteLine($"{item.Direccion}");
                        Console.WriteLine($"{item.Edad}");
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    bool menuNotas = true;
                    while (menuNotas)
                    {
                        Console.Clear();

                        byte OpcNotas = MisFunciones.MenuNotas();
                        switch (OpcNotas)
                        {
                            case 1:
                                Console.Clear();

                                student.agregarNota(ListaEst, 1);

                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                menuNotas = false;
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