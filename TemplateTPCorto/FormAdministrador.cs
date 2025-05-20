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
    public partial class FormAdministrador : Form
    {
        private Credencial usuario;
        private List<string[]> _filas;

        public FormAdministrador(Credencial usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            CargadeLista();

        }
        private void FormAdministrador_FormClosing(object sender, FormClosingEventArgs e)

        {

            Application.Exit(); // Finaliza todo el programa

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public bool CargadeLista()
        {
            AutorizacionesNegocio autorizaciones = new AutorizacionesNegocio();

            List<string[]> listaCambios = autorizaciones.CargadeListaCambios();

            bool vacio = true;
            listCambios.Items.Clear(); 

            foreach (var fila in listaCambios)
            {
                string texto = string.Join(" - ", fila);  
                listCambios.Items.Add(texto);
                vacio = false;
            }

            List<string[]> listaDesbloqueos = autorizaciones.CargadeListaDesbloqueos();

            listDesbloqueo.Items.Clear(); 

            foreach (var fila in listaDesbloqueos)
            {
                string texto = string.Join(" - ", fila);  
                listDesbloqueo.Items.Add(texto);
                vacio = false;
            }
            return vacio;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool vacio = CargadeLista();

            if (vacio)
            {
                MessageBox.Show("No hay nuevas autorizaciones.");
            }
            
        }

        private void btnCambioClavePropia_Click(object sender, EventArgs e)
        {
            FormCambiarContraseña formCambio = new FormCambiarContraseña(usuario);
            formCambio.Show();

            // ocultar o cerrar el login
            this.Hide();
        }

        private void FormAdministrador_MouseDown(object sender, MouseEventArgs e)
        {
            // Si el mouse está fuera del área del ListBox
            if (!listCambios.Bounds.Contains(e.Location) || !listDesbloqueo.Bounds.Contains(e.Location))
            {
                listCambios.ClearSelected();
                listDesbloqueo.ClearSelected();// Deselecciona todos los ítems
            }
        }
        


        private void btnAutorizarCambios_Click(object sender, EventArgs e)
        {
            if (listCambios.SelectedItem == null) 
            {
                MessageBox.Show("Debes seleccionar una opción");
                return;
            }

            AutorizacionesNegocio autorizaciones = new AutorizacionesNegocio();
            _filas = autorizaciones.CargadeListaCambios();
            int idx = listCambios.SelectedIndex;
            string[] filaElegida = _filas[idx];

            string id = filaElegida[0];
            string estado = filaElegida[2];
            string legajo = filaElegida[7];
            string nombre = filaElegida[8];
            string apellido = filaElegida[9];
            string dni = filaElegida[10];
            string fechaIngreso = filaElegida[11];

            if (estado == "A" || estado == "R")
            {
                MessageBox.Show("Seleccionar una solicitud pendiente.");
                return;
            }

            autorizaciones.CargarPersona(legajo, nombre, apellido, dni, fechaIngreso);
            autorizaciones.AutorizarSolicitud(id, usuario.Legajo);

            listCambios.Items.Remove(listCambios.SelectedItem);
            MessageBox.Show("Autorizacion de cambio persona exitosa.");
            return;
        }

        private void btnAutorizarDesbloq_Click(object sender, EventArgs e)
        {
            if (listDesbloqueo.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una opción");
                return;
            }

            AutorizacionesNegocio autorizaciones = new AutorizacionesNegocio();
            _filas = autorizaciones.CargadeListaDesbloqueos();
            int idx = listDesbloqueo.SelectedIndex;
            string[] filaElegida = _filas[idx];

            string legajo = filaElegida[7];
            string nuevaContraseña = filaElegida[9];
            string id = filaElegida[0];
            string estado = filaElegida[2];

            if (estado == "A" || estado == "R")
            {
                MessageBox.Show("Seleccionar una solicitud pendiente.");
                return;
            }

            autorizaciones.CargarContraseña(legajo, nuevaContraseña);
            autorizaciones.AutorizarSolicitud(id, usuario.Legajo);

            listDesbloqueo.Items.Remove(listDesbloqueo.SelectedItem);
            MessageBox.Show("Autorizacion de desbloqueo exitosa.");
            return;

        }
    }
}
