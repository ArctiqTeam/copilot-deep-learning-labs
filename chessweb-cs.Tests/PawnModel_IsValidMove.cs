using Xunit;
using ChessWeb.Models;

namespace PawnModel.UnitTests.Models
{
    public class PawnModel_IsValidMove
    {
        [Fact]
        public void WhitePawn_MovingOutOfBoard_ThrowsIndexOutOfRangeException()
        {
            var board = new Board();
            var pawn = new Pawn(PieceColor.White, new Position(1, 0));
            board.Squares[1, 0] = pawn;
            // Try to move one square up (out of board)
            Assert.Throws<IndexOutOfRangeException>(() => pawn.IsValidMove(new Position(1, 0), new Position(0, 0), board));
            // Try to move one square left (out of board)
            Assert.Throws<IndexOutOfRangeException>(() => pawn.IsValidMove(new Position(1, 0), new Position(1, -1), board));
        }

        [Fact]
        public void BlackPawn_MovingOutOfBoard_ThrowsIndexOutOfRangeException()
        {
            var board = new Board();
            var pawn = new Pawn(PieceColor.Black, new Position(6, 7));
            board.Squares[6, 7] = pawn;
            // Try to move one square down (out of board)
            Assert.Throws<IndexOutOfRangeException>(() => pawn.IsValidMove(new Position(6, 7), new Position(7, 7), board));
            // Try to move one square right (out of board)
            Assert.Throws<IndexOutOfRangeException>(() => pawn.IsValidMove(new Position(6, 7), new Position(6, 8), board));
        }
        [Fact]
        public void BlackPawn_CanMoveForward_OneSquare()
        {
            var board = new Board();
            var pawn = new Pawn(PieceColor.Black, new Position(1, 4));
            board.Squares[1, 4] = pawn;
            Assert.True(pawn.IsValidMove(new Position(1, 4), new Position(2, 4), board));
        }

