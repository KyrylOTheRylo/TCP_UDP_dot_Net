using System;
using System.Net;
using System.Net.Sockets;

class IPAdressExample
{
    static void PrintHostInfo(String host)
    {
        try
        {
            IPHostEntry hostInfo;

            hostInfo = Dns.GetHostEntry(host);

            Console.WriteLine("\tCanonical Name: " + hostInfo.HostName);

            Console.Write("\tIp Adresses: ");
            foreach (IPAddress ipaddr in hostInfo.AddressList)
            {
                Console.Write(ipaddr.ToString() + " ");
            }
            Console.WriteLine("\n");
            Console.Write("\tAliases: ");
            foreach (String alias in hostInfo.Aliases)
            {
                Console.Write(alias + "");
            }
            Console.WriteLine("\n");


        }
        catch (Exception)
        {
            Console.WriteLine("\tUnable to resolve the host: " + host + " ");
        }
    }

    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Local Host: ");
            String localHostName = Dns.GetHostName();
            Console.WriteLine("\tHost Name:            " + localHostName);

            PrintHostInfo(localHostName);
        }
        catch (Exception)
        {
            Console.WriteLine("Unable to resolve local host \n");

        }

        foreach (String arg in args)
        {
            Console.WriteLine(arg + " :");
            PrintHostInfo(arg);
        }
    }


}
    

