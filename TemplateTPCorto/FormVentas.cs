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
        List<Producto> listaProductos = new List<Producto>();
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
                if (listBox1.Items.Count > 0)
                {
                    MessageBox.Show("Por favor, vacíe el carrito o finalice la carga antes de cambiar de categoría.");
                    return;
                }
                
                string idCategoria = cboCategoriaProductos.SelectedValue.ToString();
                               
                productosConStock = productoNegocio.obtenerProductosPorCategoria(idCategoria);
                listaProductos = productosConStock;
                lstProducto.DataSource = listaProductos;
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
            string cantidad = txtCantidad.Text;
            ProductoNegocio productoNegocio = new ProductoNegocio();
            int numero;
            VentasNegocio ventasNegocio = new VentasNegocio();
            double totalCarrito;
            if (!int.TryParse(cantidad, out numero)) // Validar que sea un número
            {
                // No es un número
                MessageBox.Show("No es un número válido");
                return;
            } 

            if (lstProducto.SelectedItem != null)
            {
                Producto seleccionado = (Producto)lstProducto.SelectedItem;
                Producto productoAgregado = productoNegocio.agregarProductoCarrito(numero, seleccionado);
                if (productoAgregado.Stock == 0)
                {
                    MessageBox.Show("Cantidad no disponible.");
                    return;
                }                    
                listBox1.Items.Add(productoAgregado);
                seleccionado.Stock = seleccionado.Stock - numero;
               
                lstProducto.DataSource = null;
                lstProducto.DataSource = listaProductos;

                List<Producto> productosCarrito = new List<Producto>();
                productosCarrito = listBox1.Items.Cast<Producto>().ToList();

                totalCarrito = ventasNegocio.sumarSubtotal(productosCarrito);
                lablSubTotal.Text = "$" + totalCarrito.ToString();

                lblTotal.Text = "$" + ventasNegocio.sumarTotal(totalCarrito).ToString();                             



            }
            else
            {
                MessageBox.Show("Por favor, seleccioná un producto.");
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            // Verificamos que haya un producto seleccionado
            if (listBox1.SelectedItem != null)
            {
                Producto seleccionado = (Producto)listBox1.SelectedItem;
                listBox1.Items.Remove(seleccionado);
                VentasNegocio ventasNegocio = new VentasNegocio();
                double totalCarrito;

                foreach (Producto a in listaProductos)
                {
                    if (a.Id == seleccionado.Id)
                    {
                        a.Stock = a.Stock + seleccionado.Stock;
                    }
                }

                // Refrescar la lista
                lstProducto.DataSource = null;
                lstProducto.DataSource = listaProductos;

                //Resta productos de la lista
                List<Producto> productosCarrito = new List<Producto>();
                productosCarrito = listBox1.Items.Cast<Producto>().ToList();

                totalCarrito = ventasNegocio.sumarSubtotal(productosCarrito);
                lablSubTotal.Text = "$" + totalCarrito.ToString();

                lblTotal.Text = "$" + ventasNegocio.sumarTotal(totalCarrito).ToString();
            }
            else
            {
                MessageBox.Show("Seleccioná un producto del carrito para quitar.");
            }
        }

        private void lstProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lablSubTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            
            VentasNegocio ventasNegocio = new VentasNegocio();
            Guid idCliente = Guid.Empty;
           
            bool resultadoCarga = false;

            if (!(cmbClientes.SelectedItem is Cliente clienteSeleccionado))
            {
                MessageBox.Show("No se seleccionó un cliente válido.");
                return;             
                
            }           
            
            idCliente = clienteSeleccionado.Id;
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No se cargó ningun producto en el carrito.");
                return;
            }

            List<Producto> productosCarrito = new List<Producto>();
            productosCarrito = listBox1.Items.Cast<Producto>().ToList();

            resultadoCarga = ventasNegocio.ventaValidada(idCliente, productosCarrito);
            

            if (resultadoCarga)
            {
                MessageBox.Show("Se cargaron todos los productos correctamente.");
            }
            else
            {
                MessageBox.Show("Hubo errores en la carga de productos.");
            }

        }
    }
}
