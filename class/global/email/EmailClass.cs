using System.Net.Mail;
using System.Xml;

namespace Elanat
{
    public class EmailClass
    {
        public void SendMail(string To, string Subject, string Body, bool WithElanatSubject = false, bool WithElanatBody = false)
        {
            XmlNode node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/email");

            string MailHost = node["host"].InnerText.Trim();
            string MailPort = node["port"].InnerText.Trim();
            string MailSender = node["sender"].InnerText.Trim();
            string MailBeforeSubject = (WithElanatSubject)? node["text_before_email_subject"].InnerText : null;
            string MailAfterSubject = (WithElanatSubject)? node["text_after_email_subject"].InnerText : null;
            string MailBeforeBody = (WithElanatBody) ? node["text_before_email_body"].InnerText : null;
            string MailAfterBody = (WithElanatBody)? node["text_after_email_body"].InnerText : null;
            bool MailUseSsl = (node["use_https"].Attributes["active"].Value == "true");

            string MailPassword = Security.GetCodeIni("mail_password");

            SmtpClient sc = new SmtpClient(MailHost, int.Parse(MailPort));

            sc.Credentials = new System.Net.NetworkCredential(MailSender, MailPassword);
            sc.UseDefaultCredentials = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.EnableSsl = MailUseSsl;
            MailMessage mm = new MailMessage(MailSender, To, MailBeforeSubject + Subject + MailAfterSubject, MailBeforeBody + Body + MailAfterBody);
            sc.Send(mm);
        }
    }
}