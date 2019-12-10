using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Data;
using System.Net;
using System.Configuration;

namespace PAS_regenerated
{
    public partial class forgotPassword : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            try{
            // if condition for valid email ....
            SqlConnection conn = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select [e-mail] from admin_login where [e-mail]='" + txtEmail.Text.Trim() + "' union select [e-mail] from cashier_login where [e-mail]='" + txtEmail.Text.Trim() + "' union select [e-mail] from pharmacist_login where [e-mail]='" + txtEmail.Text.Trim() + "' ";
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                conn.Close();
                rdr.Close();
                
            
            
            //create your variables
            string strSubject = "Your Password reset information";
            string strFromEmail = "some1visit@gmail.com";
            string strFromName = " Medic-Care Administrator";
            string strNewPassword = GeneratePassword().ToString();  //password generator function string.

            
                //create the new mail message
                MailMessage MailMsg = new MailMessage();

                //create the FROM
                MailMsg.From = new MailAddress(strFromEmail);

                //create the subject
                MailMsg.Subject = strSubject;

                //We obviously need to create the TO - otherwise it goes nowhere.
                MailMsg.To.Add(txtEmail.Text); //assuming there was a form to fill out and they put the right email address in.

                MailMsg.IsBodyHtml = true; //I decided to make it html - so I could format the text.
                MailMsg.Body = "<h1>The following email was sent to you by " + strFromName + ".</h1><br />";
                MailMsg.Body += "<p>Apparently, you needed your password reset - So here it is: <br />";
                MailMsg.Body += " Your New Password is : <b>" + strNewPassword + "</b><br />";
                MailMsg.Body += "If you didn't request this, then - oops, you might wanna think about changing it, now. </b>";
                //MailMsg.Body += "<p>Click the following link to change your password:</p>";
                //MailMsg.Body += "<p>http://www.pharmacy.com/passwordChange/Default.aspx</P>";

                //utilizing SMTP (simple mail transfer protocol)
                SmtpClient smtp = new SmtpClient();
                NetworkCredential mailauthentication = new NetworkCredential();
                mailauthentication.UserName = "some1visit@gmail.com";
                mailauthentication.Password = "somevisits";
                smtp.Host = "smtp.gmail.com"; //if my domain had a way of sending out emails.
                smtp.Port = 587;
                smtp.EnableSsl = true; //Gmail works on Server Secured Layer
                smtp.Credentials = mailauthentication;
                smtp.Send(MailMsg);  //send it


                SqlConnection con22 = new SqlConnection(CS);
                SqlCommand cmd33 = new SqlCommand();
                cmd33.Connection = con22;
                con22.Open();

                cmd33.CommandText = "UPDATE admin_login SET [password]='" + strNewPassword + "' where [e-mail]='" + txtEmail.Text.Trim() + "'";
                    //SqlDataReader rdr33 = cmd33.ExecuteReader();
                    cmd33.ExecuteNonQuery();
                    cmd33.CommandText = "UPDATE pharmacist_login SET [password]='" + strNewPassword + "' where [e-mail]='" + txtEmail.Text.Trim() + "'";
                    cmd33.ExecuteNonQuery();

                    cmd33.CommandText = "UPDATE cashier_login SET [password]='" + strNewPassword + "' where [e-mail]='" + txtEmail.Text.Trim() + "'";
                    cmd33.ExecuteNonQuery();

                con22.Close();
                lbltxt.Text = "Message Sent Successfully";  //shows that email is sent.
            }
             else
            {
             lbltxt.Text = ( txtEmail.Text.Trim() + " Email ID does not Exist!");
            }
            }
            catch
            {
                lbltxt.Text = "Error: Network not found"; //+ex.ToString();  //or tell the person that they screwed up and it's all their fault.... or what the actual error was.
            }
        }
        
  



        public string GeneratePassword()
        {
            //how many characters the string will contain.
            string PasswordLength = "6";
            //this will hold the new generated password
            string NewPassword = "";

            //which characters are allowed in this new password
            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

            // working with an array...
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);

            string IDString = "";
            string temp = "";

            //utilize the "random" class
            Random rand = new Random();

            //and lastly - loop through the generation process...
            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;
            }

            return NewPassword;
        }
    }
  
    }
