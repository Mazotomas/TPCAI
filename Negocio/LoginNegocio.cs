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

            //Credencial credencial = usuarioPersistencia.login(usuario);

            //if (EstaBloqueado(credencial.Legajo))
            //{
            //    return null; //en caso de esta bloqueado que podría devolver? un 0? y sino el numero de rol?
            //}


            //if (credencial.Contrasena.Equals(password))
            //{
            //    return credencial; //en caso de que la contraseña este ok...deberia devolver en realidad el rol?
            //    //borrar las lineas de login_intentos.csv para este legajo
            //}
            //else
            //{
            //    Boolean puedeSeguir = CantidadIntentos(credencial.Legajo);
            //    if (puedeSeguir)
            //    {
            //        //registrar el intento en login_intentos.csv
            //        return null; //algo que dispare un msj de error pero deje continuar
            //    }
            //    else
            //    {
            //        //escribir legajo en usuario_bloqueado
            //        // error de bloqueo
            //    }

            //}

            //return null;
        }


        public bool EstaBloqueado(string legajo)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();

            Boolean Bloqueo = usuarioPersistencia.EstaBloqueado(legajo);

            return Bloqueo; //true es que lo esta, false que no

        }

        public bool CantidadIntentos(string legajo)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();

            int intentos = usuarioPersistencia.CantidadIntentos(legajo);

            if (intentos >= 2)
            {
                return false; //falso si supera los 2, deberá ser bloqueado
            }

            return true; //verdadero si puede seguir probando
        }




    }
}
