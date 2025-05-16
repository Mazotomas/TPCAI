using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Administrador : Credencial
    {
        public Administrador(String registro)
            : base(registro) { }

        public override void MostrarOpciones()
        {
            Console.WriteLine("Soy Administrador");
        }

        public void AutorizarOperacion() 
        { 
            // lógica 
        }
    }
}
