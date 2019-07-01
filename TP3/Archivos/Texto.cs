using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivos, string datos)
        {
            {
                StreamWriter sw = new StreamWriter(archivos);
                bool ret = false;
                try
                {
                    sw.Write(datos);
                    ret = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
                finally
                {
                    sw.Close();
                }
                return ret;
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = new StreamReader(archivo);
            bool ret = false;
            try
            {
                datos = sr.ReadToEnd();
                ret = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            finally
            {
                sr.Close();
            }
            return ret;
        }
    }
}
