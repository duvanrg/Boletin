using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boletin.Entities
{
    public class Estudiante : Boletin
    {
        private string code;
        private string nombre;
        private string direccion;
        private int edad;

        public Estudiante() : base()
        {
        }

        public Estudiante(List<float> quices, List<float> trabajos, List<float> parciales, string code, string nombre, string direccion, int edad) : base(quices, trabajos, parciales)
        {
            this.code = code;
            this.nombre = nombre;
            this.direccion = direccion;
            this.edad = edad;
        }


        public string Code { get => code; set => code = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Edad { get => edad; set => edad = value; }

        public void AgregarEstudiante(List<Estudiante> estudiantes)
        {
            Estudiante estudiante = new Estudiante();
            Console.WriteLine("Codigo: ");
            estudiante.Code = Console.ReadLine();
            Console.WriteLine("Nombre: ");
            estudiante.Nombre = Console.ReadLine();
            Console.WriteLine("Direccion: ");
            estudiante.Direccion = Console.ReadLine();
            Console.WriteLine("Edad: ");
            estudiante.Edad = Convert.ToInt32(Console.ReadLine());
            estudiante.Quices = new List<float>();
            estudiante.Trabajos = new List<float>();
            estudiante.Parciales = new List<float>();
            estudiantes.Add(estudiante);
        }

        public void RegistroNota(List<Estudiante> ListaEst, byte opc)
        {
            Console.WriteLine("Ingrese el codigo del estudiante");
            string studentCode = Console.ReadLine();
            Estudiante alumno = ListaEst.FirstOrDefault(x => x.Code.Equals(studentCode));
            string tipo = opc == 1 ? "quiz" : opc == 2 ? "Trabajo" : opc == 3 ? "Parcial" : null;
            var selec = opc == 1 ? alumno.Quices : opc == 2 ? alumno.Trabajos : opc == 3 ? alumno.Parciales : null;
            Console.WriteLine("Ingrese la nota del {0}: ", tipo);
            float nota = float.Parse(Console.ReadLine());
            selec.Add(nota);
            // Console.WriteLine($"{selec[0]}");
            // foreach (float item in selec)
            // {
            //     Console.WriteLine($"{item}");
            // }

            Console.ReadKey();

            // switch (opc)
            // {
            //     case 1:
            //         Console.WriteLine($"Quiz Nro: {0}", alumno.Quices.Count() + 1);
            //         alumno.Quices.Add(float.Parse(Console.ReadLine()));
            //         break;
            //     case 2:
            //         Console.WriteLine($"Trabajo Nro: {0}", alumno.Quices.Count() + 1);
            //         alumno.Trabajos.Add(float.Parse(Console.ReadLine()));
            //         break;
            //     case 3:
            //         Console.WriteLine($"Parcial Nro: {0}", alumno.Quices.Count() + 1);
            //         alumno.Parciales.Add(float.Parse(Console.ReadLine()));
            //         break;
            //     default:
            //         break;
            // }

            // selec.Add(float.Parse(Console.ReadLine()));

        }
        public void RemoveItem(List<Estudiante> ListEst)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el codigo del estudiante a eliminar");
            string studentCode = Console.ReadLine();
            Estudiante studentToRemove = ListEst.FirstOrDefault(x => (x.Code ?? string.Empty).Equals(studentCode)) ?? new Estudiante();
            if (studentToRemove != null)
            {
                ListEst.Remove(studentToRemove);
                MisFunciones.SaveData(ListEst);
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado");
                Console.ReadKey();
            }
        }
        public void EditItem(List<Estudiante> ListEst)
        {
            Console.Clear();
            byte count = 0;
            int idxnota = 0;
            Console.WriteLine("Ingrese el codigo del estudiante a Editar: ");
            string studentCode = Console.ReadLine();
            Estudiante STE = ListEst.FirstOrDefault(x => (x.Code ?? string.Empty).Equals(studentCode)) ?? new Estudiante();
            if (STE != null)
            {
                Console.Clear();
                Console.WriteLine($"Seleccione el dato que quiere editar: \n1. Codigo: {STE.Code} \n2. Nombre: {STE.Nombre} \n3. Direccion: {STE.Direccion} \n4. Edad: {STE.Edad} \n5. Notas Quices \n6. Notas Quices \n7. Notas Quices \n8. Salir");
                byte edit = Convert.ToByte(Console.ReadLine());
                string tipo =
                edit == 1 ? "el codigo" :
                edit == 2 ? "el Nombre" :
                edit == 3 ? "la Direccion" :
                edit == 4 ? "la Edad" :
                edit == 5 ? "Quiz" :
                edit == 6 ? "Trabajo" :
                edit == 7 ? "Parcial" :
                null;
                var selec =
                edit == 5 ? STE.Quices :
                edit == 6 ? STE.Trabajos :
                edit == 7 ? STE.Parciales :
                null;
                Console.Clear();
                if (edit <= 4)
                {
                    Console.WriteLine($"Digite {tipo} nueva/o: ");
                }
                else if (edit <= 7)
                {
                    if (selec.Count() != 0)
                    {
                        Console.WriteLine($"cual nota de {tipo} desea editar: ");
                        foreach (float item in selec)
                        {
                            count += 1;
                            Console.WriteLine($"{tipo} {count}: {item}");
                        }
                        idxnota = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine($"Digite la nueva nota de {tipo} ");
                        selec[idxnota] = float.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine($"No hay ninguna nota tipo {tipo}");
                    }
                }
                switch (edit)
                {
                    case 1:
                        STE.Code = Console.ReadLine();
                        break;
                    case 2:
                        STE.Nombre = Console.ReadLine();
                        break;
                    case 3:
                        STE.Direccion = Console.ReadLine();
                        break;
                    case 4:
                        STE.Edad = Convert.ToInt32(Console.ReadLine());
                        break;
                    // case 5:
                    //     Console.WriteLine($"cual nota de {edit} desea editar: ");
                    //     foreach (float item in selec)
                    //     {
                    //         each += 1;
                    //         Console.WriteLine($"1. {item}");
                    //     }
                    //     idxnota = Convert.ToInt32(Console.ReadLine()) - 1;
                    //     Console.WriteLine($"Digite la nueva nota de {edit}");
                    //     STE.Quices[idxnota] = float.Parse(Console.ReadLine());
                    //     ;
                    //     break;
                    // case 6:
                    //     Console.WriteLine($"cual nota de {edit} desea editar: ");
                    //     foreach (float item in selec)
                    //     {
                    //         each += 1;
                    //         Console.WriteLine($"1. {item}");
                    //     }
                    //     idxnota = Convert.ToInt32(Console.ReadLine()) - 1;
                    //     Console.WriteLine($"Digite la nueva nota de {edit}");
                    //     selec[idxnota] = float.Parse(Console.ReadLine());

                    //     break;
                    // case 7:
                    //     Console.WriteLine($"cual nota de {edit} desea editar: ");
                    //     foreach (float item in selec)
                    //     {
                    //         each += 1;
                    //         Console.WriteLine($"1. {item}");
                    //     }
                    //     idxnota = Convert.ToInt32(Console.ReadLine()) - 1;
                    //     Console.WriteLine($"Digite la nueva nota de {edit}");
                    //     STE.Parciales[idxnota] = float.Parse(Console.ReadLine());
                    //     ;
                    //     break;
                    default:
                        // Console.WriteLine($"Opcion Invalida");
                        break;
                }
                MisFunciones.SaveData(ListEst);
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado");
                Console.ReadLine();
            }
        }

        public void SearchItem(List<Estudiante> ListEst)
        {
            int count = 0;
            Console.WriteLine($"Seleccione el dato a buscar: \n1. Codigo \n2. Nombre \n3. Direccion \n4. Edad \n5. Notas Quices \n6. Notas Quices \n7. Notas Quices \n8. Salir");
            byte selec = Convert.ToByte(Console.ReadLine());
            string tipo =
                selec == 1 ? "el codigo" :
                selec == 2 ? "el Nombre" :
                selec == 3 ? "la Direccion" :
                selec == 4 ? "la Edad" :
                selec == 5 ? "el Quiz" :
                selec == 6 ? "el Trabajo" :
                selec == 7 ? "el Parcial" :
                null;
            if (tipo != null)
            {
                Console.Clear();
                Console.WriteLine($"digite {tipo} a buscar: ");
                string searchString = Console.ReadLine();

                List<Estudiante> resultados = new List<Estudiante>();

                foreach (var estudiante in ListEst)
                {
                    switch (selec)
                    {
                        case 1:
                            if (estudiante.Code == searchString)
                                resultados.Add(estudiante);
                            break;
                        case 2:
                            if (estudiante.Nombre == searchString)
                                resultados.Add(estudiante);
                            break;
                        case 3:
                            if (estudiante.Direccion == searchString)
                                resultados.Add(estudiante);
                            break;
                        case 4:
                            if (estudiante.Edad == Convert.ToInt32(searchString))
                                resultados.Add(estudiante);
                            break;
                        case 5:
                            if (estudiante.Quices.Contains(float.Parse(searchString)))
                                resultados.Add(estudiante);
                            break;
                        case 6:
                            if (estudiante.Trabajos.Contains(float.Parse(searchString)))
                                resultados.Add(estudiante);
                            break;
                        case 7:
                            if (estudiante.Parciales.Contains(float.Parse(searchString)))
                                resultados.Add(estudiante);
                            break;
                        default:
                            break;
                    }
                }
                if (resultados.Count() != 0)
                {

                    Console.WriteLine($"Resultados de la búsqueda por {tipo}:");
                    Console.WriteLine($"{resultados}");
                    foreach (Estudiante estudiante in resultados)
                    {
                        Console.Clear();
                        Console.WriteLine($"Codigo: {estudiante.Code} \nNombre: {estudiante.Nombre} \nDireccion: {estudiante.Direccion} \nEdad: {estudiante.Edad}");
                        Console.WriteLine($"Notas Quices");
                        count = 0;
                        foreach (float item in estudiante.Quices)
                        {
                            count += 1;
                            Console.WriteLine($"Quiz {count}: {item}");
                        }
                        count = 0;
                        Console.WriteLine($"Notas Trabajos");
                        foreach (float item in estudiante.Trabajos)
                        {
                            count += 1;
                            Console.WriteLine($"Trabajo {count}: {item}");
                        }
                        count = 0;
                        Console.WriteLine($"Notas Parciales");
                        foreach (float item in estudiante.Parciales)
                        {
                            count += 1;
                            Console.WriteLine($"Parcial {count}: {item}");
                        }
                        Console.ReadLine();
                    }
                    Console.WriteLine($"ENTER para Salir");
                }
                else
                {
                    Console.WriteLine("No se encontro ningun usuario");

                }
            }
        }
    }

}