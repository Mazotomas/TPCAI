using Datos;
using Datos.Persona;
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
    public partial class FormDesbloqueoCredencial : Form
    {
        private Credencial usuario;
    

        public FormDesbloqueoCredencial(Credencial usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
        private void FormDesbloqueoCredencial_FormClosing(object sender, FormClosingEventArgs e)

        {

            Application.Exit(); // Finaliza todo el programa

        }
        private void btnSolicitarAutorizacion_Click(object sender, EventArgs e)
        {
            DesbloqueoCredencial solicitud = new DesbloqueoCredencial();
            
            string legajo = txtLegajo.Text.Trim();
            string nuevaContraseña = txtNuevaContraseña.Text.Trim();
            

            if (string.IsNullOrEmpty(legajo))
            {
                MessageBox.Show("Ingrese un legajo");
                return;
            }

            if (string.IsNullOrEmpty(nuevaContraseña) || nuevaContraseña.Length < 8 || nuevaContraseña.Contains(";"))
            {
                MessageBox.Show("Ingrese una nueva contraseña de 8 o más caracteres.");
                return;
            }

            if (!solicitud.ConsultaBloqueo(legajo))
            {
                MessageBox.Show("El usuario no está bloqueado.");
                return;
            }
                       

            Credencial credencial = solicitud.ObtenerCredencialDesbloqueo(legajo);

            credencial.Contrasena = nuevaContraseña;
            credencial.FechaUltimoLogin = null;

            solicitud.SolicitarAutorizacionDesbloqueo(credencial, usuario.Legajo);

            MessageBox.Show("Solicitud realizada correctamente.");
            txtLegajo.Clear();
            txtNuevaContraseña.Clear();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormSupervisor formSupervisor = new FormSupervisor(usuario);
            formSupervisor.Show();

            this.Hide();
        }
    }
}
