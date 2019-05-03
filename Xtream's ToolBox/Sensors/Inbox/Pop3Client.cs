using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Collections.Specialized;

namespace XtreamToolbox.Utils.Mail
{
    class Pop3Client : IMailClient, IDisposable
    {

        private TcpClient sockServer = null;
        private NetworkStream ns = null;
        private StreamReader sr = null;

        private String hostname = null;
        private String login = null;
        private String password = null;
        private int port = 110;
        private int timeout = 6000;

        private bool connected = false;

        public void Connect(String phostname, String plogin, String ppassword)
        {
            Connect(phostname, plogin, ppassword, port, timeout);
        }

        public void Connect(String phostname, String plogin, String ppassword, int pport)
        {
            Connect(phostname, plogin, ppassword, pport, timeout);
        }

        public void Connect(String phostname, String plogin, String ppassword, int pport, int ptimeout)
        {
            hostname = phostname;
            login = plogin;
            password = ppassword;
            port = pport;
            timeout = ptimeout;

            try
            {
                sockServer = new TcpClient(hostname, port)
                {
                    ReceiveTimeout = timeout
                };
                ns = sockServer.GetStream();
                sr = new StreamReader(ns);
                Receive(sr);
                Send("user " + login + "\r\n", ns);
                Receive(sr);
                Send("pass " + password + "\r\n", ns);
                Receive(sr);
                connected = true;
            }
            catch (Exception exception)
            {
                connected = false;
                Console.WriteLine(exception.Message);
            }
        }

        public int GetNbMailInbox()
        {
            int nbMsg = 0;

            if (connected)
            {
                Send("stat\r\n", ns);
                try
                {
                    String[] tempS = Receive(sr).Split(' ');
                    nbMsg = int.Parse(tempS[1]);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            return nbMsg;
        }

        public Dictionary<String, StringCollection> GetMailHeader(int idMail)
        {
            String popResponse, key, tmpValue;
            StringCollection value;
            int positionOfDoubleDot;
            Dictionary<String, StringCollection> header = new Dictionary<String, StringCollection>();

            if (connected)
            {
                Send("top " + idMail + " 0\r\n", ns);
                popResponse = Receive(sr);

                while ((popResponse != null) && (!popResponse.Equals(".")))
                {
                    //Console.WriteLine(popResponse);
                    popResponse = popResponse.Trim();
                    positionOfDoubleDot = popResponse.IndexOf(':');
                    if (positionOfDoubleDot != -1)
                    {
                        key = popResponse.Substring(0, positionOfDoubleDot).Trim().ToUpper();
                        tmpValue = popResponse.Substring(positionOfDoubleDot + 1, popResponse.Length - (positionOfDoubleDot + 1)).Trim().ToUpper();
                        //Console.WriteLine("Key : " + key + " / Value : " + tmpValue);
                        if (header.ContainsKey(key))
                        {
                            header.TryGetValue(key, out value);
                            value.Add(tmpValue);
                            header.Remove(key);
                            header.Add(key, value);
                        }
                        else
                        {
                            value = new StringCollection
                            {
                                tmpValue
                            };
                            header.Add(key, value);
                        }
                    }
                    popResponse = Receive(sr);
                }
            }

            return header;
        }

        public void Disconnect()
        {
            if (connected)
            {
                Send("quit\r\n", ns);
            }
            connected = false;

            if (sr != null)
            {
                sr.Close();
                sr.Dispose();
            }
            if (ns != null)
            {
                ns.Close();
                ns.Dispose();
            }
            if (sockServer != null)
            {
                sockServer.Close();
            }
        }

        // Envoi une commande pop
        private void Send(String bToSend, NetworkStream ns)
        {
            try
            {
                Byte[] bOutStream;
                if ((ns != null) && (ns.CanWrite))
                {
                    ns.Write(bOutStream = ASCIIEncoding.ASCII.GetBytes(bToSend), 0, bOutStream.Length);
                    ns.Flush();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        // Récupére la réponse é une commande pop
        private String Receive(StreamReader sr)
        {
            String response = "";
            try
            {
                response = sr.ReadLine();
                sr.BaseStream.Flush();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return response;
        }

        public void Dispose()
        {
            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }
}
