using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class ChessBoard
    {
        #region Các thuộc tính của class

        public ChessPiece[,] boardArray;
        
        private const int COLUMNS = 8;
        private int ROWS = 8;

        public int castling = 0;
        public int PromotionValue=-1; //0 Knight, 1 Bishop, 2 Rook, 3 Queen
        public int playerTurn = 1;
        public void SwapPlayerTurn()
        {
            if (playerTurn == 1)
                playerTurn = 0;
            else playerTurn = 1;
        }

        public ChessBoard()
        {
            SetupBoard();
        }

        public int GetLength(int l)
        {
            return boardArray.GetLength(l);
        }

        public ChessPiece this[int x, int y]
        {
            get { return boardArray[x, y]; }
            set { boardArray[x, y] = value; }
        }
        #endregion
        private ChessBoard SetupBoard()
        {
            boardArray = new ChessPiece[COLUMNS, ROWS];
            string[] playerPieces = {
                "Rook", "Knight", "Bishop", "Queen",
                "King", "Bishop", "Knight", "Rook",
                "Pawn", "Pawn", "Pawn", "Pawn",
                "Pawn", "Pawn", "Pawn", "Pawn" };

            for (int i = 0; i < COLUMNS; i++)
            {
                // Player 0 pieces
                boardArray[i, 0] =          (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPieces[i]));
                boardArray[i, 1] =          (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPieces[i + COLUMNS]));
                // Player 1 pieces
                boardArray[i, ROWS - 1] =   (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPieces[i]), new object[] { 1 });
                boardArray[i, ROWS - 2] =   (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPieces[i + COLUMNS]), new object[] { 1 });
            }
            return this;
        }

        #region Calculate the actual actions available for a Chess Piece at a set of coordinates.

        /// <param name="x">The number of squares right of the bottom left square</param>
        /// <param name="y">The number of squares above the bottom left square</param>
        /// <param name="ignoreCheck">Do not check for threats to the king</param>
        /// <param name="attackActions">Calculate attacks</param>
        /// <param name="moveActions">Calculate movement</param>
        /// <param name="boardArray">An optional substitute board</param>
        /// <returns>A list of points that can be moved to</returns>
        public IEnumerable<Point> PieceActions(int x, int y, bool ignoreCheck = false, bool attackActions = true, bool moveActions = true, ChessPiece[,] boardArray = null)
        {
            if (boardArray == null)
            {
                boardArray = this.boardArray;
            }

            bool[,] legalActions = new bool[boardArray.GetLength(0), boardArray.GetLength(1)];
            List<Point> availableActions = new List<Point>();
            ChessPiece movingPiece = boardArray[x, y];
            
            if (attackActions)
            {
                foreach (Point[] direction in movingPiece.AvailableAttacks)
                {
                    foreach (Point attackPoint in direction)
                    {
                        Point adjustedPoint = new Point(attackPoint.x + x, attackPoint.y + y);
                        if (ValidatePoint(adjustedPoint))
                        {
                            if (boardArray[adjustedPoint.x, adjustedPoint.y] != null
                                && boardArray[adjustedPoint.x, adjustedPoint.y].Player ==
                                movingPiece.Player) break;
                            if (boardArray[adjustedPoint.x, adjustedPoint.y] != null)
                            {
                                AddMove(availableActions, new Point(x, y), adjustedPoint, ignoreCheck);
                                break;
                            }
                        }
                    }
                }
            }

            if (moveActions)
            {
                foreach (Point[] direction in movingPiece.AvailableMoves)
                {
                    foreach (Point movePoint in direction)
                    {
                        Point adjustedPoint = new Point(movePoint.x + x, movePoint.y + y);
                        if (ValidatePoint(adjustedPoint))
                        {
                            if (boardArray[adjustedPoint.x, adjustedPoint.y] != null) break;
                            AddMove(availableActions, new Point(x, y), adjustedPoint, ignoreCheck);
                        }
                    }
                }
            }

            if (movingPiece is King && ((King)movingPiece).CanCastle)
            {
                int rookX = 0;
                if (boardArray[rookX, y] is Rook && ((Rook)boardArray[rookX, y]).CanCastle)
                {
                    bool missedCondition = false;
                    foreach (int rangeX in Enumerable.Range(rookX + 1, Math.Abs(rookX - x) - 1))
                    {
                        if (boardArray[rangeX, y] != null) missedCondition = true;
                        // TODO: Validate that the king won't move through check
                    }
                    // TODO: Validate that king isn't currently in check
                    missedCondition = missedCondition || KingInCheck(movingPiece.Player);
                    if (!missedCondition) 
                        AddMove(availableActions, new Point(x, y), new Point(x - 2, y), ignoreCheck);
                }
                rookX = COLUMNS - 1;
                if (boardArray[rookX, y] is Rook && ((Rook)boardArray[rookX, y]).CanCastle)
                {
                    bool missedCondition = false;
                    foreach (int rangeX in Enumerable.Range(x + 1, Math.Abs(rookX - x) - 1))
                    {
                        if (boardArray[rangeX, y] != null) missedCondition = true;
                        // TODO: Validate that the king won't move through check
                    }
                    // TODO: Validate that king isn't currently in check
                    missedCondition = missedCondition || KingInCheck(movingPiece.Player);
                    if (!missedCondition) 
                        AddMove(availableActions, new Point(x, y), new Point(x + 2, y), ignoreCheck);
                }
            }

            if (movingPiece is Pawn)
            {
                Pawn pawn = (Pawn)movingPiece;
                int flipDirection = 1;

                if (pawn.Player == 1) flipDirection = -1;
                
                if (pawn.CanEnPassantLeft && x != 0 && boardArray[x - 1, y] != null)
                {
                    Point attackPoint;
                    attackPoint = ChessPiece.GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_LEFT)[0];
                    attackPoint.y *= flipDirection;
                    attackPoint.y += y;
                    attackPoint.x += x;
                    if (ValidatePoint(attackPoint))
                    {
                        AddMove(availableActions, new Point(x, y), attackPoint, ignoreCheck);
                    }
                }
                else pawn.CanEnPassantLeft = false;

                if (pawn.CanEnPassantRight && x != 7 && boardArray[x + 1, y] != null)
                {
                    Point attackPoint;
                    attackPoint = ChessPiece.GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_RIGHT)[0];
                    attackPoint.y *= flipDirection;
                    attackPoint.y += y;
                    attackPoint.x += x;
                    if (ValidatePoint(attackPoint))
                    {
                        AddMove(availableActions, new Point(x, y), attackPoint, ignoreCheck);
                    }
                }
                else pawn.CanEnPassantRight = false;
            }
            
            return availableActions;
        }
        //Kiểm tra xem có phải hàm ActionPiece được gọi từ AddMove không?
        bool callFromAddMoveFunct = false;
        bool kingInCheck = false;
        private void AddMove(List<Point> availableActions, Point fromPoint, Point toPoint, bool ignoreCheck = false)
        {
            //bool kingInCheck = false;

            if (!ignoreCheck)
            {
                callFromAddMoveFunct = true;
                ChessPiece movingPiece = boardArray[fromPoint.x, fromPoint.y];
                ChessPiece[,] boardArrayBackup = (ChessPiece[,])boardArray.Clone();
                ActionPiece(fromPoint, toPoint, true);
                kingInCheck = KingInCheck(movingPiece.Player);
                boardArray = boardArrayBackup;
                callFromAddMoveFunct = false;
            }

            if (ignoreCheck || !kingInCheck) 
                availableActions.Add(toPoint);
        }

        public bool KingInCheck(int player)
        {
            for (int x = 0; x < COLUMNS; x++)
            {
                for (int y = 0; y < ROWS; y++)
                {
                    ChessPiece chessPiece = boardArray[x, y];
                    if (chessPiece != null
                        && chessPiece.Player == player
                        && chessPiece is King)
                    {
                        if (CheckSquareVulnerable(x, y, player))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            throw new Exception("King wasn't found!");
        }

        public IEnumerable<Point> PieceActions(Point position, bool ignoreCheck = false, bool attackActions = true, bool moveActions = true, ChessPiece[,] boardArray = null)
        {
            return PieceActions(position.x, position.y, ignoreCheck, attackActions, moveActions, boardArray);
        }
        #endregion

        #region Move a Piece from one location on the board to another

        /// <param name="fromX">The x coordinate of the piece that is moving.</param>
        /// <param name="fromY">The y coordinate of the piece that is moving.</param>
        /// <param name="toX">The x coordinate of the destination.</param>
        /// <param name="toY">The y coordinate of the destination.</param>
        /// <returns>Returns true on success or false on failure.</returns>
        public bool ActionPiece(int fromX, int fromY, int toX, int toY)
        {
            return ActionPiece(new Point(fromX, fromY), new Point(toX, toY));
        }

        /// <param name="from">The location of the piece that is moving.</param>
        /// <param name="to">The location to move to.</param>
        /// <returns>Returns true on success or false on failure.</returns>
        public bool ActionPiece(Point from, Point to, bool bypassValidaiton = false)
        {
            if (bypassValidaiton || PieceActions(from).Contains(to))
            {
                ChessPiece movingPiece = boardArray[from.x, from.y];
                if (movingPiece is Pawn)
                {
                    Pawn pawn = (Pawn)movingPiece;
                    // If this was a double jump, check enpassant
                    if (Math.Abs(from.y - to.y) == 2)
                    {
                        int adjasentX = to.x - 1;
                        if (adjasentX > -1
                            && boardArray[adjasentX, to.y] != null
                            && boardArray[adjasentX, to.y].Player != movingPiece.Player
                            && boardArray[adjasentX, to.y] is Pawn)
                        {
                            if (!bypassValidaiton) 
                                ((Pawn)boardArray[adjasentX, to.y]).CanEnPassantRight = true;
                        }
                        adjasentX += 2;
                        if (adjasentX < COLUMNS
                            && boardArray[adjasentX, to.y] != null
                            && boardArray[adjasentX, to.y].Player != movingPiece.Player
                            && boardArray[adjasentX, to.y] is Pawn)
                        {
                            if (!bypassValidaiton) 
                                ((Pawn)boardArray[adjasentX, to.y]).CanEnPassantLeft = true;
                        }
                    }
                    // If this was a sideways jump to null, it was enpassant!
                    if (from.x != to.x && boardArray[to.x, to.y] == null)
                    {
                        boardArray[to.x, from.y] = null;
                    }

                    if (!bypassValidaiton) // Pawns can't double jump after they move.
                        pawn.CanDoubleJump = false;
                    //Phong cấp quân chốt
                    if (!callFromAddMoveFunct)
                    {
                        if ((pawn.Player == 0 && to.y == 7) || (pawn.Player == 1 && to.y == 0))
                        {
                            //Nếu bên Receive nhận buffer phong cấp
                            if (PromotionValue != -1)
                            {
                                switch (PromotionValue)
                                {
                                    case 0:
                                        movingPiece = new Knight();
                                        break;
                                    case 1:
                                        movingPiece = new Bishop();
                                        break;
                                    case 2:
                                        movingPiece = new Rook();
                                        break;
                                    case 3:
                                        movingPiece = new Queen();
                                        break;
                                    default:
                                        MessageBox.Show("Lỗi PromotionValue sai");
                                        break;
                                }
                                PromotionValue = -1;
                            }
                            else
                            {
                                PawnPromotion promoteForm = new PawnPromotion(pawn.Player);


                                while (promoteForm.PromotedPiece == null)
                                {
                                    if (promoteForm.ShowDialog() == DialogResult.OK)
                                    {
                                        break;
                                    }
                                }
                                switch (promoteForm.PromotedPiece.ToString())
                                {
                                    case "Chess.Knight":
                                        PromotionValue = 0;
                                        break;
                                    case "Chess.Bishop":
                                        PromotionValue = 1;
                                        break;
                                    case "Chess.Rook":
                                        PromotionValue = 2;
                                        break;
                                    case "Chess.Queen":
                                        PromotionValue = 3;
                                        break;
                                    default:
                                        MessageBox.Show("Wrong promotion piece");
                                        break;
                                }
                                movingPiece = promoteForm.PromotedPiece;
                            }
                            movingPiece.Player = pawn.Player;
                        }
                    }
                }
                if (movingPiece is CastlePiece)
                {
                    CastlePiece rookOrKing = (CastlePiece)movingPiece;
                    if (!bypassValidaiton) // Castling can't be done after moving
                        rookOrKing.CanCastle = false; 
                }
                if (movingPiece is King)
                {
                    King king = (King)movingPiece;
                    if (from.x - to.x == 2)
                    {   // Move rook for Queenside castle
                        boardArray[to.x + 1, from.y] = boardArray[0, from.y];
                        boardArray[0, from.y] = null;
                        castling = 1;
                    }
                    if (from.x - to.x == -2)
                    {   // Move rook for Kingside castle
                        boardArray[to.x - 1, from.y] = boardArray[COLUMNS - 1, from.y];
                        boardArray[COLUMNS - 1, from.y] = null;
                        castling = 1;
                    }
                }
                movingPiece.CalculateMoves();
                boardArray[from.x, from.y] = null;
                boardArray[to.x, to.y] = movingPiece;
                return true;
            }
            return false;
        }
        #endregion

        #region Find out if a square is vulnerable to attacks by another player

        /// <param name="player">The vulnerable player</param>
        /// <param name="boardArray">An optional substitute board for validating moves</param>
        /// <returns>True if square can be attacked</returns>
        public bool CheckSquareVulnerable(int squareX, int squareY, int player, ChessPiece[,] boardArray = null)
        {
            if (boardArray == null)
            {
                boardArray = this.boardArray;
            }

            for (int x = 0; x < boardArray.GetLength(0); x++)
            {
                for (int y = 0; y < boardArray.GetLength(1); y++)
                {
                    if (boardArray[x, y] != null && boardArray[x, y].Player != player)
                    {
                        foreach (Point point in PieceActions(x, y, true, true, false, boardArray))
                        {
                            if (point.x == squareX && point.y == squareY)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool ValidateRange(int value, int high, int low = -1)
        {
            return value > low && value < high;
        }

        public bool ValidateX(int value)
        {
            return ValidateRange(value, boardArray.GetLength(0));
        }

        public bool ValidateY(int value)
        {
            return ValidateRange(value, boardArray.GetLength(1));
        }

        public bool ValidatePoint(Point point)
        {
            return ValidateX(point.x) && ValidateY(point.y);
        }
        #endregion

    }
}
