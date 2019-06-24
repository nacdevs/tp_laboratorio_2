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
        public static bool Guardar(this string texto, string archivo) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.AppendAllText(path+"/"+archivo, "\n "+texto+ "\n ");
            return true;
        }
    }
}
