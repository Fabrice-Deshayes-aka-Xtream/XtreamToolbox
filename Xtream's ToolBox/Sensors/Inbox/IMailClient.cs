using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace XtreamToolbox.Utils.Mail
{
    interface IMailClient
    {
        void Connect(String hostname, String login, String password, int port, int timeout);
        void Connect(String hostname, String login, String password, int port);
        void Connect(String hostname, String login, String password);
        int GetNbMailInbox();
        Dictionary<String, StringCollection> GetMailHeader(int idMail);
        void Disconnect();
    }
}
