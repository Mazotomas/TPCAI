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

        
        public string agregarVenta(DatosVenta datosVenta )
        {
            var jsonRequest = JsonConvert.SerializeObject(datosVenta);
            string mensaje;

            HttpResponseMessage response = WebHelper.Post("/api/Venta/AgregarVenta", jsonRequest);

            if (response.IsSuccessStatusCode)
            {
                string contenido = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (string.IsNullOrWhiteSpace(contenido) || contenido == "201")
                {
                    mensaje = "Se ha procesado correctamente esta línea";
                }
                else
                {
                    mensaje = contenido;
                }

            }
            else
            {
                mensaje = $"No procesada.Error: {response.StatusCode} - {response.Content.ReadAsStringAsync().GetAwaiter().GetResult()}";
            }

            return mensaje;
            
        }
    }
}
