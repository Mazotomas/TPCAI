using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Datos.Persona;

namespace Persistencia
{
    public class OperacionPersistencia
    {
        private readonly string _rutaAut =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "autorizacion.csv");
        private readonly string _rutaOp =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "operacion_cambio_persona.csv");

        public int ProximoIdAutorizacion()
        {
            var ult = File.ReadLines(_rutaAut).Skip(1).LastOrDefault();
            int proximoId;

            if (ult == null)
            {
                proximoId = 1;        // Entonces empezamos en 1
            }
            else
            {
                string[] partes = ult.Split(';');   // Separamos la última línea por ';'
                int idAnterior = int.Parse(partes[0]); // Tomamos el primer campo y lo pasamos a int
                proximoId = idAnterior + 1;            // El siguiente ID es +1
            }

            return proximoId;

        }

        public void GrabarAutorizacion(Autorizacion a)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_rutaAut)); // Asegura que la carpeta exista

            // Leer contenido para chequear salto de línea
            string contenido = File.ReadAllText(_rutaAut);

            // Si no termina en salto de línea, lo agrego ANTES de abrir StreamWriter
            if (!contenido.EndsWith("\n") && !contenido.EndsWith("\r\n"))
            {
                File.AppendAllText(_rutaAut, Environment.NewLine);
            }

            string fechaAutorizacionTexto;

            if (a.FechaAutorizacion == null) 
            {
                fechaAutorizacionTexto = "";
            }
            else
            {
                fechaAutorizacionTexto = a.FechaAutorizacion.Value.ToString("dd/MM/yyyy HH:mm");
            }

            // Ahora abro StreamWriter para agregar la línea
            using (StreamWriter sw = new StreamWriter(_rutaAut, true))
            {
                sw.WriteLine($"{a.IdAutorizacion};{a.TipoOperacion};{a.Estado};{a.LegajoSolicitante};{a.FechaSolicitud:dd/MM/yyyy HH:mm};{a.LegajoAutorizador};{fechaAutorizacionTexto}");
            }
        }

        public void GrabarOperacionCambioPersona(Persona persona, int idOperacion)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_rutaOp)); // Asegura que la carpeta exista

            // Leer contenido para chequear salto de línea
            string contenido = File.ReadAllText(_rutaOp);

            // Si no termina en salto de línea, lo agrego ANTES de abrir StreamWriter
            if (!contenido.EndsWith("\n") && !contenido.EndsWith("\r\n"))
            {
                File.AppendAllText(_rutaOp, Environment.NewLine);
            }

            // Ahora abro StreamWriter para agregar la línea
            using (StreamWriter sw = new StreamWriter(_rutaOp, true))
            {
                sw.WriteLine($"{idOperacion};{persona.Legajo};{persona.Nombre};{persona.Apellido};{persona.DNI};{persona.FechaIngreso:dd/MM/yyyy}");
            }
        }
    }
}
