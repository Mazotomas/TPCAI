using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Datos.Persona;
using Negocio;

namespace TemplateTPCorto
{
    public partial class FormModificarPersona : Form
    {
        private readonly PersonaNegocio _personaNegocio = new PersonaNegocio();
        private Persona _personaOriginal;
        private Credencial usuario;

        public FormModificarPersona(Credencial usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormModificarPersona_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text.Trim();

            if (string.IsNullOrEmpty(legajo))
            {
                MessageBox.Show("Ingrese un legajo");
                return;
            }

            try
            {
                _personaOriginal = _personaNegocio.ObtenerPersona(legajo);

                if (_personaOriginal == null)
                {
                    MessageBox.Show("Legajo no encontrado");
                    return;
                }

                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtDNI.Enabled = true;
                txtFechaIngreso.Enabled = true;

                // Llenamos los controles con los datos
                txtNombre.Text = _personaOriginal.Nombre;
                txtApellido.Text = _personaOriginal.Apellido;
                txtDNI.Text = _personaOriginal.DNI.ToString();
                txtFechaIngreso.Text = _personaOriginal.FechaIngreso.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_personaOriginal == null)
            {
                MessageBox.Show("Primero busque un legajo.");
                return;
            }

            // Construimos la versión editada con los valores actuales de los controles
            Persona personaEditada = new Persona(_personaOriginal.Legajo,
                                                 txtNombre.Text.Trim(),
                                                 txtApellido.Text.Trim(),
                                                 int.Parse(txtDNI.Text.Trim()),
                                                 DateTime.Parse(txtFechaIngreso.Text.Trim()));

            // Detectamos cambios
            var cambios = _personaNegocio.ObtenerCambios(_personaOriginal, personaEditada);
            if (!cambios.Any())
            {
                MessageBox.Show("No hay cambios para guardar.");
                return;
            }

            try
            {
                string legajoSupervisor = usuario.Legajo;
                _personaNegocio.SolicitarAutorizacionCambio(personaEditada,
                                                            _personaOriginal,
                                                            legajoSupervisor,
                                                            cambios);

                MessageBox.Show("Solicitud enviada al Administrador.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            txtLegajo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtFechaIngreso.Clear();
            _personaOriginal = null;
        }
    }
    
}
