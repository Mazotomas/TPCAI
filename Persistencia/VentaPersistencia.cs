using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class VentaPersistencia
    {
        private Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5");

        
        public bool agregarVenta(DatosVenta datosVenta )
        {
            var jsonRequest = JsonConvert.SerializeObject(datosVenta);

            HttpResponseMessage response = WebHelper.Post("/api/Venta/AgregarVenta", jsonRequest);

            if (response.IsSuccessStatusCode)
            {
                return true;
                

            }
            else
            {
               return false;
                

            }

            
        }
        


    }
}
