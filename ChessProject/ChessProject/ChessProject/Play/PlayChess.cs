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

namespace ChessProject
{
    public partial class PlayChess : Form
    {
        public PlayChess()
        {
            InitializeComponent();
        }
        static public Chess.ChessBoard chessBoard = new Chess.ChessBoard();
        Chess.Point selectedPiece = new Chess.Point();
        //Nếu chưa hiện nước có thể đi là -1, còn nếu thực hiện thay đổi bàn cờ thì là 0 hoặc 1 tuỳ vào quân cờ
        static int selectedPlayer = -1;

        #region Local play

        bool localPlay = PlayGame.localPlay;
        int localPlayer = -1;
        static Socket clientSocket = ServerConnect.clientSocket;
        static string username = ServerConnect.username;

        byte[] sendBuffer;
        byte[] recvBuffer;
        byte[] recvBytes;
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
                ServerConnect.Send(ServerConnect.username, 0, 9);
                StartReceiving(clientSocket);
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
                        sendBuffer = new byte[8];
                        sendBuffer[0] = 1;
                        sendBuffer[1] = 9;
                        //sendBuffer[2] = (byte)
                        sendBuffer[4] = (byte)selectedPiece.x;
                        sendBuffer[5] = (byte)selectedPiece.y;
                        sendBuffer[6] = (byte)(a.Column - 1);
                        sendBuffer[7] = (byte)(a.Row - 1);
                        ServerConnect.Send(sendBuffer,ServerConnect.username);
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
                    sendBuffer = new byte[8];
                    sendBuffer[0] = 1;
                    sendBuffer[1] = 9;
                    //sendBuffer[2] = (byte)
                    sendBuffer[4] = (byte)selectedPiece.x;
                    sendBuffer[5] = (byte)selectedPiece.y;
                    sendBuffer[6] = (byte)(a.Column - 1);
                    sendBuffer[7] = (byte)(a.Row - 1);
                    ServerConnect.Send(sendBuffer, ServerConnect.username);
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

            #region: KIỂM TRA CHIẾU HẾT, PHONG CẤP, NHẬP THÀNH

            #endregion

        }

        public void Send(byte[] data)
        {
            try
            {
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
        public void Send(byte[] data, string username)
        {
            try
            {
                var fullPacket = new List<byte>();
                fullPacket.AddRange(BitConverter.GetBytes(data.Length + username.Length));//Gửi byte độ dài chuỗi
                fullPacket.AddRange(data);//data[8 bit với 2 bit để điều hướng]
                fullPacket.AddRange(Encoding.UTF8.GetBytes(username));
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
                recvBuffer = new byte[4];
                clientSocket.BeginReceive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, ReceiveCallback, null);
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
                if (clientSocket.EndReceive(AR) > 1)
                {
                    recvBytes = new byte[BitConverter.ToInt32(recvBuffer, 0)];
                    clientSocket.Receive(recvBytes, 0, recvBytes.Length, SocketFlags.None);

                    if (recvBytes[0] == 1)//Gói tin để client biết mình quân trắng hay đen
                    {
                        localPlayer = recvBytes[1];
                        if (localPlayer == 1)
                        {
                            MessageBox.Show("Bạn là quân trắng, bạn đi trước!");
                        }
                        else if (localPlayer == 0)
                        {
                            MessageBox.Show("Bạn là quân đen, bạn đợi nước đi của đối phương!");
                        }
                    }
                    else if (recvBytes[0] == 2)
                    {
                        chessBoard.SwapPlayerTurn();
                        Invoke(new Action(() =>
                        {
                            chessBoard.PieceActions(recvBytes[4], recvBytes[5]);
                            chessBoard.ActionPiece(recvBytes[4], recvBytes[5], recvBytes[6], recvBytes[7]);
                            DrawPieces(chessBoard);
                        }
                        ));
                    }
                    else if (recvBytes[0] == 3)
                    {
                        string tempText = Encoding.UTF8.GetString(recvBytes, 1, recvBytes.Length - 1).Trim();
                        Invoke(new Action(() =>
                        {
                            lstChatBox.Items.Add(tempText);
                        }));
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
                }
                else
                {
                    //StartReceiving(clientSocket);
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void Disconnect()
        {
            clientSocket.Disconnect(true);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbInput.TextLength == 0)
                {
                    MessageBox.Show("Nội dung không được để trống");
                    return;
                }

                lstChatBox.Items.Add(tbInput.Text);
                var fullPacket = new List<byte>();
                fullPacket.AddRange(BitConverter.GetBytes(username.Length +tbInput.TextLength + 2));//Gửi byte độ dài chuỗi
                fullPacket.Add(2);
                fullPacket.Add(9);
                fullPacket.AddRange(Encoding.UTF8.GetBytes(username+": "+tbInput.Text));
                clientSocket.Send(fullPacket.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
