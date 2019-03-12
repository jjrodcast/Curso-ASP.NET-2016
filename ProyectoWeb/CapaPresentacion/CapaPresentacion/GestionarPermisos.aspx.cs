using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaPresentacion.Custom;

namespace CapaPresentacion
{
    public partial class GestionarPermisos : BasePage
    {
        // public Int32 gIdEmpleado = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtDNI.Text, "[^0-9]") && txtDNI.Text.Length != 8)
            {
                hfIdEmpleado.Value = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('INGRESAR NÚMERO DE DOCUMENTO VÁLIDO')", true);
                return;
            }

            if (txtDNI.Text.Length == 8)
            {
                Empleado objEmpleado = EmpleadoLN.getInstance().BuscarEmpleado(txtDNI.Text);

                if (objEmpleado != null)
                {
                    if (objEmpleado.ID != 0)
                    {
                        hfIdEmpleado.Value = objEmpleado.ID.ToString();
                        ListarPermisosAsignados(objEmpleado.ID, 0); // 0 es para asignados
                        ListarPermisosNoAsignados(objEmpleado.ID, 1); // 1 es para no asignados
                    }
                    else
                    {
                        hfIdEmpleado.Value = "0";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('NO EXISTE EMPLEADO CON EL DOCUMENTO INGRESADO')", true);
                        //Response.Write("<script>alert('NO EXISTE EMPLEADO CON EL DOCUMENTO INGRESADO.')</script>");
                    }
                }
                else
                {
                    hfIdEmpleado.Value = "0";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('NO EXISTE EMPLEADO CON EL DOCUMENTO INGRESADO')", true);
                    //Response.Write("<script>alert('NO EXISTE EMPLEADO CON EL DOCUMENTO INGRESADO.')</script>");
                }
            }
            else
            {
                hfIdEmpleado.Value = "0";
            }
        }

        private void ListarPermisosAsignados(Int32 IdEmpleado, Int32 opcion)
        {
            var listaPermisos = PermisoLN.getInstance().ListarMenuPermisos(IdEmpleado, opcion);
            grdPermisosAsignados.DataSource = listaPermisos;
            grdPermisosAsignados.DataBind();
        }

        private void ListarPermisosNoAsignados(Int32 IdEmpleado, Int32 opcion)
        {
            var listaPermisos = PermisoLN.getInstance().ListarMenuPermisos(IdEmpleado, opcion);
            grdPermisosNoAsignados.DataSource = listaPermisos;
            grdPermisosNoAsignados.DataBind();
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            Permiso objPermiso = new Permiso();
            for (int i = 0; i < grdPermisosAsignados.Rows.Count; i++)
            {
                var row = grdPermisosAsignados.Rows[i];
                var check = row.FindControl("chkSeleccionar") as CheckBox;
                if (!check.Checked)
                {
                    var IdMenu = Convert.ToInt32((row.FindControl("hfIdMenu") as HiddenField).Value);

                    CapaEntidades.Menu objMenu = new CapaEntidades.Menu();

                    objPermiso.PEmpleado.ID = Convert.ToInt32(hfIdEmpleado.Value);
                    objMenu.IdMenu = IdMenu;
                    objPermiso.PMenu.Add(objMenu);
                }
            }
            if (objPermiso.PMenu.Count > 0)
            {
                bool response = PermisoLN.getInstance().RegistrarEliminarPermiso(objPermiso, 0); // 0 es para Eliminar
                if (response)
                {
                    //Response.Write("<script>alert('SE ELIMINARON LOS PERMISOS.')</script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('SE ELIMINARON LOS PERMISOS')", true);
                    ListarPermisosAsignados(objPermiso.PEmpleado.ID, 0);
                    ListarPermisosNoAsignados(objPermiso.PEmpleado.ID, 1);
                }
                else
                {
                    //Response.Write("<script>alert('ERROR AL ELIMINAR LOS PERMISOS.')</script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('ERROR AL ELIMINAR LOS PERMISOS')", true);
                }
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            Permiso objPermiso = new Permiso(); ;
            for (int i = 0; i < grdPermisosNoAsignados.Rows.Count; i++)
            {
                var row = grdPermisosNoAsignados.Rows[i];
                var check = row.FindControl("chkSeleccionar") as CheckBox;
                if (check.Checked)
                {
                    var IdMenu = Convert.ToInt32((row.FindControl("hfIdMenu") as HiddenField).Value);

                    CapaEntidades.Menu objMenu = new CapaEntidades.Menu();

                    objPermiso.PEmpleado.ID = Convert.ToInt32(hfIdEmpleado.Value);
                    objMenu.IdMenu = IdMenu;
                    objPermiso.PMenu.Add(objMenu);
                }
            }

            if (objPermiso.PMenu.Count > 0)
            {
                bool response = PermisoLN.getInstance().RegistrarEliminarPermiso(objPermiso, 1); // 1 es para Crear
                if (response)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('SE CREARON LOS PERMISOS')", true);
                    //Response.Write("<script>alert('SE CREARON LOS PERMISOS.')</script>");
                    ListarPermisosAsignados(objPermiso.PEmpleado.ID, 0);
                    ListarPermisosNoAsignados(objPermiso.PEmpleado.ID, 1);
                }
                else
                {
                    //Response.Write("<script>alert('ERROR AL CREAR LOS PERMISOS.')</script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('ERROR AL CREAR LOS PERMISOS')", true);
                }
            }
        }
    }
}