using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioPersistencia
    {

        public string BuscarLineaCredencial(string usuario)
        {
            var lineas = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "credenciales.csv")).Skip(1); // salta encabezado
            foreach (string linea in lineas)
            {
                string[] campos = linea.Split(';');
                if (campos.Length > 1 && campos[1] == usuario)
                {
                    return linea;
                }
            }
            return null;
        }

        public bool EstaBloqueado(string legajo)
        {
            //var bloqueados = File.ReadAllLines("DataBase/Tablas/usuario_bloqueado.csv").Skip(1);
            var bloqueados = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "usuario_bloqueado.csv")).Skip(1);
            foreach (string linea in bloqueados)
            {
                if (linea.Trim() == legajo)
                {
                    return true;
                }
            }
            return false;
        }

        public void RegistrarIntento(string legajo)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "login_intentos.csv");

            Directory.CreateDirectory(Path.GetDirectoryName(path)); // Asegura que la carpeta exista

            // Leer contenido para chequear salto de línea
            string contenido = File.ReadAllText(path);

            // Si no termina en salto de línea, lo agrego ANTES de abrir StreamWriter
            if (!contenido.EndsWith("\n") && !contenido.EndsWith("\r\n"))
            {
                File.AppendAllText(path, Environment.NewLine);
            }

            // Ahora abro StreamWriter para agregar la línea
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{legajo};{DateTime.Now:dd/MM/yyyy}");
            }
        }

        public int ContarIntentosFallidos(string legajo)
        {
            var lineas = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "login_intentos.csv"));
            int contador = 0;

            foreach (string linea in lineas)
            {
                string[] campos = linea.Split(';');
                if (campos.Length > 0 && campos[0] == legajo)
                {
                    contador++;
                }
            }

            return contador;
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

        public void BloquearUsuario(string legajo)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "usuario_bloqueado.csv");

            Directory.CreateDirectory(Path.GetDirectoryName(path)); // Asegura que la carpeta exista

            // Leer contenido para chequear salto de línea
            string contenido = File.ReadAllText(path);

            // Si no termina en salto de línea, lo agrego ANTES de abrir StreamWriter
            if (!contenido.EndsWith("\n") && !contenido.EndsWith("\r\n"))
            {
                File.AppendAllText(path, Environment.NewLine);
            }

            // Ahora abro StreamWriter para agregar la línea
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{legajo}");
                LimpiarIntentos(legajo);
            }
        }

        public int ObtenerPerfilPorLegajo(string legajo)
        {
            var lineas = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "usuario_perfil.csv")).Skip(1);

      
            foreach (string linea in lineas)
            {
                string[] campos = linea.Split(';');

                // Verificamos si el primer campo coincide con el legajo
                if (campos.Length > 1 && campos[0] == legajo)
                {
                    // Devolvemos el segundo campo (idPerfil) convertido a número
                    return int.Parse(campos[1]);
                }
            }

            // Si no encontramos ninguna línea con ese legajo, lanzamos una excepción
            throw new Exception("Perfil no encontrado");
        }

        public Credencial CrearUsuarioDesdeRegistro(string registro, int idPerfil)
        {
            
            switch (idPerfil)
            {
                case 1:
                    return new Operador(registro);
                case 2:
                    return new Supervisor(registro);
                case 3:
                    return new Administrador(registro);
                default:
                    throw new Exception("Perfil desconocido");
            }
        }

        public void ActualizarFechaUltimoLogin(string legajo)
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
                            // Actualiza la fecha de último login con la fecha actual
                            campos[4] = DateTime.Now.ToString("dd/MM/yyyy");
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

        public string BuscarLineaLegajo(string legajo)
        {
            var lineas = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "Tablas", "credenciales.csv")).Skip(1); // salta encabezado
            foreach (string linea in lineas)
            {
                string[] campos = linea.Split(';');
                if (campos.Length > 1 && campos[0] == legajo)
                {
                    return linea;
                }
            }
            return null;
        }
    }
}
