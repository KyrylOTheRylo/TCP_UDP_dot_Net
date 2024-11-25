using System;
using System.Text;
using System.Net.Sockets;


class TcpEchoClient
{
    static void Main(string[] args)
    {
        if (args.Length != 3 && args.Length !=2)
        {
            throw new ArgumentException("Parameters <Server> <word> [<Port>]");
        }

        String server = args[0];
        Console.WriteLine(server);
        byte[] byteBuffer = Encoding.ASCII.GetBytes(args[1]);
        int servPort = (args.Length == 3) ? Int32.Parse(args[2]) : 7;

        TcpClient client = null;
        NetworkStream stream = null;

        try
        {
            client = new TcpClient(server, servPort);
            Console.WriteLine("Connected to server .... Sending echo string");

            stream = client.GetStream();

            stream.Write(byteBuffer, 0, byteBuffer.Length);

            Console.WriteLine("Sent {0} bytes to server...", byteBuffer.Length);

            int totalByteRcvd = 0;
            int bytesRcvd = 0;

            while ( totalByteRcvd < byteBuffer.Length)
            {
                if ((bytesRcvd = stream.Read(byteBuffer, totalByteRcvd, byteBuffer.Length - totalByteRcvd)) == 0)
                {
                    Console.WriteLine("Connection closed prematurely.");
                    break;
                }
                totalByteRcvd += bytesRcvd;

            }
            Console.WriteLine("Received {0} bytes from server: {1}", totalByteRcvd, Encoding.ASCII.GetString(byteBuffer, 0, totalByteRcvd));


        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
        finally
        {
            stream.Close();
            client.Close();

        }
    }
}

