using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace Xtream_ToolBox.Utils.Mail {
    interface IMailClient {
        void connect(String hostname, String login, String password, int port, int timeout);
        void connect(String hostname, String login, String password, int port);
        void connect(String hostname, String login, String password);
        int getNbMailInbox();
        Dictionary<String, StringCollection> getMailHeader(int idMail);
        void disconnect();
    }
}
