using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)

        {

            Application.Exit(); // Finaliza todo el programa

        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;

            LoginNegocio loginNegocio = new LoginNegocio();

            ResultadoLogin resultado = loginNegocio.Login(usuario, password);

            if (resultado.UsuarioNoEncontrado)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            if (resultado.EstaBloqueado)
            {
                MessageBox.Show(resultado.Mensaje);
                return;
            }

            if (resultado.IntentosFallidos > 0)
            {
                MessageBox.Show(resultado.Mensaje);
                return;
            }

            if (resultado.CambiarClave)
            {
                MessageBox.Show("Debe cambiar su contraseña porque es su primer ingreso o pasaron más de 30 días del último login.");

                // Abrir formulario de cambio de clave, pasando la credencial
                FormCambiarContraseña formCambio = new FormCambiarContraseña(resultado.Usuario);
                formCambio.Show();

                // ocultar el login
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Exitoso");

                if (resultado.Usuario is Operador)
                {
                    FormOperador formOperador = new FormOperador(resultado.Usuario);
                    formOperador.Show();
                }
                else if (resultado.Usuario is Supervisor)
                {
                    FormSupervisor formSupervisor = new FormSupervisor(resultado.Usuario);
                    formSupervisor.Show();
                }
                else if (resultado.Usuario is Administrador)
                {
                    FormAdministrador formAdministrador = new FormAdministrador(resultado.Usuario);
                    formAdministrador.Show();
                }

                // ocultar el login para no volver atrás
                this.Hide();
            }
           


        }

    }
}
