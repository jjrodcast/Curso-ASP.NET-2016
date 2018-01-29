using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogicaNegocio
{
    public class HorarioAtencionLN
    {
        #region "PATRON SINGLETON"
        private static HorarioAtencionLN horarioAtencion = null;
        private HorarioAtencionLN() { }
        public static HorarioAtencionLN getInstance()
        {
            if (horarioAtencion == null)
            {
                horarioAtencion = new HorarioAtencionLN();
            }
            return horarioAtencion;
        }
        #endregion

        public HorarioAtencion RegistrarHorarioAtencion(HorarioAtencion objHorarioAtencion)
        {
            try
            {
                return HorarioAtencionDAO.getInstance().RegistrarHorarioAtencion(objHorarioAtencion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HorarioAtencion> Listar(Int32 idMedico)
        {
            try
            {
                return HorarioAtencionDAO.getInstance().Listar(idMedico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HorarioAtencion> ListarHorarioReservas(Int32 IdEspecialidad, DateTime Fecha)
        {
            try
            {
                return HorarioAtencionDAO.getInstance().ListarHorarioReservas(IdEspecialidad, Fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idHorarioAtencion)
        {
            try
            {
                return HorarioAtencionDAO.getInstance().Eliminar(idHorarioAtencion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(HorarioAtencion objHorario)
        {
            try
            {
                return HorarioAtencionDAO.getInstance().Editar(objHorario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