            [Fact]
            public void BlackPawn_CanMoveForward_TwoSquares_FromStart()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.Black, new Position(1, 4));
                board.Squares[1, 4] = pawn;
                Assert.True(pawn.IsValidMove(new Position(1, 4), new Position(3, 4), board));
            }

            [Fact]
            public void BlackPawn_CannotMoveForward_TwoSquares_FromOtherPosition()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.Black, new Position(2, 4));
                board.Squares[2, 4] = pawn;
                Assert.False(pawn.IsValidMove(new Position(2, 4), new Position(4, 4), board));
            }

            [Fact]
            public void BlackPawn_CanCapture_Diagonally()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.Black, new Position(1, 4));
                var enemy = new Pawn(PieceColor.White, new Position(2, 5));
                board.Squares[1, 4] = pawn;
                board.Squares[2, 5] = enemy;
                Assert.True(pawn.IsValidMove(new Position(1, 4), new Position(2, 5), board));
            }

            [Fact]
            public void BlackPawn_CannotMoveDiagonally_WithoutCapture()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.Black, new Position(1, 4));
                board.Squares[1, 4] = pawn;
                Assert.False(pawn.IsValidMove(new Position(1, 4), new Position(2, 5), board));
            }

            [Fact]
            public void BlackPawn_CannotCapture_OwnPiece_Diagonally()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.Black, new Position(1, 4));
                var friendly = new Pawn(PieceColor.Black, new Position(2, 5));
                board.Squares[1, 4] = pawn;
                board.Squares[2, 5] = friendly;
                Assert.False(pawn.IsValidMove(new Position(1, 4), new Position(2, 5), board));
            }

            [Fact]
            public void BlackPawn_CannotMoveForward_IfBlocked()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.Black, new Position(1, 4));
                var blocker = new Pawn(PieceColor.White, new Position(2, 4));
                board.Squares[1, 4] = pawn;
                board.Squares[2, 4] = blocker;
                Assert.False(pawn.IsValidMove(new Position(1, 4), new Position(2, 4), board));
            }

            [Fact]
            public void BlackPawn_CannotMoveForward_TwoSquares_IfBlocked_OneAhead()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.Black, new Position(1, 4));
                var blocker = new Pawn(PieceColor.White, new Position(2, 4));
                board.Squares[1, 4] = pawn;
                board.Squares[2, 4] = blocker;
                Assert.False(pawn.IsValidMove(new Position(1, 4), new Position(3, 4), board));
            }

            [Fact]
            public void BlackPawn_CannotMoveForward_TwoSquares_IfBlocked_TwoAhead()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.Black, new Position(1, 4));
                var blocker = new Pawn(PieceColor.White, new Position(3, 4));
                board.Squares[1, 4] = pawn;
                board.Squares[3, 4] = blocker;
                Assert.False(pawn.IsValidMove(new Position(1, 4), new Position(3, 4), board));
            }

            [Fact]
            public void Pawn_CanMoveForward_OneSquare()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                board.Squares[6, 4] = pawn;
                Assert.True(pawn.IsValidMove(new Position(6, 4), new Position(5, 4), board));
            }

            [Fact]
            public void Pawn_CanMoveForward_TwoSquares_FromStart()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                board.Squares[6, 4] = pawn;
                Assert.True(pawn.IsValidMove(new Position(6, 4), new Position(4, 4), board));
            }

            [Fact]
            public void Pawn_CannotMoveForward_TwoSquares_IfBlocked()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                var blocker = new Pawn(PieceColor.White, new Position(5, 4));
                board.Squares[6, 4] = pawn;
                board.Squares[5, 4] = blocker;
                Assert.False(pawn.IsValidMove(new Position(6, 4), new Position(4, 4), board));
            }

            [Fact]
            public void Pawn_CanCapture_Diagonally()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                var enemy = new Pawn(PieceColor.Black, new Position(5, 5));
                board.Squares[6, 4] = pawn;
                board.Squares[5, 5] = enemy;
                Assert.True(pawn.IsValidMove(new Position(6, 4), new Position(5, 5), board));
            }

            [Fact]
            public void Pawn_CannotMoveDiagonally_WithoutCapture()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                board.Squares[6, 4] = pawn;
                Assert.False(pawn.IsValidMove(new Position(6, 4), new Position(5, 5), board));
            }

            [Fact]
            public void Pawn_CannotCapture_OwnPiece_Diagonally()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                var friendly = new Pawn(PieceColor.White, new Position(5, 5));
                board.Squares[6, 4] = pawn;
                board.Squares[5, 5] = friendly;
                Assert.False(pawn.IsValidMove(new Position(6, 4), new Position(5, 5), board));
            }

            [Fact]
            public void Pawn_CannotMoveForward_IntoOccupiedSquare()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                var blocker = new Pawn(PieceColor.Black, new Position(5, 4));
                board.Squares[6, 4] = pawn;
                board.Squares[5, 4] = blocker;
                Assert.False(pawn.IsValidMove(new Position(6, 4), new Position(5, 4), board));
            }

            [Fact]
            public void Pawn_CannotMoveForward_TwoSquares_IfBlocked_OneAhead()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                var blocker = new Pawn(PieceColor.Black, new Position(5, 4));
                board.Squares[6, 4] = pawn;
                board.Squares[5, 4] = blocker;
                Assert.False(pawn.IsValidMove(new Position(6, 4), new Position(4, 4), board));
            }

            [Fact]
            public void Pawn_CannotMoveForward_TwoSquares_IfBlocked_TwoAhead()
            {
                var board = new Board();
                var pawn = new Pawn(PieceColor.White, new Position(6, 4));
                var blocker = new Pawn(PieceColor.Black, new Position(4, 4));
                board.Squares[6, 4] = pawn;
                board.Squares[4, 4] = blocker;
                Assert.False(pawn.IsValidMove(new Position(6, 4), new Position(4, 4), board));
            }
