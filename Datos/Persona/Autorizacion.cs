using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Persona
{
    public class Autorizacion
    {
        private int _idAutorizacion;
        private string _tipoOperacion;
        private char _estado; // A, P, R
        private string _legajoSolicitante;
        private DateTime _fechaSolicitud;
        private string _legajoAutorizador;
        private DateTime? _fechaAutorizacion;

        // --------- Propiedades -------------
        public int IdAutorizacion { get => _idAutorizacion; set => _idAutorizacion = value; }
        public string TipoOperacion { get => _tipoOperacion; set => _tipoOperacion = value; }
        public char Estado { get => _estado; set => _estado = value; }
        public string LegajoSolicitante { get => _legajoSolicitante; set => _legajoSolicitante = value; }
        public DateTime FechaSolicitud { get => _fechaSolicitud; set => _fechaSolicitud = value; }
        public string LegajoAutorizador { get => _legajoAutorizador; set => _legajoAutorizador = value; }
        public DateTime? FechaAutorizacion { get => _fechaAutorizacion; set => _fechaAutorizacion = value; }



        // 1) Desde string CSV (lectura)
        public Autorizacion(string registroCsv)
        {
            var c = registroCsv.Split(';');

            IdAutorizacion = int.Parse(c[0]);
            TipoOperacion = c[1];
            Estado = char.Parse(c[2]);
            LegajoSolicitante = c[3];
            FechaSolicitud = DateTime.ParseExact(c[4], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            LegajoAutorizador = c[5];
            // Campo opcional: si viene vacío, queda null
            FechaAutorizacion = string.IsNullOrWhiteSpace(c[6])
                               ? (DateTime?)null
                               : DateTime.ParseExact(c[6], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        // 2) Vacío / por propiedad (creación manual)
        public Autorizacion() { }

        // Para convertir de nuevo a línea CSV
        public string ToCsv() =>
        $"{IdAutorizacion};{TipoOperacion};{Estado};{LegajoSolicitante};{FechaSolicitud:dd/MM/yyyy HH:mm};{LegajoAutorizador};{FechaAutorizacion}";
    }
}
