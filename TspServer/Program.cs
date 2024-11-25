using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;


class TcpServer
    
{
    private const int BUFFSIZE = 32;
    static void Main(string[] args)
    {
        //byte[] bytes = Encoding.ASCII.GetBytes("server.exampe.com");
        //IPAddress address = new IPAddress(bytes);
        int port = 7;
        TcpListener server = new TcpListener(IPAddress.Any, port);
        server.Start();
        byte[] receiveBuffer = new byte[BUFFSIZE];
        int bytesRcvd = 0;
        while (true)
        {
            Console.WriteLine("Working");
            TcpClient connection = null;
            NetworkStream stream = null;
            try
            {
                connection = server.AcceptTcpClient();
                stream= connection.GetStream();
                Console.WriteLine("Handling stream {0}", connection);
                int totalBytesEchoed = 0;
                while ((bytesRcvd = stream.Read(receiveBuffer, 0, receiveBuffer.Length)) > 0) {
                    stream.Write(receiveBuffer, 0, bytesRcvd);
                    totalBytesEchoed += bytesRcvd;
                }
                Console.WriteLine("Bytes echoed {0}", totalBytesEchoed);

                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e);
                stream.Close();
                
            }


        }

    }
}

