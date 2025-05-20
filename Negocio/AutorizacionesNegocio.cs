using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Negocio
{
    public class AutorizacionesNegocio
    {
        public List<string[]> CargadeListaCambios()
        {
            AutorizacionesPersistencia autorizaciones = new AutorizacionesPersistencia();

            List<string[]> todas = autorizaciones.ObtenerAutorizaciones();

            
            List<string[]> soloPersona = new List<string[]>();

            
            foreach (string[] fila in todas)
            {
                if (fila.Length > 1 &&                 
                    string.Equals(fila[1], "Persona",  
                                  StringComparison.OrdinalIgnoreCase))
                {
                    soloPersona.Add(fila);             
                }
            }

            return soloPersona;

        }

        public List<string[]> CargadeListaDesbloqueos()
        {
            AutorizacionesPersistencia autorizaciones = new AutorizacionesPersistencia();

            
            List<string[]> todas = autorizaciones.ObtenerAutorizaciones();

            
            List<string[]> soloCredencial = new List<string[]>();

           
            foreach (string[] fila in todas)
            {
                if (fila.Length > 1 &&                 
                    string.Equals(fila[1], "Credencial",  
                                  StringComparison.OrdinalIgnoreCase))
                {
                    soloCredencial.Add(fila);             
                }
            }

            return soloCredencial;
        }

        public void CargarContraseña(string legajo, string contraseña)
        {
            AutorizacionesPersistencia autorizaciones = new AutorizacionesPersistencia();
            autorizaciones.RealizarCambioClave(legajo, contraseña);

        }
        public void CargarPersona(string legajo, string nombre, string apellido, string dni, string fechaIngreso)
        {
            AutorizacionesPersistencia autorizaciones = new AutorizacionesPersistencia();
            autorizaciones.RealizarCambioPersona(legajo, nombre, apellido, dni, fechaIngreso);

        }

        public void AutorizarSolicitud(string id, string legajoAut)
        {
            AutorizacionesPersistencia autorizaciones = new AutorizacionesPersistencia();
            autorizaciones.AutorizarCampos(id, legajoAut);
        }

    }
}
