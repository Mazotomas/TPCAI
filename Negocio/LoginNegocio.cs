using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LoginNegocio
    {
        //public Credencial login(String usuario, String password)
        public ResultadoLogin Login(string usuario, string password)
        {
            UsuarioPersistencia persistencia = new UsuarioPersistencia();
            ResultadoLogin resultado = new ResultadoLogin();

            string registro = persistencia.BuscarLineaCredencial(usuario);
            if (registro == null)
            {
                resultado.UsuarioNoEncontrado = true;
                return resultado;
            }

            string legajo = registro.Split(';')[0];

            if (persistencia.EstaBloqueado(legajo))
            {
                resultado.EstaBloqueado = true;
                resultado.Mensaje = "Usuario bloqueado.";
                return resultado;
            }

            string contrasenaCorrecta = registro.Split(';')[2];
            if (password != contrasenaCorrecta)
            {
                persistencia.RegistrarIntento(legajo);
                int intentos = persistencia.ContarIntentosFallidos(legajo);

                if (intentos >= 3)
                {
                    persistencia.BloquearUsuario(legajo);
                    resultado.EstaBloqueado = true;
                    resultado.Mensaje = "Usuario bloqueado por superar los 3 intentos.";
                }
                else
                {
                    resultado.IntentosFallidos = intentos;
                    resultado.Mensaje = $"Contraseña incorrecta. Intento {intentos}/3.";
                }

                return resultado;
            }

            persistencia.LimpiarIntentos(legajo);

            int idPerfil = persistencia.ObtenerPerfilPorLegajo(legajo);
            Credencial usuarioFinal = persistencia.CrearUsuarioDesdeRegistro(registro, idPerfil);

            resultado.Usuario = usuarioFinal;
            resultado.Mensaje = "Login exitoso.";

            resultado.CambiarClave = false;

            if (!resultado.Usuario.FechaUltimoLogin.HasValue ||
                (DateTime.Now - resultado.Usuario.FechaUltimoLogin.Value).TotalDays > 30)
            {
                resultado.CambiarClave = true;
            }

            persistencia.ActualizarFechaUltimoLogin(legajo);

            return resultado;

        }

    }
}
