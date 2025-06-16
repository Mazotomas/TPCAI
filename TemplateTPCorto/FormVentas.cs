using Datos;
using Datos.Ventas;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {

            CargarClientes();
            CargarCategoriasProductos();
            IniciarTotales();
        }

        private void IniciarTotales()
        {
            lablSubTotal.Text = "0.00";
            lblTotal.Text = "0.00";
        }

        private void CargarCategoriasProductos()
        {
            
            VentasNegocio ventasNegocio = new VentasNegocio();

            List<CategoriaProductos> categoriaProductos = ventasNegocio.obtenerCategoriaProductos();


            cboCategoriaProductos.DataSource = categoriaProductos;
            cboCategoriaProductos.DisplayMember = "Detalle"; // Cambiá por la propiedad visible (ej. "Descripcion")
            cboCategoriaProductos.ValueMember = "Id";       // Cambiá por la propiedad del ID

            //foreach (CategoriaProductos categoriaProducto in categoriaProductos)
            //{
            //    cboCategoriaProductos.Items.Add(categoriaProducto);
            //}
        }

        private void CargarClientes()
        {
            VentasNegocio ventasNegocio = new VentasNegocio();

            List<Cliente> listadoClientes = ventasNegocio.obtenerClientes();

            foreach (Cliente cliente in listadoClientes)
            {
                cmbClientes.Items.Add(cliente);
            }
        }

        private void btnListarProductos_Click(object sender, EventArgs e)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> productosConStock = new List<Producto>();
            if (cboCategoriaProductos.SelectedValue != null)
            {
                string idCategoria = cboCategoriaProductos.SelectedValue.ToString();
                MessageBox.Show(idCategoria);
                
                productosConStock = productoNegocio.obtenerProductosPorCategoria(idCategoria);
                lstProducto.DataSource = productosConStock;
                // usar idCategoria

            }
            else
            {
                MessageBox.Show("Por favor, seleccioná una categoría válida.");
            }
           
        }
        
        
        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormSupervisor_FormClosing(object sender, FormClosingEventArgs e)

        {

            Application.Exit(); // Finaliza todo el programa

        }

     

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (lstProducto.SelectedItem != null)
            {
                Producto seleccionado = (Producto)lstProducto.SelectedItem;
                MessageBox.Show("Seleccionaste: " + seleccionado.Nombre);
                string cantidad = txtCantidad.Text; //Validar que sea un numero
            }
            else
            {
                MessageBox.Show("Por favor, seleccioná una categoría válida.");
            }
        }
    }
}
