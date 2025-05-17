using Datos;
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
    public partial class FormSupervisor : Form
    {
        private Credencial usuario;

        public FormSupervisor(Credencial usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void BtnCambioClave_Click(object sender, EventArgs e)
        {
            FormCambiarContraseña formCambio = new FormCambiarContraseña(usuario);
            formCambio.Show();

            // ocultar o cerrar el login
            this.Hide();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            FormModificarPersona formModificar = new FormModificarPersona();
            formModificar.Show();

            // ocultar o cerrar el login
            this.Hide();
        }

        private void BtnDesbloquear_Click(object sender, EventArgs e)
        {

        }
    }
}
