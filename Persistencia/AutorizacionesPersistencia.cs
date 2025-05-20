using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class AutorizacionesPersistencia
    {
        public List<string[]> ObtenerAutorizaciones()
        {
            // --- 1. Rutas y lecturas ---
            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas");
            string rutaAut = Path.Combine(baseDir, "autorizacion.csv");
            string rutaCred = Path.Combine(baseDir, "operacion_cambio_credencial.csv");
            string rutaPers = Path.Combine(baseDir, "operacion_cambio_persona.csv");

            // Diccionarios:  id → resto de las columnas
            Dictionary<string, string[]> dicCred = CargarDiccionario(rutaCred);
            Dictionary<string, string[]> dicPers = CargarDiccionario(rutaPers);

            var lista = new List<string[]>();

            // --- 2. Recorrer autorizaciones ---
            foreach (var linea in File.ReadAllLines(rutaAut).Skip(1)) // salto encabezado
            {
                var datosAut = linea.Split(';');        // [0]=id, [1]=... etc.
                string id = datosAut[0];

                // Buscar en los otros diccionarios (si existe)
                dicCred.TryGetValue(id, out var datosCred);
                dicPers.TryGetValue(id, out var datosPers);

                // Combinar: autorización + cred + persona  (null-coalesce para evitar nulls)
                var filaCompleta = datosAut
                    .Concat(datosCred ?? Array.Empty<string>())
                    .Concat(datosPers ?? Array.Empty<string>())
                    .ToArray();

                lista.Add(filaCompleta);
            }

            return lista;
        }

        // --- helper ---
        private Dictionary<string, string[]> CargarDiccionario(string ruta)
        {
            if (!File.Exists(ruta)) return new Dictionary<string, string[]>();

            return File.ReadAllLines(ruta)
                       .Skip(1)                   // encabezado
                       .Select(l => l.Split(';')) // [0]=id, resto = datos
                       .Where(arr => arr.Length > 1)
                       .ToDictionary(a => a[0],   // clave = id
                                     a => a.Skip(1).ToArray()); // valor = resto columnas
        }

        public void LimpiarIntentos(string legajo)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "login_intentos.csv");
            string[] lineas = File.ReadAllLines(path);
            List<string> nuevas = new List<string>();

            // Guardar el encabezado
            string encabezado = lineas[0];
            nuevas.Add(encabezado);

            // Filtrar las demás
            for (int i = 1; i < lineas.Length; i++)
            {
                if (!lineas[i].StartsWith(legajo + ";"))
                {
                    nuevas.Add(lineas[i]);
                }
            }

            File.WriteAllLines(path, nuevas);
        }

        public void RealizarCambioClave(string legajo,string contraseña)
        {
            string archivoCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "credenciales.csv");

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
                            // Actualiza la fecha de último login vacia
                            campos[4] = null;
                            campos[2] = contraseña;
                        }

                        nuevasLineas.Add(string.Join(";", campos));
                    }

                    // Sobrescribe el archivo con los cambios
                    File.WriteAllLines(archivoCsv, nuevasLineas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar fecha de último login: " + ex.Message);
            }
        }
        public void RealizarCambioPersona(string legajo, string nombre, string apellido, string dni, string fechaIngreso)
        {
            string archivoCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "persona.csv");

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
                            // Actualiza los campos de persona
                            campos[1] = nombre;
                            campos[2] = apellido;
                            campos[3] = dni;
                            campos[4] = fechaIngreso;
                        }

                        nuevasLineas.Add(string.Join(";", campos));
                    }

                    // Sobrescribe el archivo con los cambios
                    File.WriteAllLines(archivoCsv, nuevasLineas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar fecha de último login: " + ex.Message);
            }
        }

        public void AutorizarCampos(string id, string legajoAut)
        {
            string archivoCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "autorizacion.csv");

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

                        if (campos.Length == 7 && campos[0] == id)
                        {
                            // Actualiza la fecha de último login vacia
                            campos[2] = "A";
                            campos[5] = legajoAut;
                            campos[6] = DateTime.Now.ToString("dd/MM/yyyy");
                        }

                        nuevasLineas.Add(string.Join(";", campos));
                    }

                    // Sobrescribe el archivo con los cambios
                    File.WriteAllLines(archivoCsv, nuevasLineas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar fecha de último login: " + ex.Message);
            }
        }
    }
}
