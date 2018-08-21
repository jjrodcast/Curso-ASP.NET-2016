using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Diagnostico
    {
        public int IdDiagnostico { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
        public DateTime FechaEmision { get; set; }
        public String Observacion { get; set; }
        public String SDiagnostico { get; set; }
        public bool Estado { get; set; }


        public Diagnostico()
        {
            this.HistoriaClinica = new HistoriaClinica();
        }
    }
}
