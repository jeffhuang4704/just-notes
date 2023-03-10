using System;
using System.Collections.Generic;
using System.Text;

namespace consoleDI
{
    class SchedulerTasks
    {
        private IMailNotification _notification;

        public SchedulerTasks(IMailNotification notification)
        {
            _notification = notification;
        }

        public void Run()
        {
            _notification.SendMail("Jeff_Huang@hotmail.com");
        }
    }
}
