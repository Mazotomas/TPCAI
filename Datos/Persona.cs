using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Persona
    {
        private string _legajo;
        private string _nombre;
        private string _apellido;
        private int _Dni;
        private DateTime _fechaIngreso;

        public string Legajo { get => _legajo; set => _legajo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int DNI { get => _Dni; set => _Dni = value; }
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }

        public Persona(string registro)
        {
            string[] datos = registro.Split(';');
            this._legajo = datos[0];
            this._nombre = datos[1];
            this._apellido = datos[2];
            this._Dni = int.Parse(datos[3]);
            this._fechaIngreso = DateTime.ParseExact(datos[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

    }
}
