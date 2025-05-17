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
    public partial class FormAdministrador : Form
    {
        private Credencial usuario;

        public FormAdministrador(Credencial usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

    }
}
