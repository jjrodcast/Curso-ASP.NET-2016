using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class HorarioAtencion
    {
        public int IdHorarioAtencion { get; set; }
        public Medico Medico { get; set; }
        public Hora Hora { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }

        public HorarioAtencion()
        {

        }

    }
}
