using ClinicManagementSystem.DAL;
using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Business
{
    public class EmpleadoBL
    {
        #region "PATRON SINGLETON"
        private static EmpleadoBL empleado = null;

        private EmpleadoBL() { }

        public static EmpleadoBL getInstance()
        {
            if (empleado == null)
            {
                empleado = new EmpleadoBL();
            }

            return empleado;
        }
        #endregion

        public Empleado AccesoSistema(string user, string pass)
        {
            try
            {
                return EmpleadoDAO.getInstance().AccesoSistema(user, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
