using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class PawnPromotion : Form
    {
        public ChessPiece PromotedPiece;
        
        public PawnPromotion(int playerTurn)
        {
            InitializeComponent();
            //Truyền vào playerTurn = MovingPiece.Player (Nếu 0 là bên trắng, 1 là bên đen) 
            if (playerTurn == 0) 
            {
                btn_whiteBishop.Visible = false;
                btn_whiteKnight.Visible = false;
                btn_whiteQueen.Visible = false;
                btn_whiteRook.Visible = false;
            }
            else
            {
                btn_blackBishop.Visible = false;
                btn_blackKnight.Visible = false;
                btn_blackQueen.Visible = false;
                btn_blackRook.Visible = false;
            }
            //Khi người chơi click chọn quân cờ thì sẽ chuyển qua hàm button_click
            btn_blackQueen.Click += Button_click;
            btn_blackRook.Click += Button_click;
            btn_blackBishop.Click += Button_click;
            btn_blackKnight.Click += Button_click;
            btn_whiteQueen.Click += Button_click;
            btn_whiteRook.Click += Button_click;
            btn_whiteBishop.Click += Button_click;
            btn_whiteKnight.Click += Button_click;
        }
        private void Button_click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btn_blackQueen":
                    PromotedPiece = new Queen();
                    Close();
                    break;
                case "btn_blackRook":
                    PromotedPiece = new Rook();
                    Close();
                    break;
                case "btn_blackBishop":
                    PromotedPiece = new Bishop();
                    Close();
                    break;
                case "btn_blackKnight":
                    PromotedPiece = new Knight();
                    Close();
                    break;
                case "btn_whiteQueen":
                    PromotedPiece = new Queen();
                    Close();
                    break;
                case "btn_whiteRook":
                    PromotedPiece = new Rook();
                    Close();
                    break;
                case "btn_whiteBishop":
                    PromotedPiece = new Bishop();
                    Close();
                    break;
                case "btn_whiteKnight":
                    PromotedPiece = new Knight();
                    Close();
                    break;
            }
        }
    }
}
