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
    public partial class FormCambiarContraseña : Form
    {
        
        private Credencial usuario;

        private CambioContraseña negocioCambio;

        public FormCambiarContraseña(Credencial usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            negocioCambio = new CambioContraseña();
        }

        // Aquí podés usar usuario para mostrar datos o validar.
        // Y loginNegocio para llamar al método cambio de clave.
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevaContra = txtCambioContraseña.Text;

            if (string.IsNullOrWhiteSpace(nuevaContra))
            {
                MessageBox.Show("Por favor ingrese la nueva contraseña.");
                return;
            }

            // Llamamos a la lógica de negocio
            string resultado = negocioCambio.CambiarContraseña(usuario.Legajo, nuevaContra, usuario.Contrasena);

            MessageBox.Show(resultado);

            if (resultado == "Contraseña cambiada correctamente.")
            {
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
        }
    }
}
