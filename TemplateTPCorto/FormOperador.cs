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
    public partial class FormOperador : Form
    {
        private Credencial usuario;

        public FormOperador(Credencial usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
        private void FormOperador_FormClosing(object sender, FormClosingEventArgs e)

        {

            Application.Exit(); // Finaliza todo el programa

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCambioClave_Click(object sender, EventArgs e)
        {
            FormCambiarContraseña formCambio = new FormCambiarContraseña(usuario);
            formCambio.Show();

            // ocultar o cerrar el login
            this.Hide();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            FormVentas formVenta = new FormVentas();
            formVenta.Show();

            // ocultar o cerrar el login
            this.Hide();
        }
    }
}
