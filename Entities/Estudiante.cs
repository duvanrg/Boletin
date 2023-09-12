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

        public void agregarNota(List<Estudiante> ListaEst, byte tipo)
        {
            Console.WriteLine("Ingrese el codigo del estudiante");
            string studentCode = Console.ReadLine();
            Estudiante alumno = ListaEst.FirstOrDefault(x => x.Code.Equals(studentCode));
            var selec = tipo == 1 ? alumno.Quices :tipo == 2 ?  alumno.Trabajos: tipo == 3 ? alumno.Parciales : null;
            Console.WriteLine(alumno.Nombre);
            Console.WriteLine("Ingrese la nota del quiz");
            selec.Add(float.Parse(Console.ReadLine()));
            foreach (float item in alumno.Quices)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}