using Datos;
using Datos.Ventas;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasNegocio
    {
        public List<Cliente> obtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            ClientePersistencia clientePersistencia = new ClientePersistencia();

            clientes = clientePersistencia.obtenerClientes();

            return clientes;
        }

        public List<CategoriaProductos> obtenerCategoriaProductos()
        {
            List<CategoriaProductos> categoriaProductos = new List<CategoriaProductos>();
            
            CategoriaProductos p1 = new CategoriaProductos("1","Audio");
            categoriaProductos.Add(p1);

            CategoriaProductos p2 = new CategoriaProductos("2", "Celulares");
            categoriaProductos.Add(p2);

            CategoriaProductos p3 = new CategoriaProductos("3", "Electro Hogar");
            categoriaProductos.Add(p3);

            CategoriaProductos p4 = new CategoriaProductos("4", "Informática");
            categoriaProductos.Add(p4);

            CategoriaProductos p5 = new CategoriaProductos("5", "Smart TV");
            categoriaProductos.Add(p5);

            return categoriaProductos;
        }

        public double sumarSubtotal(List<Producto> listaProductos)
        {
            double subtotal = 0;
            foreach (Producto p in listaProductos)
            {
                subtotal = subtotal + p.Precio;
            }

            return subtotal;
        }
        public double sumarTotal(double subtotal)
        {
            double total = subtotal;

            if (subtotal >= 1000000)
            {
                total = subtotal * 0.85;
            }

            return total;
            
        }

        public bool ventaValidada(Guid idCliente, List<Producto> productos)
        {
            VentaPersistencia ventaPersistencia = new VentaPersistencia();
            bool valido = false;
            string respuesta = null;
            Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5");

            foreach (Producto p in productos)
            {
                DatosVenta datosVenta = new DatosVenta(idCliente, p.Id, idUsuario, p.Stock);
                valido = ventaPersistencia.agregarVenta(datosVenta);                

            }

            return valido;


        }
    }
}
