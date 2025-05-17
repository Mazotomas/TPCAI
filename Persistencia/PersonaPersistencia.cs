using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Persona;
using Datos;
using Persistencia.DataBase;
using System.IO;


namespace Persistencia
{
    public class PersonaPersistencia
    {
        public Persona BuscarPorLegajo(string legajo)
        {
            string archivoCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "persona.csv");

            try
            {
                using (StreamReader sr = new StreamReader(archivoCsv))
                {
                    string linea;
                    bool esPrimera = true;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (esPrimera)
                        {
                            esPrimera = false;
                            continue;
                        }

                        string[] campos = linea.Split(';');
                        if (campos.Length > 0 && campos[0] == legajo)
                        {
                            return new Persona(linea);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer persona.csv: " + e.Message);
            }

            return null;
        }

    }
}
