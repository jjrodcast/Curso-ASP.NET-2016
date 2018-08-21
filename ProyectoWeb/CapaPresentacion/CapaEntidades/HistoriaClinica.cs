using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class HistoriaClinica
    {
        public int IdHistoriaClinica { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime FechaApertura { get; set; }
        public bool Estado { get; set; }


        public HistoriaClinica()
        {
            Paciente = new Paciente();
        }
    }
}
