using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Collections.Specialized;

namespace Xtream_ToolBox.Utils.Mail {
    class Pop3Client : IMailClient {

        private TcpClient sockServer = null;
        private NetworkStream ns = null;
        private StreamReader sr = null;

        private String hostname = null;
        private String login = null;
        private String password = null;
        private int port = 110;
        private int timeout = 6000;

        private bool connected = false;

        public void connect(String phostname, String plogin, String ppassword){
            connect(phostname, plogin, ppassword, port, timeout);
        }

        public void connect(String phostname, String plogin, String ppassword, int pport) {
            connect(phostname, plogin, ppassword, pport, timeout);
        }

        public void connect(String phostname, String plogin, String ppassword, int pport, int ptimeout) {
            hostname = phostname;
            login = plogin;
            password = ppassword;
            port = pport;
            timeout = ptimeout;

            try {
                sockServer = new TcpClient(hostname, port);
                sockServer.ReceiveTimeout = timeout;
                ns = sockServer.GetStream();
                sr = new StreamReader(ns);
                receive(sr);
                send("user " + login + "\r\n", ns);
                receive(sr);
                send("pass " + password + "\r\n", ns);
                receive(sr);
                connected = true;
            } catch(Exception exception) {
                connected = false;
                Console.WriteLine(exception.Message);
            }
        }

        public int getNbMailInbox() {
            int nbMsg = 0;

            if (connected) {
                send("stat\r\n", ns);
                try {
                    String[] tempS = receive(sr).Split(' ');
                    nbMsg = int.Parse(tempS[1]);
                } catch (Exception exception) {
                    Console.WriteLine(exception.Message);
                }
            }

            return nbMsg;
        }

        public Dictionary<String, StringCollection> getMailHeader(int idMail) {
            String popResponse, key, tmpValue;
            StringCollection value;
            int positionOfDoubleDot;
            Dictionary<String, StringCollection> header = new Dictionary<String, StringCollection>();

            if (connected) {
                send("top " + idMail + " 0\r\n", ns);
                popResponse = receive(sr);

                while ((popResponse!=null) && (!popResponse.Equals("."))) {
                    //Console.WriteLine(popResponse);
                    popResponse = popResponse.Trim();
                    positionOfDoubleDot = popResponse.IndexOf(':');
                    if (positionOfDoubleDot != -1) {
                        key = popResponse.Substring(0, positionOfDoubleDot).Trim().ToUpper();
                        tmpValue = popResponse.Substring(positionOfDoubleDot + 1, popResponse.Length - (positionOfDoubleDot + 1)).Trim().ToUpper();
                        //Console.WriteLine("Key : " + key + " / Value : " + tmpValue);
                        if (header.ContainsKey(key)) {
                            header.TryGetValue(key, out value);
                            value.Add(tmpValue);
                            header.Remove(key);
                            header.Add(key, value);
                        } else {
                            value = new StringCollection();
                            value.Add(tmpValue);
                            header.Add(key, value);
                        }
                    }
                    popResponse = receive(sr);
                }
            }

            return header;
        }
        
        public void disconnect() {
            if (connected) {
                send("quit\r\n", ns);
            }
            connected = false;

            if (sr != null) {
                sr.Close();
                sr.Dispose();
            }
            if (ns != null) {
                ns.Close();
                ns.Dispose();
            }
            if (sockServer != null) {
                sockServer.Close();
            }
        }

        // Envoi une commande pop
        private void send(String bToSend, NetworkStream ns) {
            try {
                Byte[] bOutStream;
                if ((ns != null) && (ns.CanWrite)) {
                    ns.Write(bOutStream = ASCIIEncoding.ASCII.GetBytes(bToSend), 0, bOutStream.Length);
                    ns.Flush();
                }
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
        }

        // Récupère la réponse à une commande pop
        private String receive(StreamReader sr) {
            String response = "";
            try {
                response = sr.ReadLine();
                sr.BaseStream.Flush();
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
            return response;
        }
    }
}
