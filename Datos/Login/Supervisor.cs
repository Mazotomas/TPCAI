using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Supervisor : Credencial
    {
        public Supervisor(String registro)
            : base(registro) { }

        public override void MostrarOpciones()
        {
            Console.WriteLine("Soy Supervisor");
        }

        public void DesbloquearUsuario() 
        { 
            // lógica 
        }
        public void ModificarPersona() 
        { 
            // logica
        }
    }
}
