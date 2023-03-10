using System;
using System.Collections.Generic;
using System.Text;

namespace consoleDI
{
    public interface IMailNotification
    {
        public void SendMail(string recipient);
    }

    class Notification : IMailNotification
    {
        private ITrace _trace;
        public Notification(ITrace trace)
        {
            _trace = trace;
        }

        public void SendMail(string recipient)
        {
            _trace.Dump(string.Format("sending out the mail to {0}", recipient));
        }
    }
}
