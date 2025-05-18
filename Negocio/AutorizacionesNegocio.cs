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
            Autorizaciones autorizaciones = new Autorizaciones();

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
            Autorizaciones autorizaciones = new Autorizaciones();

            
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
            Autorizaciones autorizaciones = new Autorizaciones();
            autorizaciones.RealizarCambioClave(legajo, contraseña);

        }

        public void AutorizarSolicitud(string id, string legajoAut)
        {
            Autorizaciones autorizaciones = new Autorizaciones();
            autorizaciones.AutorizarCampos(id, legajoAut);
        }

    }
}
