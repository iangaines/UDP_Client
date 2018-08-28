
/* 
* The purpose of this program is to provide a minimal example of using UDP to 
* send data.
* It transmits broadcast packets and displays the text in a console window.
* This was created to work with the program UDP_Minimum_Listener.
* Run both programs, send data with Talker, receive the data with Listener.
*/
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Boolean done = false;
        Boolean exception_thrown = false;
        Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        string serverIPAddress = "67.191.68.182"; //67.191.68.182 10.0.0.77

        //IPAddress send_to_address = IPAddress.Parse("67.191.68.182"); //67.191.68.182 10.0.0.77
        //IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);

        UdpClient sender = new UdpClient();
        //sender.Connect("67.191.68.182", 11000);
        sender.Connect(serverIPAddress, 11000);
        //sender.Connect("10.0.0.77", 11000);
        //sender.Connect(serverIPAddress, 11000);

        Console.WriteLine("Enter text to send, blank line to quit");
        string text_to_send = Console.ReadLine();
        byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);
        Byte[] senddata = Encoding.ASCII.GetBytes(text_to_send);
        sender.Send(senddata, senddata.Length);

        string received_data;
        byte[] receive_byte_array;
        IPEndPoint groupEP = new IPEndPoint(((IPEndPoint)sender.Client.LocalEndPoint).Address/*IPAddress.Any*/, ((IPEndPoint)sender.Client.LocalEndPoint).Port);

        receive_byte_array = sender.Receive(ref groupEP);
        received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);

        int sentport = ((IPEndPoint)sender.Client.LocalEndPoint).Port;
        sender.Close();




        UdpClient listener = new UdpClient(sentport);
        listener.Connect(serverIPAddress, Int32.Parse(received_data));
        listener.Send(senddata, senddata.Length);
        Console.WriteLine("New Server Port: " + received_data);

        Console.WriteLine("Waiting for broadcast");
        receive_byte_array = listener.Receive(ref groupEP);
        Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
        received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
        Console.WriteLine("Received: {0}\n\n", received_data);

        //listener.Connect(groupEP);

        while (!done)
        {

            if (text_to_send.Length == 0)
            {
                done = true;
            }
            else
            {
                // the socket object must have an array of bytes to send.
                // this loads the string entered by the user into an array of bytes.

                //UdpClient sender = new UdpClient();
                //sender.Connect("10.0.0.77", 11000);
                //Byte[] senddata = Encoding.ASCII.GetBytes(text_to_send);
                //sender.Send(senddata, senddata.Length);



                // Remind the user of where this is going.
                /*Console.WriteLine("sending to address: {0} port: {1}",
                sending_end_point.Address,
                sending_end_point.Port);
                try
                {
                    sending_socket.SendTo(send_buffer, sending_end_point);
                    Console.WriteLine("Local UDP EndPoint" + ((IPEndPoint)sending_socket.LocalEndPoint).Address + " : " + ((IPEndPoint)sending_socket.LocalEndPoint).Port);
                }
                catch (Exception send_exception)
                {
                    exception_thrown = true;
                    Console.WriteLine(" Exception {0}", send_exception.Message);
                }
                if (exception_thrown == false)
                {
                    Console.WriteLine("Message has been sent to the broadcast address");
                }
                else
                {
                    exception_thrown = false;
                    Console.WriteLine("The exception indicates the message was not sent.");
                }*/
                
                //string received_data;
                //byte[] receive_byte_array;
                //IPEndPoint groupEP = new IPEndPoint(((IPEndPoint)sender.Client.LocalEndPoint).Address/*IPAddress.Any*/, ((IPEndPoint)sender.Client.LocalEndPoint).Port);
                /*
                int sentport = ((IPEndPoint)sender.Client.LocalEndPoint).Port;
                sender.Close();*/

                //IPEndPoint groupEP = new IPEndPoint(((IPEndPoint)sending_socket.LocalEndPoint).Address, ((IPEndPoint)udpClient.Client.LocalEndPoint).Port);
                //UdpClient listener = new UdpClient(sentport);

                // sending_socket.Receive();
                
                //Console.WriteLine("Waiting for broadcast");
                //receive_byte_array = listener.Receive(ref groupEP);
                //Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
                //received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                //Console.WriteLine("data follows \n{0}\n\n", received_data);

                //listener.Connect(groupEP);

                Console.WriteLine("Enter text to send, blank line to quit");
                text_to_send = Console.ReadLine();
                senddata = Encoding.ASCII.GetBytes(text_to_send);
                listener.Send(senddata, senddata.Length);

                Console.WriteLine("Waiting for broadcast");
                receive_byte_array = listener.Receive(ref groupEP);
                Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
                received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                Console.WriteLine("data follows \n{0}\n\n", received_data);

            }
        } // end of while (!done)
    } // end of main()
} // end of class Program