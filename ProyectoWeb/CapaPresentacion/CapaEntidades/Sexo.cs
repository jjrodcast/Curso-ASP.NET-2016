using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Sexo
    {
        public String IdSexo { get; set; }
        public String Nombre { get; set; }

        public Sexo() : this("", "") { }

        public Sexo(String IdSexo, String Nombre)
        {
            this.IdSexo = IdSexo;
            this.Nombre = Nombre;
        }
    }
}
