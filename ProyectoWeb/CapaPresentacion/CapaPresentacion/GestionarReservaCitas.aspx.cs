using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaPresentacion.Custom;

namespace CapaPresentacion
{
    public partial class GestionarReservaCitas : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarEspecialidades();
            }

        }

        private void LlenarGridViewHorariosAtencion()
        {

            if (txtFechaAtencion.Text.Equals(string.Empty))
            {
                Response.Write("<script>alert('No ha ingresado una fecha valida')</script>");
                return;
            }

            // obtenemos fecha
            String fecha = txtFechaAtencion.Text;
            DateTime fechaBusqueda = Convert.ToDateTime(fecha);

            // obtenemos el idEspecialidad
            Int32 idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            

            List<HorarioAtencion> Lista = HorarioAtencionLN.getInstance().ListarHorarioReservas(idEspecialidad, fechaBusqueda);
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

        protected void btnBuscarHorario_Click(object sender, EventArgs e)
        {
            LlenarGridViewHorariosAtencion();
        }

        protected void btnReservarCita_Click(object sender, EventArgs e)
        {
            // ejecutar el guardado de la reserva
            bool isSelected = HorarioAtencionSelccionado();

            if (!idPaciente.Value.Equals(string.Empty) && isSelected)
            {
                Cita objCita = ObtenerCitaSeleccionada();

                bool response = CitaLN.getInstance().RegistrarCita(objCita);

                if (response)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "<script>alert('Cita registrada correctamente.')</script>", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "<script>alert('Error al registrar la cita.')</script>", false);
                }
            }
        }

        private bool HorarioAtencionSelccionado()
        {
            foreach (GridViewRow row in grdHorariosAtencion.Rows)
            {
                CheckBox chkHorario = (row.FindControl("chkSeleccionar") as CheckBox);

                if (chkHorario.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        private Cita ObtenerCitaSeleccionada() 
        {
            Cita objCita = new Cita();

             foreach (GridViewRow row in grdHorariosAtencion.Rows)
            {
                CheckBox chkHorario = (row.FindControl("chkSeleccionar") as CheckBox);

                if (chkHorario.Checked)
                {
                    objCita.Hora = (row.FindControl("lblHora") as Label).Text;
                    objCita.FechaReserva = DateTime.Now;
                    objCita.Paciente.IdPaciente = Convert.ToInt32(idPaciente.Value);

                    string idMedico = (row.FindControl("hfIdMedico") as HiddenField).Value;
                    objCita.Medico.IdMedico = Convert.ToInt32(idMedico);

                    break;
                }
             }
            return objCita;
        }

    }
}