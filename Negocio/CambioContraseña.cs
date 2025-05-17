using System;
using Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CambioContraseña
    {
        // private ContraseñaPersistencia persistencia = new ContraseñaPersistencia();


        public string CambiarContraseña(string legajo, string nuevaContraseña, string contraseña)
        {

            ContraseñaPersistencia persistencia = new ContraseñaPersistencia();

            if (nuevaContraseña.Length <= 8)
            {
                return "Debe contener 8 o más caracteres.";
            }
            if (contraseña == nuevaContraseña)
            {
                return "No puede ser igual a la última contraseña.";
            }
            bool actualizado = persistencia.ActualizarContraseña(legajo, nuevaContraseña);

            if (actualizado == true)
            {
                return "Contraseña cambiada correctamente.";
            }
            return "Error al cambiar contraseña";


        }

    }

   
}
