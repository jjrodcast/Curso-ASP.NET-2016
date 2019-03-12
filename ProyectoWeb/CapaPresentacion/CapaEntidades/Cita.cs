using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Cita
    {
        public int IdCita { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Observacion { get; set; }
        public char Estado { get; set; }
        public string Hora { get; set; }
        //public Hora EHora { get; set; }

        public Cita() : this(0,new Medico(), new Paciente(), DateTime.Now, "", ' ', "")
        {
        }

        public Cita(int _IdCita, Medico _Medico, Paciente _Paciente, DateTime _FechaReserva, string _Observacion
            , char _Estado, string _Hora)
        {
            this.IdCita = _IdCita;
            this.Medico = _Medico;
            this.Paciente = _Paciente;
            this.FechaReserva = _FechaReserva;
            this.Observacion = _Observacion;
            this.Estado = _Estado;
            this.Hora = _Hora;
        }

    }
}
