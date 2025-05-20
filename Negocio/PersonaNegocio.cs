using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Datos.Persona;
using Persistencia;

namespace Negocio
{
    public class PersonaNegocio
    {
        private readonly PersonaPersistencia _personaPersistencia = new PersonaPersistencia();
        private readonly OperacionPersistencia _operacionPersistencia = new OperacionPersistencia();

        public Persona ObtenerPersona(string legajo)
        {
            
            return _personaPersistencia.BuscarPorLegajo(legajo);
        }
        
        public bool ValidacionTexto(string persona)
        {
            bool validacion = true;

            if (persona == null || persona.Contains(";") || persona.Any(char.IsDigit) || !Regex.IsMatch(persona, @"^[a-zA-Z0-9]+$")) 
            {
                validacion = false;
            }
            return validacion;
        }
        public bool ValidacionNumero(string numero)
        {
            bool validacion = true;

            if (numero == null || numero.Contains(";") || !numero.All(char.IsDigit) || numero.Length < 7 || numero.Length > 8)
            {
                validacion = false;
            }
            return validacion;
        }
        public bool ValidacionFecha(string fechaNueva)
        {
            bool validacion = true;

            if (fechaNueva == null || fechaNueva.Contains(";") || !DateTime.TryParse(fechaNueva, out DateTime fecha) || fecha.Year < 2000 || fecha > DateTime.Now)
            {
                validacion = false;
            }

            return validacion;
            
        }


        public IEnumerable<(string Campo, string Anterior, string Nuevo)>
        ObtenerCambios(Persona original, Persona editada)
        {
            if (original == null || editada == null) yield break;

            if (original.Nombre != editada.Nombre)
                yield return ("Nombre", original.Nombre, editada.Nombre);

            if (original.Apellido != editada.Apellido)
                yield return ("Apellido", original.Apellido, editada.Apellido);

            if (original.DNI != editada.DNI)
                yield return ("Dni", original.DNI.ToString(), editada.DNI.ToString());

            if (original.FechaIngreso != editada.FechaIngreso)
                yield return ("FechaIngreso",
                              original.FechaIngreso.ToString("dd/MM/yyyy"),
                              editada.FechaIngreso.ToString("dd/MM/yyyy"));
        }

        public void SolicitarAutorizacionCambio(Persona editada,
                                                Persona original,
                                                string legajoSupervisor,
                                                IEnumerable<(string Campo, string Anterior, string Nuevo)> cambios)
        {
            // 1. Generar nuevo idAutorizacion
            int idAut = _operacionPersistencia.ProximoIdAutorizacion();

            // 2. Grabar autorización
            var aut = new Autorizacion
            {
                IdAutorizacion = idAut,
                TipoOperacion = "Persona",
                FechaSolicitud = DateTime.Now,
                LegajoSolicitante = legajoSupervisor,
                Estado = 'P'
            };
            _operacionPersistencia.GrabarAutorizacion(aut);
            _operacionPersistencia.GrabarOperacionCambioPersona(editada, idAut);
        }

        
    }
}
