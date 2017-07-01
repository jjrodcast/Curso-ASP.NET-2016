using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class GestionarHorarioAtencion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Medico BuscarMedico(String dni)
        {
            return MedicoLN.getInstance().BuscarMedico(dni);
        }

        [WebMethod]
        public static HorarioAtencion AgregarHorario(String fecha, String hora, String idmedico)
        {
            HorarioAtencion objHorarioAtencion = new HorarioAtencion()
            {
                Fecha = Convert.ToDateTime(fecha),
                Hora = new Hora()
                {
                    hora = hora
                },
                Medico = new Medico()
                {
                    IdMedico = Convert.ToInt32(idmedico)
                }
            };

            return HorarioAtencionLN.getInstance().RegistrarHorarioAtencion(objHorarioAtencion);
        }

        [WebMethod]
        public static List<HorarioAtencion> ListarHorariosAtencion(String idmedico)
        {
            Int32 idMedico = Convert.ToInt32(idmedico);

            return HorarioAtencionLN.getInstance().Listar(idMedico);
        }
    }
}