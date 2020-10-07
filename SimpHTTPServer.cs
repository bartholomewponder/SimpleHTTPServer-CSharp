using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SimpHTTPServer
{
#region ServerClasses
    public class SimpHTTPServer
    {

        int serverID {get; set;}
        string serverName {get; set;}

        /* 
         * Method: SimpHTTPServer (constructor)
         * Class: SimpHTTPServer
         * Args: 
         *     int port - takes the number of a port as an argument. 
         *     
         *     
              */
        public static async Task SimpHTTPServer(int port)
        {

        }
        public static async Task handleGETRequest(HttpProcessor proc)
        {

        }
        public static async Task handlePUTRequest(HttpProcessor proc) 
        {

        }
        public static async Task handlePOSTRequest(HttpProcessor proc)
        {

        }
        public static void RunServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, srvPort);
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting for a client to connect...");
                TcpClient client = listener.AcceptTCPClient();
                ProcessClient();
            }
        }
        public static void ProcessClient(TcpClient client)
        {

        }
    }
    public class SimpHTTPS : SimpHTTPServer 
    {
        /* 
         * Method: SimpHTTPS (constructor)
         * Class: SimpHTTPS
         * Args: 
         *     int port - takes the number of a port as an argument. 
         *     EncryptionPolicy ep - takes an encryption policy for HTTPS to use
         *     
      */
    }
#endregion
#region SocketClasses
    public class GetSocket
    {
        public static Socket ConnectSocket(string server, int port)
        {
            Socket sock = null;
            IPHostEntry hostEntry = null;

            hostEntry = Dns.GetHostEntry(server);

            foreach(IPAdress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSock = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSock.Connect(ipe);

                if(tempSock.Conected)
                {
                    sock = tempSock;
                    break;
                }
                else 
                {
                    continue;
                }
           }
           return s;
        }
       private static string SocketSendReceive(string server, int port) 
       {
           //GET request to server, place in byte array
           string request = "GET / HTTP/1.1.\r\nHost: " + server + "\r\nConnection: Close\r\n\r\n";
           Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
           Byte[] bytesReceived = new Byte[256];
           string page = "";

           //create a socket connection with server and port
           using(Socket s = ConnectSocket(server, port)) {
               if (s == null) 
                   return("Connection failed");

               //Send a request to the server
               s.Send(bytesSent, bytesSent.Length, 0);

               //receive the server homepage content
               int bytes = 0;
               page = "Default HTML page on " + server +  ": \r\n";

               //block until the page is transmitted
               do {
                   bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                   page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
               } while (bytes > 0);
           }
           return page;
       }
    }
    public class PutSocket
    {

    }
    public class PostSocket
    {

    }
#endregion

#region LogClasses
    public class Logger
    {

    }
#endregion
}

