using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{   
    public static class GuardaString
    {   
        /// <summary>
        /// Metodo de extension para la clase String
        /// Guarda el texto en un archivo en el escritorio, si el archivo existe le agrega el texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.AppendAllText(path+"/"+archivo, "\n "+texto+ "\n ");
            return true;
        }
    }
}
