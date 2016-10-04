using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace PerfectWeddings.Business
{
    public class UtilityHelper
    {
        //Sending Email
        public static bool SendEmail(string to, string subject, string body, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress("mail@tctandobago.com");
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.win11.hosterpk.com";
                smtp.Port = 25;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("mail@tctandobago.com", "f1Ul8S6p5m");// Enter seders User name and password
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method: SendEmail
        /// Comments: Send email using SmtpClient 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool SendEmail(string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();                          
                mail.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["CaliberAdmin"], "Administrator");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["MailHost"]);
                SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["MailPort"].ToString());
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.EnableSsl = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Account"],
                                                                          ConfigurationManager.AppSettings["Password"],
                                                                          ConfigurationManager.AppSettings["MailHost"]);
                

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Clearing Cookes
        public static void ClearCooke(string CookName)
        {
            SetStatus("", CookName);
        }

        //Create Cookes
        public static void SetStatus(string message, string cookieName)
        {
            HttpCookie myCookie = new HttpCookie(cookieName);
            DateTime now = DateTime.Now;

            // Set the cookie value.
            myCookie.Value = message;
            // Set the cookie expiration date.
            myCookie.Expires = now.AddMinutes(0.3);

            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
        //Encrypt Data
        public static string Encrypt(string ToEncrypt)
        {
            if (ToEncrypt == null)
            {
                return string.Empty;
            }

            return Convert.ToBase64String(Encoding.ASCII.GetBytes(ToEncrypt));
        }
        //Decrypt Data
        public static string Decrypt(string cypherString)
        {
            if (cypherString == null)
            {
                return string.Empty;
            }
            return Encoding.ASCII.GetString(Convert.FromBase64String(cypherString));
        }
     
    }
}
