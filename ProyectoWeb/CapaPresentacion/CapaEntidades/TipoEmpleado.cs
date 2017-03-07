using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class TipoEmpleado
    {
        public int ID { get; set; }
        public String Descripcion { get; set; }
        public bool Estado { get; set; }

        public TipoEmpleado()
        {
        }

        public TipoEmpleado(int ID, String Descripcion, bool Estado)
        {
            this.ID = ID;
            this.Descripcion = Descripcion;
            this.Estado = Estado;
        }
    }
}
