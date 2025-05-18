using Datos;
using Datos.Persona;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DesbloqueoCredencial
    {
        private readonly OperacionPersistencia _operacionPersistencia = new OperacionPersistencia();
        UsuarioPersistencia solicitud = new UsuarioPersistencia();

        public bool ConsultaBloqueo(string legajo)
        {
            UsuarioPersistencia persistencia = new UsuarioPersistencia();

            return persistencia.EstaBloqueado(legajo); 
            //NO TERMINE, PERO HACE FALTA QUE ESTE BLOQUEADO? O PUEDE BLANQUEAR LA CLAVE DE CUALQUIERA?
        }

        public Credencial ObtenerCredencialDesbloqueo (string legajo)
        {
            string linea = solicitud.BuscarLineaLegajo(legajo);
            return new Operador (linea);         
        }

        public void SolicitarAutorizacionDesbloqueo(Credencial editada,                                               
                                                string legajoSupervisor
                                                )
        {
            
        // 1. Generar nuevo idAutorizacion
        int idAut = _operacionPersistencia.ProximoIdAutorizacion();

            // 2. Grabar autorización
            var aut = new Autorizacion
            {
                IdAutorizacion = idAut,
                TipoOperacion = "Credencial",
                FechaSolicitud = DateTime.Now,
                LegajoSolicitante = legajoSupervisor,
                Estado = 'P'
            };
            _operacionPersistencia.GrabarAutorizacion(aut);
            _operacionPersistencia.GrabarOperacionCambioCredencial(editada, idAut);
        }



        
    }
}
