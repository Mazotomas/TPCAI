using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ResultadoLogin
    {
        public Credencial Usuario { get; set; }
        public bool EstaBloqueado { get; set; }
        public bool UsuarioNoEncontrado { get; set; }
        public int IntentosFallidos { get; set; }
        public string Mensaje { get; set; }
        public bool CambiarClave { get; set; }
    }
}
