using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Client
{
    class Client
    {
        public Socket socketClient;
        private const int bufSize = 8 * 1024;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }
        public Client(IPAddress _ip, int port)
        {
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socketClient.Connect(_ip, port);
            Receive();
        }
        private void Receive()
        {
            socketClient.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                try
                {
                    State so = (State)ar.AsyncState;
                    int bytes = socketClient.EndReceiveFrom(ar, ref epFrom);
                    socketClient.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);

                    byte[] req = new byte[bytes];
                    Array.Copy(state.buffer, req, bytes);

                    //xu li data
                    string str = Encoding.UTF8.GetString(req);
                    if (str == "test")
                        MessageBox.Show("Longdz");

                    Array.Clear(state.buffer, 0, bufSize);

                }
                catch(Exception ex)
                {
                    MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }, state);
        }
        public void Send(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            socketClient.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = socketClient.EndSend(ar);
               
            }, state);
        }
    }
}
