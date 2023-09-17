using ClinicManagementSystem.Business;
using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinic_management_system
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Empleado empleado = EmpleadoBL
                .getInstance()
                .AccesoSistema(txtUsuario.Text, txtPassword.Text);

            if (empleado != null)
            {
                Response.Write("<script>alert('USUARIO CORRECTO')</script>");
            }
            else
            {
                Response.Write("<script>alert('USUARIO INCORRECTO')</script>");
            }
        }
    }
}
