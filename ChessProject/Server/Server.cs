using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

using System.Threading;
using System.Net;
using System.Net.Sockets;

using MailKit.Net;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net;
using System.Net.Mail;


namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }


        #region NHẬN, GỬI DỮ LIỆU ĐI



        byte[] recvBuffer = new byte[4];
        byte[] recvBytes;
        public Socket listenSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Socket recvSock;
        public static string conn;

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (tbLocalName.TextLength == 0 || tbPassword.TextLength == 0)
            {
                return;
            }

            conn = ("Data Source=" + tbLocalName.Text + ";Initial Catalog=QLCOVUA;User id=sa;password=" + tbPassword.Text + ";");

            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối tới sql data base");
                return;
            }

            MessageBox.Show("Kết nối cơ sở dữ liệu thành công!");

            Listener listener = new Listener();
            listener.StartListening();

            btnListen.Enabled = false;
        }
        class Listener
        {
            public Socket ListenerSocket; //This is the socket that will listen to any incoming connections
            public short Port = 1234; // on this port we will listen

            public Listener()
            {
                ListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            public void StartListening()
            {
                try
                {
                    MessageBox.Show($"Listening started port:{Port} protocol type: {ProtocolType.Tcp}");
                    ListenerSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
                    ListenerSocket.Listen(10);
                    ListenerSocket.BeginAccept(AcceptCallback, ListenerSocket);
                }
                catch (Exception ex)
                {
                    throw new Exception("listening error" + ex);
                }
            }
            public void AcceptCallback(IAsyncResult ar)
            {
                try
                {
                    Console.WriteLine($"Accept CallBack port:{Port} protocol type: {ProtocolType.Tcp}");
                    Socket acceptedSocket = ListenerSocket.EndAccept(ar);
                    ManageClient.AddClient(acceptedSocket,Clients.Count);

                    ListenerSocket.BeginAccept(AcceptCallback, ListenerSocket);
                }
                catch (Exception ex)
                {
                    throw new Exception("Base Accept error" + ex);
                }
            }
        }
        
        #endregion

        #region ByteManage

        public static byte[] RemoveNumberOfFirstByte(byte[] _bytes, int num)
        {
            for (int i = 0; i < _bytes.Length - num; i++)
                _bytes[i] = _bytes[i + num];
            return _bytes;
        }
        
        public static void Send(byte[] data, Socket s)
        {
            List<byte> fullPackage = new List<byte>();
            fullPackage.AddRange(BitConverter.GetBytes(data.Length));
            fullPackage.AddRange(data);
            s.Send(fullPackage.ToArray());
        }
       
        public static void Send(byte firstByte, Socket s)
        {
            List<byte> fullPackage = new List<byte>();
            fullPackage.AddRange(BitConverter.GetBytes(1));
            fullPackage.Add(firstByte);
            //fullPackage.Add(secondByte);
            s.Send(fullPackage.ToArray());
        }
        
        public static void Send(string sendString, byte firstByte, Socket s)
        {
            List<byte> fullPackage = new List<byte>();
            fullPackage.AddRange(BitConverter.GetBytes(sendString.Length + 1));
            fullPackage.Add(firstByte);
            //fullPackage.Add(secondByte);
            fullPackage.AddRange(Encoding.UTF8.GetBytes(sendString));
            s.Send(fullPackage.ToArray());
        }
        


        #endregion

        #region CÁC HÀM TRUY XUẤT SQL 

        public static string username = "";
        //01
        private static bool checkMail(string inputGmail, string code)
        {
            string sql = "SELECT TENND FROM NGUOIDUNG WHERE EMAIL=@mail ";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@mail", inputGmail);
            SqlDataReader sqlReader = sc.ExecuteReader();

            bool kq = sqlReader.HasRows;
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    username = sqlReader.GetString(0); // biến toàn cục để lưu username để sd khi cần

                    // viết hàm tạo mã và gửi về gmail tại đây

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("", "ChessApp@gmail.com"));
                    message.To.Add(new MailboxAddress("", inputGmail));
                    message.Subject = "Mã xác nhận đổi tài khoản App Chess";
                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Mã xác nhận là : " + code;
                    message.Body = bodyBuilder.ToMessageBody();
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("20520370@gm.uit.edu.vn", "gguit3139");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }

            }
            con.Dispose();
            sc.Dispose();
            sqlReader.Close();

            return kq;
        }
        //03
        private static bool NewPass(string username, string newPass)
        {

            SqlConnection con = new SqlConnection(conn);
            con.Open();

            string sql = "UPDATE NGUOIDUNG SET MATKHAU = @mk WHERE TENND = @ten";
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@ten", username);
            sc.Parameters.AddWithValue("@mk", newPass);
            int row = sc.ExecuteNonQuery();

            con.Dispose();
            sc.Dispose();
            if (row == 0)
                return false;
            return true;


        }
        //04
        private static bool SignIn(string username, string pass)
        {


            string sql = "SELECT TENND FROM NGUOIDUNG WHERE TENND=@ten AND MATKHAU=@mk ";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@ten", username);
            sc.Parameters.AddWithValue("@mk", pass);
            SqlDataReader sqlReader = sc.ExecuteReader();

            bool result = sqlReader.HasRows;
            con.Dispose();
            sc.Dispose();
            sqlReader.Close();

            return result;
        }
        //06
        private static bool SignUp(string[] msg)
        {
            //msg[0]: username, msg[1]:pass, msg[2]:email
            if (checkSignUp(msg[0], msg[2]) == false)
            {

                string sql = "INSERT INTO NGUOIDUNG(TENND,MATKHAU,EMAIL,DIEM) VALUES (@ten,@mk,@mail,0)";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand sc = new SqlCommand(sql, con);
                sc.Parameters.AddWithValue("@ten", msg[0]);
                sc.Parameters.AddWithValue("@mk", msg[1]);
                sc.Parameters.AddWithValue("@mail", msg[2]);
                int row = sc.ExecuteNonQuery();

                con.Dispose();
                sc.Dispose();

                if (row == 0)
                    return false;
                return true;
            }
            return false;
        }
        //07
        private static string[] Rank(string username)
        {


            string sql = "SELECT TOP 3 DIEM, TENND FROM NGUOIDUNG ORDER BY DIEM DESC ";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand sc = new SqlCommand(sql, con);
            SqlDataReader sqlReader = sc.ExecuteReader();

            string[] chuoi = new string[9];
            int i = 0;

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    chuoi[i] = sqlReader.GetString(1);
                    i++;
                    chuoi[i] = sqlReader.GetInt64(0).ToString();
                    i++;
                }

            }
            con.Dispose();
            sc.Dispose();
            sqlReader.Close();

            string sql_user = "SELECT ROW_NUMBER() OVER (ORDER BY DIEM DESC) AS XEPHANG, TENND, DIEM FROM NGUOIDUNG";
            SqlConnection con1 = new SqlConnection(conn);
            con1.Open();
            SqlCommand sc1 = new SqlCommand(sql_user, con1);
            SqlDataReader sqlReader1 = sc1.ExecuteReader();
            if (sqlReader1.HasRows)
            {
                while (sqlReader1.Read())
                {
                    if (string.Equals(sqlReader1.GetString(1), username, StringComparison.OrdinalIgnoreCase))
                    {
                        chuoi[i] = sqlReader1.GetString(1);
                        i++;
                        chuoi[i] = sqlReader1.GetInt64(2).ToString();
                        i++;
                        chuoi[i] = sqlReader1.GetInt64(0).ToString();
                        break;
                    }

                }

            }
            con1.Dispose();
            sc1.Dispose();
            sqlReader1.Close();
            return chuoi;

        }
        //08
        private static string[] getInfo(string username)
        {
            string[] info = new string[4];
            info[0] = getBattleCount(username).ToString(); //số trận
            info[1] = getCurrRank(username).ToString(); // hạng hiện tại
            info[2] = getBattleWinCount(username).ToString(); //số trận thắng
            info[3] = getWinRate(username).ToString() + "%"; //tỉ lệ thắng

            return info;

            //code chạy thử người dùng bất kỳ
            //string[] thongtin = getInfo("andinh");
            //MessageBox.Show(thongtin[0] + " " + thongtin[1] + " " + thongtin[2] + " " + thongtin[3]);
        }
        //10
        private static bool changePass(string username, string oldPass, string newPass)
        {
            if (SignIn(username, oldPass) == true)
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();

                string sql = "UPDATE NGUOIDUNG SET MATKHAU = @mk WHERE TENND = @ten";
                SqlCommand sc = new SqlCommand(sql, con);
                sc.Parameters.AddWithValue("@ten", username);
                sc.Parameters.AddWithValue("@mk", newPass);
                int row = sc.ExecuteNonQuery();

                con.Dispose();
                sc.Dispose();
                if (row == 0)
                    return false;
                return true;
            }
            return false;
        }
        //11
        private static bool MatchUpdate(string username1, string username2, int ratio)
        {
            //ratio 0:username1 thua
            //ratio 1:username1 hòa
            //ratio 2:username1 thắng
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            string sql;
            if (ratio == 0) //người thua là user1
            {
                if (getPoint(username1) < 2 && getPoint(username1) != -1) // điểm người user1 < 2 thì cập nhật điểm user1 = 0
                {
                    sql = "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user1,0) \n" +
                          "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user2,2) \n" +
                          "UPDATE NGUOIDUNG SET DIEM = 0 WHERE TENND = @user1 \n" +
                          "UPDATE NGUOIDUNG SET DIEM = DIEM + 5 WHERE TENND = @user2";
                }
                else // người thua user1 có điểm lớn hơn 2 thì điểm = điểm - 2
                {
                    sql = "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user1,0) \n" +
                          "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user2,2) \n" +
                          "UPDATE NGUOIDUNG SET DIEM = DIEM - 2 WHERE TENND = @user1 \n" +
                          "UPDATE NGUOIDUNG SET DIEM = DIEM + 5 WHERE TENND = @user2";
                }
            }
            else if (ratio == 1)
            {
                sql = "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user1,1) \n" +
                      "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user2,1) \n" +
                      "UPDATE NGUOIDUNG SET DIEM = DIEM + 1 WHERE TENND = @user1 \n" +
                      "UPDATE NGUOIDUNG SET DIEM = DIEM + 1 WHERE TENND = @user2";
            }
            else //ratio == 2
            {
                if (getPoint(username2) < 2 && getPoint(username2) != -1) // người thua user2 có điểm nhỏ hơn 2 thì cập nhật điểm = 0
                {
                    sql = "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user1,2) \n" +
                          "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user2,0) \n" +
                          "UPDATE NGUOIDUNG SET DIEM = DIEM + 5 WHERE TENND = @user1 \n" +
                          "UPDATE NGUOIDUNG SET DIEM = 0 WHERE TENND = @user2";
                }
                else // người thua user2 có điểm lớn hơn 2 thì cập nhật điểm = điểm - 2
                {
                    sql = "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user1,2) \n" +
                          "INSERT INTO BANCHOI(TENND,KQUA) VALUES (@user2,0) \n" +
                          "UPDATE NGUOIDUNG SET DIEM = DIEM + 5 WHERE TENND = @user1 \n" +
                          "UPDATE NGUOIDUNG SET DIEM = DIEM - 2 WHERE TENND = @user2";
                }
            }
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@user1", username1);
            sc.Parameters.AddWithValue("@user2", username2);
            int row = sc.ExecuteNonQuery();

            con.Dispose();
            sc.Dispose();
            if (row == 4)
                return true;
            return false;
        }
        #endregion

        #region CÁC HÀM PHỤ

        private static readonly Random _random = new Random();
        private static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        private static bool checkSignUp(string username, string inputGmail)
        {


            string sql = "SELECT TENND FROM NGUOIDUNG WHERE TENND =@ten OR EMAIL=@mail ";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@ten", username);
            sc.Parameters.AddWithValue("@mail", inputGmail);
            SqlDataReader sqlReader = sc.ExecuteReader();

            bool kq = sqlReader.HasRows;
            con.Dispose();
            sc.Dispose();
            sqlReader.Close();

            return kq;
        }

        private static int getBattleCount(string username)
        {

            SqlConnection con = new SqlConnection(conn);
            con.Open();

            string sql = "SELECT COUNT(MABC) FROM BANCHOI WHERE TENND = @ten";
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@ten", username);
            SqlDataReader sqlReader = sc.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    return sqlReader.GetInt32(0);
                }

            }
            con.Dispose();
            sc.Dispose();
            sqlReader.Close();
            return 0;
        }

        private static int getBattleWinCount(string username)
        {

            SqlConnection con = new SqlConnection(conn);
            con.Open();

            string sql = "SELECT COUNT(MABC) FROM BANCHOI WHERE TENND = @ten AND KQUA=2";
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@ten", username);
            SqlDataReader sqlReader = sc.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    return sqlReader.GetInt32(0);
                }

            }
            con.Dispose();
            sc.Dispose();
            sqlReader.Close();
            return 0;
        }

        private static int getBattleDrawCount(string username)
        {

            SqlConnection con = new SqlConnection(conn);
            con.Open();

            string sql = "SELECT COUNT(MABC) FROM BANCHOI WHERE TENND = @ten AND KQUA=1";
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@ten", username);
            SqlDataReader sqlReader = sc.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    return sqlReader.GetInt32(0);
                }

            }
            con.Dispose();
            sc.Dispose();
            sqlReader.Close();
            return 0;
        }

        private static double getWinRate(string username)
        {
            int win = getBattleWinCount(username);
            int draw = getBattleDrawCount(username);
            int battle = getBattleCount(username);
            double rate;
            if (battle == 0)
                rate = 0.0;
            else
                rate = (win + draw * 0.5) * 100.0 / battle;
            rate = Math.Round(rate, 1);
            return rate;
        }

        private static int getCurrRank(string username)
        {


            string sql_user = "SELECT ROW_NUMBER() OVER (ORDER BY DIEM DESC) AS XEPHANG, TENND FROM NGUOIDUNG";
            SqlConnection con1 = new SqlConnection(conn);
            con1.Open();
            SqlCommand sc1 = new SqlCommand(sql_user, con1);
            //sc1.Parameters.AddWithValue("@ten", username);
            SqlDataReader sqlReader1 = sc1.ExecuteReader();

            int rank = 0;

            if (sqlReader1.HasRows)
            {
                while (sqlReader1.Read())
                {
                    if (string.Equals(sqlReader1.GetString(1), username, StringComparison.OrdinalIgnoreCase))
                    {
                        rank = (int)sqlReader1.GetInt64(0);
                    }

                }

            }
            con1.Dispose();
            sc1.Dispose();
            sqlReader1.Close();
            return rank;
        }

        private static int getPoint(string username)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            string sql = "SELECT DIEM FROM NGUOIDUNG WHERE TENND = @ten";
            SqlCommand sc = new SqlCommand(sql, con);
            sc.Parameters.AddWithValue("@ten", username);
            SqlDataReader sqlReader = sc.ExecuteReader();
            int point = -1;
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    point = (int)sqlReader.GetInt64(0);
                }
            }
            con.Dispose();
            sc.Dispose();
            sqlReader.Close();
            return point;
        }
        #endregion


        public static List<Client> Clients = new List<Client>();

        #region Socket
        public class Client
        {
            public Socket clientSock { get; set; }
            public ReceivePacket Receive { get; set; }
            public Socket opponentSock { get; set; }
            public string Username { get; set; }
            public string opponentUsername { get; set; }
            public int id { get; set; }

            public int opponentid { get; set; }

            public bool isWaiting = false;

            public Client(Socket _socket, int _id)
            {
                Receive = new ReceivePacket(_socket, _id);
                Receive.StartReceiving();
                clientSock = _socket;
                id = _id;
            }
            public void setClient(string _username)
            {
                Username = _username;
            }
        }
        public class ReceivePacket
        {
            private byte[] _buffer;
            private Socket _receiveSocket;
            public int _clientId;
            public ReceivePacket(Socket receiveSocket, int id)
            {
                _receiveSocket = receiveSocket;
                _clientId = id;
            }
            public void StartReceiving()
            {
                try
                {
                    _buffer = new byte[4];
                    _receiveSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            private void ReceiveCallback(IAsyncResult AR)
            {
                try
                {
                    
                    if (_receiveSocket.EndReceive(AR) > 1)
                    {
                        _buffer = new byte[BitConverter.ToInt32(_buffer, 0)];
                        _receiveSocket.Receive(_buffer, _buffer.Length, SocketFlags.None);

                        //recvBytes = new byte[BitConverter.ToInt32(recvBuffer, 0)];
                        //Clients[Clients.Count - 1].clientSock.Receive(recvBytes, 0, recvBytes.Length, SocketFlags.None);

                        string stringData = "";
                        string[] stringArr;

                        if (_buffer.Length < 2)
                        {
                            MessageBox.Show("Something went Wrong!\t" +
                                $"Not receiving enough bytes");
                            return;
                        }
                        switch (_buffer[1])
                        {
                            case 1://ForgotPass - Gửi mail xác thực
                                {
                                    string email = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2).Trim();
                                    string randomCode = RandomString(5, true);
                                    if (checkMail(email, randomCode))
                                    {
                                        stringData = username + " " + randomCode;
                                        Send(stringData, 1, _receiveSocket);
                                    }
                                    else
                                    {
                                        Send(0, _receiveSocket);
                                    }
                                    break;
                                }
                            case 3://ForgotPass - Đổi mật khẩu
                                {
                                    stringData = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2).Trim();
                                    stringArr = stringData.Split(' ');
                                    if (NewPass(stringArr[0], stringArr[1]))
                                    {
                                        Send(1, _receiveSocket);
                                    }
                                    else
                                    {
                                        Send(0, _receiveSocket);
                                    }
                                    break;
                                }
                            case 4://Đăng nhập 
                                {
                                    stringData = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2);
                                    stringArr = stringData.Split(' ');
                                    if (SignIn(stringArr[0], stringArr[1]))
                                    {
                                        Send(1, _receiveSocket);
                                    }
                                    else
                                    {
                                        Send(0, _receiveSocket);
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    stringData = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2).Trim();
                                    stringArr = stringData.Split(' ');
                                    if (SignUp(stringArr))
                                    {
                                        Send(1, _receiveSocket);
                                    }
                                    else
                                    {
                                        Send(0, _receiveSocket);
                                    }
                                    break;
                                }
                            case 7:
                                {
                                    stringData = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2).Trim();
                                    string[] RankList = Rank(stringData);
                                    stringData = RankList[0] + ' ' + RankList[1] + ' '
                                                + RankList[2] + ' ' + RankList[3] + ' '
                                                + RankList[4] + ' ' + RankList[5] + ' '
                                                + RankList[6] + ' ' + RankList[7] + ' ' + RankList[8];
                                    Send(stringData, 1, _receiveSocket);
                                    break;
                                }
                            case 8:
                                {
                                    stringData = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2).Trim();
                                    stringArr = getInfo(stringData);
                                    stringData = stringArr[0] + " " + stringArr[1] + " " + stringArr[2] + " " + stringArr[3];
                                    Send(stringData, 1, _receiveSocket);
                                    break;
                                }
                            case 9://09 Tạo phòng hoặc ghép cặp//19: gửi chuỗi byte nước đi, //29 gửi string chat
                                switch (_buffer[0])
                                {
                                    case 0://09 và username
                                        stringData = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2);//username
                                        _buffer = new byte[2];
                                        Clients[Clients.Count - 1].Username = stringData;
                                        if (Clients.Count % 2 == 0)
                                        {
                                            foreach (Client client in Clients)
                                            {
                                                if (client.isWaiting)
                                                {
                                                    client.isWaiting = false;

                                                    Clients[Clients.Count - 1].opponentSock = client.clientSock;
                                                    Clients[Clients.Count - 1].opponentUsername = client.Username;

                                                    client.opponentSock = Clients[Clients.Count - 1].clientSock;
                                                    client.opponentUsername = Clients[Clients.Count - 1].Username;


                                                    _buffer[0] = 1;
                                                    _buffer[1] = 0;
                                                    Send(_buffer, _receiveSocket);//Gửi về player sau

                                                    _buffer[1] = 1;
                                                    Send(_buffer, Clients[Clients.Count - 1].opponentSock);//Gửi về player trước, quân trắng

                                                    
                                                   
                                                    //recvBuffer = new byte[4];
                                                    //client.opponentSock.BeginReceive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, recvCallBack, recvSock);

                                                    break;
                                                }
                                            }
                                            Clients[Clients.Count - 1].isWaiting = true;
                                        }
                                        else
                                        {
                                            Clients[Clients.Count - 1].isWaiting = true;
                                        }
                                        break;
                                    case 1:
                                        //19 gửi chuỗi byte nước đi 
                                        //recvBytes = byte[8] với [2]: 1win/0tiếp tục chơi [3]:  [4]->[7]: nước di chuyển []còn lại là string username

                                        stringData = Encoding.UTF8.GetString(_buffer, 8, _buffer.Length - 8);//username
                                        _buffer[0] = 2;
                                        if (_buffer[2] == 1)//Nếu win
                                        {
                                            //Cập nhật điểm sql
                                            MatchUpdate(stringData, Clients[Clients.FindIndex(x => x.Username == stringData)].opponentUsername, 1);

                                            //Gửi thông tin về báo rằng ván đấu kết thúc
                                        }

                                        //Chuyển tiếp thông tin qua người chơi khác
                                        Send(_buffer, Clients[Clients.FindIndex(x => x.Username == stringData)].opponentSock);
                                        break;

                                    case 2://29 gửi string chat
                                        stringData = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2).Trim();
                                        Send(stringData, 3, Clients[Clients.Count - 1].opponentSock);
                                        break;

                                }
                                break;
                            case 0:
                                {
                                    stringData = Encoding.UTF8.GetString(_buffer, 2, _buffer.Length - 2).Trim();
                                    stringArr = stringData.Split(' ');
                                    if (changePass(stringArr[0], stringArr[1], stringArr[2]))
                                        Send(1, _receiveSocket);
                                    else
                                        Send(0, _receiveSocket);
                                    break;
                                }
                        }

                        StartReceiving();
                    }
                    else
                    {
                        Disconnect();
                    }
                }
                catch (Exception ex)
                {
                    if (!_receiveSocket.Connected)
                    {
                        Disconnect();
                    }
                    else
                    {
                        MessageBox.Show(ex.ToString());
                        //StartReceiving();
                    }
                }
            }
            private void Disconnect()
            {
                _receiveSocket.Disconnect(true);
                ManageClient.RemoveClient(_clientId);
            }
        }
        
        public static class ManageClient
        {
            public static void AddClient(Socket _socket, int _id)
            {
                Clients.Add(new Client(_socket, Clients.Count));
            }

            public static void RemoveClient(int _id)
            {
                int findIndex = Clients.FindIndex(x => x.id == _id);
                Clients.RemoveAt(findIndex);
            }
        }
        #endregion
    }
}