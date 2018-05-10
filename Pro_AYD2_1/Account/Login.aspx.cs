using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Pro_AYD2_1.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web.Providers.Entities;

namespace Pro_AYD2_1.Account
{
    public partial class Login : Page
    {
        DBComun cn = new DBComun();
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Habilite esta opción una vez tenga la confirmación de la cuenta habilitada para la funcionalidad de restablecimiento de contraseña
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("select * from usuario where email = '"+Email.Text+"' and pass = '"+Password.Text+"';",cn.conexion);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count.ToString()=="1")
            {
                Session["user"] = Email.Text;
                Response.Redirect("WebForm1.aspx");
            }

            else
            {
                FailureText.Text = "Intento de inicio de sesión no válido";
                ErrorMessage.Visible = true;

            }
     /*       if (IsValid)
            {
                // Validar la contraseña del usuario
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // Esto no cuenta los errores de inicio de sesión hacia el bloqueo de cuenta
                // Para habilitar los errores de contraseña para desencadenar el bloqueo, cambie a shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Intento de inicio de sesión no válido";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        
    */}
        
    }
}