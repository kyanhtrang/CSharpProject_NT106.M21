using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Chess;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FormClient
{
    public partial class ChessPlay : Form
    {
        static public Chess.ChessBoard chessBoard = new Chess.ChessBoard();
        Chess.Point selectedPiece = new Chess.Point();
        //Nếu chưa hiện nước có thể đi là -1, còn nếu thực hiện thay đổi bàn cờ thì là 0 hoặc 1 tuỳ vào quân cờ
        static int selectedPlayer = -1;

        #region Local play

        bool localPlay = dashboard.localPlay;
        int localPlayer = -1;
        static Socket clientSocket { get; set; }
        byte[] sendBuffer = new byte[8];
        byte[] recvBuffer = new byte[8];

        //List buffer {4 byte đầu là độ dài chuỗi byte, 8 byte sau là dữ liệu}
        //buffer = {
        //[0] clientSide (-1,0,1) ,
        //[1] Win (0,1),
        //[2] (dự phòng)
        //[3] PieceValue (Not used yet)
        //[4] fromX,
        //[5] fromY,
        //[6] toX,
        //[7] toY
        //}


        #endregion

        public ChessPlay()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            for (int x = 1; x < boardLayoutPanel.ColumnCount; x++)
            {
                for (int y = 1; y < boardLayoutPanel.RowCount; y++)
                {
                    #region TẠO BÀN CỜ VỚI MỖI Ô TRONG PANEL LÀ MỘT BUTTON

                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);
                    //button.FlatStyle = FlatStyle.Popup;
                    button.FlatAppearance.BorderSize = 0;

                    boardLayoutPanel.Controls.Add(button);
                    #endregion

                    //Mỗi khi tạo một button thì load lại bàn cờ
                    button.Click += Click_Board;
                }
            }

            if (localPlay == true)
            {
                TryToConnect();
            }

            DrawPieces(chessBoard);
        }
        private void Click_Board(object s, EventArgs e)
        {
            #region LOAD BÀN CỜ MỖI KHI CLICK BUTTON

            DrawPieces(chessBoard);
            if (!(s is Button)) return;

            if (localPlay)
            {
                if (localPlayer == -1)
                {
                    MessageBox.Show("Wating for Server to reply");
                    return;
                }
                else if (localPlayer != chessBoard.playerTurn)
                {
                    MessageBox.Show("Chưa tới lượt bạn!");
                    return;
                }
            }
            Button button = (Button)s;
            button.BackColor = System.Drawing.Color.Transparent;
            button.FlatStyle = FlatStyle.Standard;
            button.UseVisualStyleBackColor = true;
            TableLayoutPanelCellPosition a = boardLayoutPanel.GetPositionFromControl((Control)s);

            #endregion

            #region BUTTON KHÔNG PHẢI QUÂN CỜ

            if (!(button.Tag is ChessPiece))
            {
                //nếu button là Nước nằm trong (AvailableMoves) mà quân cờ có thể đi
                if (selectedPlayer > -1)
                {
                    //Trường hợp có thể di chuyển nhưng không di chuyển hợp lệ thì reset lại
                    if (!chessBoard.ActionPiece(selectedPiece.x, selectedPiece.y, a.Column - 1, a.Row - 1))
                    {
                        MessageBox.Show("Đi sai luật chơi");
                        selectedPlayer = -1;
                        return;
                    }
                    if (localPlay)
                    {
                        sendBuffer[4] = (byte)selectedPiece.x;
                        sendBuffer[5] = (byte)selectedPiece.y;
                        sendBuffer[6] = (byte)(a.Column - 1);
                        sendBuffer[7] = (byte)(a.Row -1);
                        Send(sendBuffer);
                        StartReceiving(clientSocket);
                    }

                    selectedPlayer = -1;
                    DrawPieces(chessBoard);
                    chessBoard.SwapPlayerTurn();
                }
                //selectedPlayer = -1;
                return;
            }
            #endregion

            #region BUTTON LÀ QUÂN CỜ

            ChessPiece chessPiece = (ChessPiece)button.Tag;


            //Thực hiện ăn quân cờ (Đối với quân cờ của đối phương)
            if (selectedPlayer > -1 && selectedPlayer != chessPiece.Player)
            {
                //Trường hợp có thể ăn quân cờ nhưng không hợp lệ thì reset lại
                if (!chessBoard.ActionPiece(selectedPiece.x, selectedPiece.y, a.Column - 1, a.Row - 1))
                {
                    MessageBox.Show("Đi sai luật chơi");
                    selectedPlayer = -1;
                    return;
                }
                if (localPlay)
                {
                    sendBuffer[4] = (byte)selectedPiece.x;
                    sendBuffer[5] = (byte)selectedPiece.y;
                    sendBuffer[6] = (byte)(a.Column - 1);
                    sendBuffer[7] = (byte)(a.Row - 1);
                    Send(sendBuffer);
                    StartReceiving(clientSocket);
                }
                selectedPlayer = -1;
                DrawPieces(chessBoard);
                chessBoard.SwapPlayerTurn();
            }

            //Hiện nước đi của quân mình
            else
            {
                selectedPlayer = chessPiece.Player;
                //Check lượt di chuyển quân khi chơi single play
                if (chessBoard.playerTurn != selectedPlayer)
                {
                    MessageBox.Show("Nhầm lượt đi!");
                    selectedPlayer = -1;
                    return;
                }
                selectedPiece.x = a.Column - 1;
                selectedPiece.y = a.Row - 1;
                foreach (Chess.Point point in chessBoard.PieceActions(a.Column - 1, a.Row - 1))
                {
                    Button actionButton = (Button)boardLayoutPanel.GetControlFromPosition(point.x + 1, point.y + 1);
                    if (actionButton.BackgroundImage == null)
                    {
                        actionButton.BackgroundImage = global::Chess.Properties.Resources.dot;
                        actionButton.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else actionButton.BackColor = Color.LightSkyBlue;
                }
                if (chessBoard.KingInCheck(chessPiece.Player) && chessBoard.PieceActions(a.Column - 1, a.Row - 1).Count() == 0)
                    MessageBox.Show("Vua đang bị chiếu");
            }
            #endregion
        }
        private void DrawPieces(Chess.ChessBoard board)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Button button = (Button)boardLayoutPanel.GetControlFromPosition(x + 1, y + 1);


                    #region NẾU BUTTON LÀ MỘT CHESSPIECE THÌ GẮN TAG VÀO BUTTON

                    if (board[x, y] != null)
                    {
                        ChessPiece chessPiece = board[x, y];

                        button.Tag = chessPiece;
                        button.Text = "";

                        if (chessPiece.Player == 1)
                        {
                            switch (chessPiece.ToString().Replace("Chess.", ""))
                            {
                                case ("Knight"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_knight;
                                    break;
                                case ("Bishop"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_bishop;
                                    break;
                                case ("Rook"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_rook;
                                    break;
                                case ("Queen"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_queen;
                                    break;
                                case ("Pawn"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_pawn;
                                    break;
                                case ("King"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_king;
                                    break;
                            }
                        }
                        else
                        {
                            switch (chessPiece.ToString().Replace("Chess.", ""))
                            {
                                case ("Knight"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_knight;
                                    break;
                                case ("Bishop"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_bishop;
                                    break;
                                case ("Rook"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_rook;
                                    break;
                                case ("Queen"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_queen;
                                    break;
                                case ("Pawn"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_pawn;
                                    break;
                                case ("King"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_king;
                                    break;
                            }
                        }

                        button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        button.FlatStyle = FlatStyle.Popup;
                        button.UseVisualStyleBackColor = false;
                    }
                    #endregion

                    #region NẾU BUTTON KHÔNG PHẢI LÀ MỘT CHESSPIECE

                    else
                    {
                        button.BackgroundImage = null;
                        button.FlatStyle = FlatStyle.Popup;
                        button.Text = "";
                        button.Tag = null;
                    }

                    #endregion
                    if ((x + y) % 2 == 1) button.BackColor = Color.RosyBrown;
                    else button.BackColor = Color.White;
                    this.coordinates.SetToolTip(button, String.Format("({0}, {1})", x, y));
                }
            }

            //Socket Things
        }
        public void TryToConnect()
        {
            Socket connectingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            while (!connectingSocket.Connected)
            {
                Thread.Sleep(1000);

                try
                {
                    connectingSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
                }
                catch
                {
                    if (MessageBox.Show("Kết nối tới Server thất bại! Bạn có muốn thử lại?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        break;
                    }
                }
            }
            StartReceiving(connectingSocket);
        }
        public void Send(byte[] data)
        {
            try
            {
                if (localPlayer == 1)
                {
                    data[0] = 1;
                }
                else if (localPlayer == 0)
                {
                    data[0] = 0;
                }
                else
                {
                    data[0] = 2;
                    MessageBox.Show("Error 01, localPlayer = -1");
                }

                var fullPacket = new List<byte>();
                fullPacket.AddRange(BitConverter.GetBytes(data.Length));
                fullPacket.AddRange(data);
                clientSocket.Send(fullPacket.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public void StartReceiving(Socket _sock)
        {

            clientSocket = _sock;
            try
            {
                clientSocket.BeginReceive(recvBuffer, 0, 4, SocketFlags.None, ReceiveCallback, null);
            }
            catch { }
        }
        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                if (clientSocket.EndReceive(AR) > 1)
                {
                    recvBuffer = new byte[8];

                    clientSocket.Receive(recvBuffer, recvBuffer.Length, SocketFlags.None);

                    

                    if (localPlayer == -1)
                    {
                        localPlayer = recvBuffer[0];
                        if (localPlayer == 1)
                        {
                            MessageBox.Show("Bạn đi trước");
                        }
                        else if (localPlayer == 0)
                        {
                            MessageBox.Show("Đợi nước đi của đối thủ");
                            StartReceiving(clientSocket);
                        }
                    }
                    else if (recvBuffer[2] != 0)
                    {
                        if (recvBuffer[2] == 1)
                        {
                            if (MessageBox.Show("Bạn có muốn chấp nhận hoà không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                MessageBox.Show("Ván đấu kết thúc hoà!");

                                byte[] bytes = new byte[8];
                                bytes[2] = 3;
                                Send(bytes);

                                Invoke(new Action(() =>
                                {
                                    this.Close();
                                }));
                            }
                            else//Không đồng ý
                            {
                                byte[] bytes = new byte[8];
                                bytes[2] = 2;
                                Send(bytes);
                                StartReceiving(clientSocket);
                            }
                        }
                        else if (recvBuffer[2] == 2)
                        {
                            MessageBox.Show("Đối thủ không chấp nhận, ván đấu tiếp tục");
                        }
                        else //=3
                        {
                            MessageBox.Show("Đối thủ chấp nhận hoà, ván đấu kết thúc");
                            Invoke(new Action(() =>
                            {
                                this.Close();
                            }));
                        }
                    }
                    
                    else if (recvBuffer[3]==1)
                    {
                        MessageBox.Show("Đối thủ chịu thua!");
                        Invoke(new Action(() =>
                        {
                            this.Close();
                        }));

                    }
                    else
                    {
                        chessBoard.SwapPlayerTurn();
                        Invoke(new Action(() =>
                        {
                            chessBoard.PieceActions(recvBuffer[4], recvBuffer[5]);
                            chessBoard.ActionPiece(recvBuffer[4], recvBuffer[5], recvBuffer[6], recvBuffer[7]);
                            DrawPieces(chessBoard);
                        }
                        ));
                    }
                }
                else
                {
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                if (!clientSocket.Connected)
                {
                    Disconnect();
                    MessageBox.Show(ex.ToString());
                }
                else
                {
                    StartReceiving(clientSocket);
                }
            }
        }
        private void Disconnect()
        {
            try
            {
                clientSocket.Disconnect(true);
            }
            catch(SocketException ex)
            {

            }
        }

        private void btnSurrender_Click(object sender, EventArgs e)
        {
            if (localPlayer != chessBoard.playerTurn)
            {
                MessageBox.Show("Đợi đối phương di chuyển trước khi đầu hàng!");
                return;
            }
            byte[] bytes = new byte[8];
            bytes[3] = 1;
            Send(bytes);

            Invoke(new Action(() =>
            {
                this.Close();
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (localPlayer != chessBoard.playerTurn)
            {
                MessageBox.Show("Đợi đối phương di chuyển trước khi muốn cầu hoà!");
                return;
            }

            byte[] bytes = new byte[8];
            bytes[2] = 1;
            Send(bytes);
            MessageBox.Show("Chờ đối thủ trả lời...");

            StartReceiving(clientSocket);

            while (recvBuffer[2] != 0)
            {
                Thread.Sleep(1000);
            }
        }
    }
}


