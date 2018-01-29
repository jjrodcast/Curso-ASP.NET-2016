using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class GestionarReservaCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridView();
                LlenarEspecialidades();
            }
        }

        private void LlenarGridView()
        {
            String fecha = "29/01/2018";
            DateTime fechaBusqueda = Convert.ToDateTime(fecha);
            List<HorarioAtencion> Lista = HorarioAtencionLN.getInstance().ListarHorarioReservas(1, fechaBusqueda);
            grdHorariosAtencion.DataSource = Lista;
            grdHorariosAtencion.DataBind();
        }

        private void LlenarEspecialidades()
        {
            List<Especialidad> Lista = EspecialidadLN.getInstance().Listar();

            ddlEspecialidad.DataSource = Lista;
            ddlEspecialidad.DataValueField = "IdEspecialidad";
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataBind();
        }

        [WebMethod]
        public static Paciente BuscarPacienteDNI(String dni)
        {
            return PacienteLN.getInstance().BuscarPacienteDNI(dni);
        }

    }
}