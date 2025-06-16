using Datos.Ventas;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> obtenerProductosPorCategoria(String categoria)
        {
            List<Producto> productos = new List<Producto>();
            ProductoPersistencia productoPersistencia = new ProductoPersistencia();
            
            productos = productoPersistencia.obtenerProductosPorCategoria(categoria);
            List<Producto> productosConStock = new List<Producto>();

            foreach (Producto p in productos)
            {
                if (p.Stock > 0)
                {
                    productosConStock.Add(p);
                }
            }
            return productosConStock;
        }

        public Producto agregarProductoCarrito(int cantidad, Producto producto)
        {
            Producto productoAgregado = new Producto(producto);
            if (cantidad > productoAgregado.Stock)
            {
                productoAgregado.Stock = 0;
                return productoAgregado;
            }
           
            productoAgregado.Precio = producto.Precio * cantidad;
            productoAgregado.Stock = cantidad;

            return productoAgregado;
        }
         
    }
}

