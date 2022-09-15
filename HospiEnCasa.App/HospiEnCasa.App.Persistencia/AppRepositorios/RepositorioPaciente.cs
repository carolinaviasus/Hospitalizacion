using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext;

        //metodo constructor de repositorioPaciente
         public RepositorioPaciente(AppContext appContext)
         {
            _appContext = appContext;
         }

         //Metodos abstractoaheredados de la intergaz IRepositorioPaciente
         //Este metodo retorna un objeto de tipo paciente 
         Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
         {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
         }

        //este metodo elimina un paciente
        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
         var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
        
        if (pacienteEncontrado == null)  return;
        
        _appContext.Pacientes.Remove (pacienteEncontrado);
        _appContext.SaveChanges();
        }

        //retorna todos los pacientes
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPaciente()
        {
            return _appContext.Pacientes;
        }

        //Metodo que retorna un solo paciente
        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return  _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
        }

        //Metodo que actualiza un paciente 
        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            //Encuentra la primera coincidiencia
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
        
            if (pacienteEncontrado !=null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefonico = paciente.NumeroTelefonico;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud =paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;
                _appContext.SaveChanges(); ///Guardar cambios
            } 
            else
            {
                System.Console.WriteLine("Paciente no encontrado");
            }
            return pacienteEncontrado;
            
        }

        //Metodo para asignar Medico

    Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
    {
        var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
        if (pacienteEncontrado != null)
        {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
            
            if (medicoEncontrado !=null)
            {
                pacienteEncontrado.Medico = medicoEncontrado;
                _appContext.SaveChanges();
            }
            else {
                System.Console.WriteLine("Medico no encontrado");
            }
            return medicoEncontrado;
        }
        return null;
    }




    }
}

