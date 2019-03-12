using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public String Nombre { get; set; }
        public bool IsSubMenu { get; set; }
        public String Url { get; set; }
        public int IdMenuParent { get; set; }
        public List<Menu> SubMenu { get; set; }
        public bool Estado { get; set; }
        public bool Show { get; set; }

        public Menu(int _IdMenu, String _Nombre, bool _IsSubMenu, String _Url, int _IdMenuParent, List<Menu> _SubMenu, bool _Estado, bool _Show)
        {
            this.IdMenu = _IdMenu;
            this.Nombre = _Nombre;
            this.IsSubMenu = _IsSubMenu;
            this.Url = _Url;
            this.IdMenuParent = _IdMenuParent;
            this.SubMenu = _SubMenu;
            this.Estado = _Estado;
            this.Show = _Show;
        }

        public Menu() : this(0, "", false, "", 0, new List<Menu>(), false, false) { }
    }
}
