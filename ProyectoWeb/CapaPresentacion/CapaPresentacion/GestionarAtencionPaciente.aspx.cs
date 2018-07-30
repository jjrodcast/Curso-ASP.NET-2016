using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class GestionarAtencionPaciente : System.Web.UI.Page
    {
        private static String COMMAND_REGISTER = "Registrar";
        private static String COMMAND_CANCEL = "Cancelar";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDataList();
                lblFechaAtencion.Text = DateTime.Now.ToShortDateString();
            }

        }

        private void llenarDataList()
        {
            List<Cita> ListaCitas = CitaLN.getInstance().ListarCitas();
            dlAtencionMedica.DataSource = ListaCitas;
            dlAtencionMedica.DataBind();
        }

        protected void dlAtencionMedica_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == COMMAND_REGISTER)
            {
                // realizar el registro de la atención
                // Redirección a la página de GestionarAtencionCita.aspx
                String IdCita = (e.Item.FindControl("hdIdCita") as HiddenField).Value;
                Response.Redirect("GestionarAtencionCita.aspx?idcita=" + IdCita);
            }
            else if (e.CommandName == COMMAND_CANCEL)
            {
                // realizar la cancelación de la reserva de cita
            }
        }
    }
}