using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Pro_AYD2_1.Models;

namespace Pro_AYD2_1.Account
{
    public partial class Register : Page
    {

        DBComun cn = new DBComun();
        string cadenainsertar;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

            //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}

            registrar_usuario();
        }

        public void registrar_usuario()
        {

            if (Password.Text.Equals(ConfirmPassword.Text))
            {
                cadenainsertar = "insert into usuario (nombre, apellido, dpi, cuenta, saldoIni, email, pass) values ('" + nombre.Text + "','" + apellido.Text + "','" + dpi.Text + "','" + cuenta.Text + "','" + saldo.Text + "','" + Email.Text + "','" + ConfirmPassword.Text + "');";
                cn.insertardatos(cadenainsertar);
                string mensaje = "Usuario creado con exitos";
                ClientScript.RegisterStartupScript(typeof(Page), "alert", "<script language=JavaScript>alert('" + (mensaje) + "');</Script>");
                nombre.Text = "";
                apellido.Text = "";
                dpi.Text = "";
                cuenta.Text = "";
                saldo.Text = "";
                Email.Text = "";
                Password.Text = "";
                ConfirmPassword.Text = "";
            }
            else
            {
                string mensaje = "Error al confirmar contraseña";
                ClientScript.RegisterStartupScript(typeof(Page), "alert", "<script language=JavaScript>alert('" + (mensaje) + "');</Script>");
                Password.Text = "";
                ConfirmPassword.Text = "";
            }
        }
    }
}