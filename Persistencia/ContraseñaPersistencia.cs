using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ContraseñaPersistencia

    {
        public bool ActualizarContraseña(string legajo, string nuevoContraseña)
        {
            string archivoCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "credenciales.csv");
            bool validacion = false;
            try
            {
                var lineas = File.ReadAllLines(archivoCsv).ToList();

                if (lineas.Count > 1)
                {
                    string encabezado = lineas[0];
                    var nuevasLineas = new List<string> { encabezado };

                    for (int i = 1; i < lineas.Count; i++)
                    {
                        string[] campos = lineas[i].Split(';');

                        if (campos.Length == 5 && campos[0] == legajo)
                        {

                            campos[2] = nuevoContraseña;
                            campos[4] = DateTime.Now.ToString("dd/MM/yyyy");
                            validacion = true;
                        }

                        nuevasLineas.Add(string.Join(";", campos));
                    }

                    // Sobrescribe el archivo con los cambios
                    File.WriteAllLines(archivoCsv, nuevasLineas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la contraseña: " + ex.Message);
            }
            return validacion;

        }
    }
}
