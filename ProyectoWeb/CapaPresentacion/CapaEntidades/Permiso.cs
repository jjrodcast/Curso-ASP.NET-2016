using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Permiso
    {
        public Empleado PEmpleado { get; set; }
        public List<Menu> PMenu { get; set; }
        public bool Estado { get; set; }

        public Permiso(Empleado Empleado, List<Menu> LMenu, bool Estado)
        {
            this.PEmpleado = Empleado;
            this.PMenu = LMenu;
            this.Estado = Estado;
        }

        public Permiso() : this(new Empleado(), new List<Menu>(), false) { }
    }
}
