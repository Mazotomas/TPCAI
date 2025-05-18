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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void CargadeLista()
        {
            AutorizacionesNegocio autorizaciones = new AutorizacionesNegocio();

            List<string[]> listaCambios = autorizaciones.CargadeListaCambios();

            listCambios.Items.Clear(); 

            foreach (var fila in listaCambios)
            {
                string texto = string.Join(" - ", fila);  
                listCambios.Items.Add(texto);                
            }

            List<string[]> listaDesbloqueos = autorizaciones.CargadeListaDesbloqueos();

            listDesbloqueo.Items.Clear(); 

            foreach (var fila in listaDesbloqueos)
            {
                string texto = string.Join(" - ", fila);  
                listDesbloqueo.Items.Add(texto);               
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargadeLista();
        }

        private void btnCambioClavePropia_Click(object sender, EventArgs e)
        {
            FormCambiarContraseña formCambio = new FormCambiarContraseña(usuario);
            formCambio.Show();

            // ocultar o cerrar el login
            this.Hide();
        }

        private void btnAutorizarCambios_Click(object sender, EventArgs e)
        {
            if (listCambios.SelectedItem == null) 
            {
                MessageBox.Show("Debes seleccionar una opción");
            }

            if (listCambios.SelectedItems.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una autorización.");
                return;
            }





            
        }

        private void btnAutorizarDesbloq_Click(object sender, EventArgs e)
        {
            if (listDesbloqueo.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una opción");
            }

            if (listDesbloqueo.SelectedItems.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una autorización.");
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
