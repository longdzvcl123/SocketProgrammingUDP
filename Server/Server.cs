using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Server
{
    class Server
    {
        private Socket socketServer;
        private const int bufSize = 8 * 1024;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;
        //private List<EndPoint> ClientSockets;  // EndPoint : IP-Port

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public Server(IPAddress _ip, int port)
        {
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socketServer.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            socketServer.Bind(new IPEndPoint(_ip, port));
            Receive();
        }

        public void Send(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            socketServer.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = socketServer.EndSend(ar);
                //Console.WriteLine("SEND: {0}, {1}", bytes, text);
            }, state);
        }

        private void Receive()
        {
            socketServer.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                try
                {
                    State so = (State)ar.AsyncState;
                    int bytes = socketServer.EndReceiveFrom(ar, ref epFrom);
                    socketServer.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);

                    byte[] req = new byte[bytes];
                    Array.Copy(state.buffer, req, bytes);

                    //xu li data
                    string str = Encoding.UTF8.GetString(req);
                    if (str == "test")
                    {
                        MessageBox.Show("Longdz");
                        //this.Send("test");
                    }
                    

                    Array.Clear(state.buffer, 0, bufSize);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }, state);
        }
    }
}
