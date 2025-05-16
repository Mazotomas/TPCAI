using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Operador : Credencial
    {
        public Operador(String registro)
            : base(registro) { }

        public override void MostrarOpciones()
        {
            Console.WriteLine("Soy Operador");
        }
    }
}
