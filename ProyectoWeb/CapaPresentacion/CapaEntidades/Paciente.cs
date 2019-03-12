using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public String Nombres { get; set; }
        public String ApPaterno { get; set; }
        public String ApMaterno { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public String NroDocumento { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public bool Estado { get; set; }
        public String Imagen { get; set; }
        public HistoriaClinica PHistoriaClinica { get; set; }


        public Paciente() : this(0,"", "", "", 0, ' ', "", "", "", false, "", new HistoriaClinica()) { }


        public Paciente(int _IdPaciente, String _Nombres, String _ApPaterno, String _ApMaterno, int _Edad, char _Sexo
            , String _NroDocumento, String _Direccion, String _Telefono, bool _Estado, String _Imagen, HistoriaClinica _PHistoriaClinica)
        {

            this.IdPaciente = _IdPaciente;
            this.Nombres = _Nombres;
            this.ApPaterno = _ApPaterno;
            this.ApMaterno = _ApMaterno;
            this.Edad = _Edad;
            this.Sexo = _Sexo;
            this.NroDocumento = _NroDocumento;
            this.Direccion = _Direccion;
            this.Imagen = _Imagen;
            this.PHistoriaClinica = _PHistoriaClinica;
        }

    }
}
