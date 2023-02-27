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
namespace FormClient
{
    public partial class GameBoardForm : Form
    {
        ChessBoard chessBoard = new ChessBoard();
        Chess.Point selectedPiece = new Chess.Point();

        //Nếu thực hiện nước đi thì là -1 , còn nếu chỉ ấn vào để hiện nước đi thì là 0 hoặc 1 tuỳ vào quân cờ
        int selectedPlayer = -1;

        #region Local play

        public bool playOnlines = false;

        #endregion

        public GameBoardForm()
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
                    button.FlatStyle = FlatStyle.Popup;
                    button.FlatAppearance.BorderSize = 0;

                    boardLayoutPanel.Controls.Add(button);
                    #endregion

                    //Mỗi khi tạo một button thì load lại bàn cờ
                    button.Click += Click_Board;

                }
            }

            DrawPieces(chessBoard);
        }

        private void Click_Board(object s, EventArgs e)
        {
            #region LOAD BÀN CỜ MỖI KHI CLICK BUTTON

            DrawPieces(chessBoard);
            if (!(s is Button)) return;

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
                    selectedPlayer = -1;
                    DrawPieces(chessBoard);
                    chessBoard.SwapPlayerTurn();
                }
                //selectedPlayer = -1;
                return;
            }
            #endregion

            #region BUTTON LÀ QUÂN CỜ

            ChessPiece chessPiece = (ChessPiece) button.Tag;


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
                selectedPlayer = -1;
                DrawPieces(chessBoard);
                chessBoard.SwapPlayerTurn();
            }

            //Hiện nước đi của quân mình
            else
            {
                selectedPlayer = chessPiece.Player;

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
                    actionButton.BackColor = Color.Transparent;
                    actionButton.FlatStyle = FlatStyle.Popup;
                }
                if (chessBoard.KingInCheck(chessPiece.Player)
                    && chessBoard.PieceActions(a.Column - 1, a.Row - 1).Count() == 0)
                    MessageBox.Show("Vua đang bị chiếu");
            }
            #endregion
        }

        private void DrawPieces(ChessBoard board)
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
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_Knight;
                                    break;
                                case ("Bishop"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_Bishop;
                                    break;
                                case ("Rook"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_Rook;
                                    break;
                                case ("Queen"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_Queen;
                                    break;
                                case ("Pawn"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_Pawn;
                                    break;
                                case ("King"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.w_King;
                                    break;
                            }
                        }
                        else
                        {
                            switch (chessPiece.ToString().Replace("Chess.", ""))
                            {
                                case ("Knight"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_Knight;
                                    break;
                                case ("Bishop"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_Bishop;
                                    break;
                                case ("Rook"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_Rook;
                                    break;
                                case ("Queen"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_Queen;
                                    break;
                                case ("Pawn"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_Pawn;
                                    break;
                                case ("King"):
                                    button.BackgroundImage = global::Chess.Properties.Resources.b_King;
                                    break;
                            }
                        }

                        if ((x + y) % 2 == 1) button.BackColor = Color.DarkGray;
                        else button.BackColor = Color.White;
                        button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                        button.FlatStyle = FlatStyle.Popup;
                        button.UseVisualStyleBackColor = false;
                    }
                    #endregion

                    #region NẾU BUTTON KHÔNG PHẢI LÀ MỘT CHESSPIECE

                    else
                    {
                        button.BackgroundImage = null;

                        if ((x + y) % 2 == 1) button.BackColor = Color.DarkGray;
                        else button.BackColor = Color.White;

                        button.Text = "";
                        button.Tag = null;
                    }

                    #endregion

                    this.coordinates.SetToolTip(button, String.Format("({0}, {1})", x, y));
                    
                }
            }
        }
    }

}
