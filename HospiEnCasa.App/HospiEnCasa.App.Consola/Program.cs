using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente= new RepositorioPaciente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenidos a Hospital En Casa de G45");
            AddPaciente();
            //BuscarPaciente(1);
            //AsignarMedico();
        }

        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Ivan",
                Apellidos = "Castro Ruiz",
                NumeroTelefonico = "3003162985",
                Genero = Genero.Masculino,
                Direccion = "Calle la Playa",
                Longitud = 5.07062F,
                Latitud = -75.52290F,
                Ciudad = "Barranquilla",
                FechaNacimiento = new DateTime(1979, 09, 14)
            };
            _repoPaciente.AddPaciente(paciente);
            System.Console.WriteLine($"Paciente {paciente.Nombre} {paciente.Apellidos} ha sido agregado con exito a la BD");
          
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre+" "+paciente.Apellidos);
        }

        private static void AsignarMedico()
        {
            var medico = _repoPaciente.AsignarMedico(1,2);
            Console.WriteLine(medico.Nombre+" "+medico.Apellidos);
        }
    }
}
