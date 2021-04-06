using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Tools
{
    public class LlenaCero
    {
        public static string LlenaConCero(string cadena,int contador, string relleno)
        {
            string scadena = "";
            if (cadena == null || contador <= 0)
            {
                return "";
            }
            if (cadena.Length > contador)
            {
                cadena = cadena.Substring(contador, (cadena.Length - contador)+1 );
            }
            int j = int.Parse(cadena) + 1;
            scadena = j.ToString();
            for (int i = 0; i < contador-cadena.Length; i++)
            {
                scadena = relleno + scadena;
            }

            return scadena;
        }
    }
}
