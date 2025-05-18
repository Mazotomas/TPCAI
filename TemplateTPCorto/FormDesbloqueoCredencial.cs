using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace TemplateTPCorto
{
    public partial class FormDesbloqueoCredencial : Form
    {

        public FormDesbloqueoCredencial()
        {
            InitializeComponent();
        }

        private void btnSolicitarAutorizacion_Click(object sender, EventArgs e)
        {
            DesbloqueoCredencial solicitud = new DesbloqueoCredencial();
            string legajo = txtLegajo.Text.Trim();

            if (string.IsNullOrEmpty(legajo))
            {
                MessageBox.Show("Ingrese un legajo");
                return;
            }

        }
    }
}
