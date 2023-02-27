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

namespace ChessProject
{
    public partial class ServerConnect : Form
    {
        public ServerConnect()
        {
            InitializeComponent();
        }
        #region SOCKET

        public static string username = "";
        public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static byte[] recvBuffer =new byte[4];
        public static byte[] recvBytes;
        public static bool Received = false;
        public bool TryToConnect()
        {
            while (!clientSocket.Connected)
            {
                try
                {
                    clientSocket.Connect(new IPEndPoint(IPAddress.Parse(tbServerIp.Text), 1234));
                }
                catch
                {
                    if (MessageBox.Show("Kết nối tới server thất bại, có muốn thử lại không?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                        return false;
                }
            }
            return true;
        }
        public static void StartReceiving()
        {
            recvBuffer = new byte[4];
            clientSocket.BeginReceive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, RecvCallBack, clientSocket);
        }
        public static void RecvCallBack(IAsyncResult ar)
        {
            if (clientSocket.EndReceive(ar) <= 1)
            {
                return;
            }
            //= new byte[BitConverter.ToInt32(_buffer, 0)]; 
            recvBytes = new byte[BitConverter.ToInt32(recvBuffer, 0)];
            clientSocket.Receive(recvBytes, 0, recvBytes.Length, SocketFlags.None);
            Received = true;
        }
        public static void WaitForData()
        {
            Received = false;
            StartReceiving();
            while (!Received)
            {
                Thread.Sleep(3000);
                if (Received)
                    break;
                if (MessageBox.Show("Đợi thông tin từ Server\r\nẤn 'No' để đóng ứng dụng", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    clientSocket.Disconnect(true);
                    break;
                }
            }
        }
        public static void Send(byte[] data, string sendString)
        {
            List<byte> fullPackage = new List<byte>();
            fullPackage.AddRange(BitConverter.GetBytes(sendString.Length + data.Length));
            fullPackage.AddRange(data);
            fullPackage.AddRange(Encoding.UTF8.GetBytes(sendString));
            ServerConnect.clientSocket.Send(fullPackage.ToArray());
        }
        public static void Send(string sendString, byte firstByte, byte secondByte)
        {
            List<byte> fullPackage = new List<byte>();
            fullPackage.AddRange(BitConverter.GetBytes(sendString.Length+2));
            fullPackage.Add(firstByte);
            fullPackage.Add(secondByte);
            fullPackage.AddRange(Encoding.UTF8.GetBytes(sendString));
            ServerConnect.clientSocket.Send(fullPackage.ToArray());
        }
        public static void Send(string sendString1, string sendString2, byte firstByte, byte secondByte)
        {
            List<byte> fullPackage = new List<byte>();
            string sendString = sendString1 + " " + sendString2;
            fullPackage.AddRange(BitConverter.GetBytes(sendString.Length+2));
            fullPackage.Add(firstByte);
            fullPackage.Add(secondByte);
            fullPackage.AddRange(Encoding.UTF8.GetBytes(sendString));
            ServerConnect.clientSocket.Send(fullPackage.ToArray());
        }
        public static void Send(string sendString1, string sendString2, string sendString3, byte firstByte, byte secondByte)
        {
            List<byte> fullPackage = new List<byte>();
            string sendString = sendString1 + " " + sendString2 +" "+sendString3;
            fullPackage.AddRange(BitConverter.GetBytes(sendString.Length+2));
            fullPackage.Add(firstByte);
            fullPackage.Add(secondByte);
            fullPackage.AddRange(Encoding.UTF8.GetBytes(sendString));
            ServerConnect.clientSocket.Send(fullPackage.ToArray());
        }
        public static void Send(byte[] data, byte firstByte, byte secondByte)
        {
            List<byte> fullPackage = new List<byte>();
            fullPackage.AddRange(BitConverter.GetBytes(data.Length + 2));
            fullPackage.Add(firstByte);
            fullPackage.Add(secondByte);
            fullPackage.AddRange(data);
            ServerConnect.clientSocket.Send(fullPackage.ToArray());
        }
        #endregion

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!TryToConnect())
                return;
            btnConnect.Enabled = false;
            MessageBox.Show("Kết nối tới server thành công");

            Form si = new SignIn();
            this.Hide();
            si.Show();
        }
    }
}
