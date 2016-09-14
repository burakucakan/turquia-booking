using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace CARETTA.COM {
    public class Mailing {
        private string m_RealmString;
        private string m_EMailServer;

        public Mailing(string EMailServer)
        {
            m_EMailServer = EMailServer;
        }

        public bool SendEMail(string From, string To, string Subject, string Body, string Bcc, string CC, MailPriority Priority, params object[] ArrayAttachment)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                MailAddress Address = new MailAddress(From);
                Attachment Attachment;

                Msg.From = Address;
                Address = new MailAddress(To);

                Msg.To.Add(Address);
                Msg.Subject = Subject;
                Msg.Body = Body;

                if (CC != "") { Msg.CC.Add(Bcc); }
                if (Bcc != "") { Msg.Bcc.Add(Bcc); }

                if (ArrayAttachment.Length > 0)
                {
                    int i;
                    for (i = 0; i <= ArrayAttachment.Length - 1; i++)
                    {
                        if (System.IO.File.Exists(ArrayAttachment[i].ToString()))
                        {
                            Attachment = new Attachment(ArrayAttachment[i].ToString());
                            Msg.Attachments.Add(Attachment);
                        }
                    }
                }

                Msg.Priority = Priority;
                Msg.IsBodyHtml = true;

                smtp.Host = this.m_EMailServer;

                smtp.Send(Msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
