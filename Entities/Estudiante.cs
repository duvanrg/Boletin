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
            }else{
                Console.WriteLine("Estudiante no encontrado");
                Console.ReadKey();
            }
        }

        public void EditItem(List<Estudiante> ListEst)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el codigo del estudiante a Editar: ");
            string studentCode = Console.ReadLine();
            Estudiante studentToEdit = ListEst.FirstOrDefault(x => (x.Code ?? string.Empty).Equals(studentCode)) ?? new Estudiante();
            if (studentToEdit != null)
            {
                Console.WriteLine($"1. {studentToEdit.Code} \n2. {studentToEdit.Nombre} \n3. {studentToEdit.Direccion} \n4. {studentToEdit.Edad} \n5. Notas Quices \n6. Notas Quices \n7. Notas Quices \n8. Salir");
                byte edit = Convert.ToByte(Console.ReadLine());
                string tipo = 
                edit == 1 ? "codigo" : edit == 2 ? "Nombre" : edit == 3 ? "Direccion" : edit == 4 ? "Direccion" : edit == 5 ? "quiz" : edit == 6 ? "Trabajo" : edit == 7 ? "Parcial" : null;
                var selec = edit == 1 ? studentToEdit.Nombre = "hola" : edit == 2 ? studentToEdit.Nombre : edit == 3 ? studentToEdit.Nombre : edit == 4 ? studentToEdit.Nombre : edit == 5 ? studentToEdit.Nombre : edit == 6 ? studentToEdit.Nombre : edit == 7 ? studentToEdit.Nombre : null;
                int idx = ListEst.IndexOf(studentToEdit);
                ListEst.Remove(studentToEdit);
                MisFunciones.SaveData(ListEst);
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado");
                Console.ReadLine();
            }
        }
    }

}