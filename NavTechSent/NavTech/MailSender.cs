using System.Net;
using System.Net.Mail;

namespace NavTech
{
    public class MailSender
    {

        public static void Sendmail()
        {
            //can Assign parameters To this values
             string toAddress = null;
            //int id = 1;
            //string shippingaddress =null;
            //string   date =null;
            //int status = 1;

           

            string msgbody = "Hello -- Your Order Place Order Id Is -- Expected Delivery Is -- ";
            MailMessage mailmsg = new MailMessage("<FromAdd>", toAddress);

            mailmsg.IsBodyHtml = true;
            mailmsg.Subject = "Order Information !";
            mailmsg.Body = msgbody;


            SmtpClient sender = new SmtpClient("smtp.gmail.com", 587); // Can Be Any server
            NetworkCredential MailCrediential = new NetworkCredential("<userid>", "< password>");

            sender.Credentials = MailCrediential;
            sender.EnableSsl = true;
            sender.Send(mailmsg);


        }

    }
}