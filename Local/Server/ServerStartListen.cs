using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class ServerStartListen : Form
    {
        public ServerStartListen()
        {
            InitializeComponent();
        }

        static Listener listener = new Listener();
        private void btnListen_Click(object sender, EventArgs e)
        {

            if (btnListen.Text == "Listen")
            {
                btnListen.Text = "Disconnect";

                StartListen();
            }
            else
            {
                btnListen.Text = "Listen";
                listener.listenSock.Close();
            }
        }
        public static void StartListen()
        {
            listener = new Listener();
            listener.listen();
        }

        public class Listener
        {
            public Socket listenSock;
            public int port = 1234;

            public Listener()
            {
                listenSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

            public void listen()
            {
                listenSock.Bind(new IPEndPoint(IPAddress.Any, port));
                listenSock.Listen(10);
                listenSock.BeginAccept(callback, listenSock);

            }
            private void callback(IAsyncResult ar)
            {
                try
                {
                    Socket acceptedSocket = listenSock.EndAccept(ar);
                    ManageClient.AddClient(acceptedSocket);
                    listenSock.BeginAccept(callback, listenSock);
                }
                catch (ObjectDisposedException ex)
                {
                    MessageBox.Show("Server has closed");
                }
            }
        }
        public class Client
        {
            public Socket clientSock { get; set; }
            public int id { get; set; }
            public byte[] data = new byte[8];
            public bool isWaiting = false;

            public Client(Socket _socket, int _id)
            {
                clientSock = _socket;
                id = _id;
            }
            public void send(byte[] _data)
            {
                var fullPacket = new List<byte>();
                fullPacket.AddRange(BitConverter.GetBytes(_data.Length));
                fullPacket.AddRange(_data);
                clientSock.Send(fullPacket.ToArray());
            }
            public void StartReceiving()
            {
                try
                {
                    data = new byte[12];
                    clientSock.BeginReceive(data, 0, 4, SocketFlags.None, ReceiveCallback, null);
                }
                catch { }
            }
            private void ReceiveCallback(IAsyncResult AR)
            {
                try
                {
                    data = new byte[8];
                    if (clientSock.EndReceive(AR) > 1)
                    {
                        clientSock.Receive(data, data.Length, SocketFlags.None);
                    }
                    else
                    {
                        Disconnect();
                    }
                }
                catch
                {
                    if (!clientSock.Connected)
                    {
                        Disconnect();
                    }
                    else
                    {
                        StartReceiving();
                    }
                }
            }

            private void Disconnect()
            {
                // Close connection
                clientSock.Disconnect(true);

            }
        }
        public static class ManageClient
        {
            static List<Client> Clients = new List<Client>();

            public static void AddClient(Socket _socket)
            {
                Clients.Add(new Client(_socket, Clients.Count));
                //MessageBox.Show($"Thêm socket thành công! id:{Clients[Clients.Count - 1].id}");

                //Có người đang đợi
                if (Clients.Count % 2 == 0)
                {
                    foreach (Client client in Clients)
                    {
                        if (client.isWaiting)
                        {
                            client.isWaiting = false;
                            MatchBetween(client, Clients[Clients.Count - 1]);
                            break;
                        }
                    }
                }
                else
                {
                    Clients[Clients.Count - 1].isWaiting = true;
                }
            }

            public static void RemoveClient(int _id)
            {
                int findIndex = Clients.FindIndex(x => x.id == _id);
                Clients.RemoveAt(findIndex);
                MessageBox.Show($"Remove id {_id} which is Clients[{findIndex}] ");
            }

            public static void MatchBetween(Client firstPlayer, Client secondPlayer)
            {
                //buffer để gửi
                byte[] buffer = new byte[8];

                #region TRƯỚC VÁN ĐẤU

                //Quy định quân đen hay trắng
                buffer[0] = 1;
                firstPlayer.send(buffer);

                buffer[0] = 0;
                secondPlayer.send(buffer);

                #endregion

                #region VÁN ĐẤU

                bool WhiteToPlay = true;
                bool ifWinOrDraw = false;
                while (true)
                {
                    
                    buffer = new byte[8];
                    if (WhiteToPlay)
                    {
                        firstPlayer.StartReceiving();

                        while (firstPlayer.data[4] == firstPlayer.data[6] &&
                            firstPlayer.data[5] == firstPlayer.data[7])
                        {
                            if (firstPlayer.data[3] == 1)//Chịu thua
                            {
                                MessageBox.Show("Trắng thắng! Kết thúc ván đấu");
                                ifWinOrDraw = true;
                                break;
                            }
                            else if (firstPlayer.data[2] == 1)//Cầu hoà
                            {
                                buffer = firstPlayer.data;
                                firstPlayer.data = new byte[8];
                                secondPlayer.send(buffer);
                                secondPlayer.StartReceiving();

                                while (secondPlayer.data[2] == 0)
                                {
                                    Thread.Sleep(1000);
                                }
                                if (secondPlayer.data[2] == 3)//Đồng ý hoà
                                {
                                    buffer = secondPlayer.data;
                                    secondPlayer.data = new byte[8];
                                    firstPlayer.send(buffer);
                                    ifWinOrDraw = true;
                                    break;
                                }
                                else//Không đồng ý hoà
                                {
                                    buffer = secondPlayer.data;
                                    secondPlayer.data = new byte[8];
                                    firstPlayer.send(buffer);

                                    firstPlayer.StartReceiving();
                                }
                                    
                            }
                            Thread.Sleep(1000);
                        }
                        buffer = firstPlayer.data;
                        firstPlayer.data = new byte[8];
                        secondPlayer.send(buffer);
                        
                    }
                    else
                    {
                        secondPlayer.StartReceiving();

                        while (secondPlayer.data[4] == secondPlayer.data[6] &&
                            secondPlayer.data[5] == secondPlayer.data[7])
                        {
                            if (secondPlayer.data[3] == 1)
                            {
                                MessageBox.Show("Đen thắng! Kết thúc ván đấu");
                                ifWinOrDraw = true;
                                break;
                            }
                            else if (secondPlayer.data[2] == 1)//Cầu hoà
                            {
                                buffer = secondPlayer.data;
                                secondPlayer.data = new byte[8];
                                firstPlayer.send(buffer);
                                firstPlayer.StartReceiving();

                                while (firstPlayer.data[2] == 0)
                                {
                                    Thread.Sleep(1000);
                                }
                                if (firstPlayer.data[2] == 3)//Đồng ý hoà
                                {
                                    buffer = firstPlayer.data;
                                    firstPlayer.data = new byte[8];
                                    secondPlayer.send(buffer);
                                    ifWinOrDraw = true;
                                    break;
                                }
                                else//Không đồng ý hoà
                                {
                                    buffer = firstPlayer.data;
                                    firstPlayer.data = new byte[8];
                                    secondPlayer.send(buffer);

                                    secondPlayer.StartReceiving();
                                }

                            }
                            Thread.Sleep(1000);
                        }

                        buffer = secondPlayer.data;
                        secondPlayer.data = new byte[8];
                        firstPlayer.send(buffer);
                        
                    }
                    if (ifWinOrDraw)
                        break;
                    WhiteToPlay = !WhiteToPlay;
                   
                }
                //Ván kết thúc
                #endregion
            }
        }
    }
}
