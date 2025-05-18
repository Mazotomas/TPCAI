using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Negocio
{
    public class DesbloqueoCredencial
    {
        
        
        public bool ConsultaBloqueo(string legajo)
        {
            UsuarioPersistencia persistencia = new UsuarioPersistencia();

            return persistencia.EstaBloqueado(legajo); 
            //NO TERMINE, PERO HACE FALTA QUE ESTE BLOQUEADO? O PUEDE BLANQUEAR LA CLAVE DE CUALQUIERA?
        }
    }
}
