using Morpion;


namespace TestProjectMorpion
{
    public class BoardTests
    {
        [Fact]
     
        public void TheFunctionEmptyCellShouldReturnTrue()
        {
            
            var board = new Board();
            bool result = board.IsCellEmpty(0, 0);
            Assert.True(result);
        }

        [Fact]

        public void TheFunctionEmptyCellShouldReturnFalse()
        {
            var board = new Board();
            board.PlayMove(1, 1,'X');
            Assert.False(board.IsCellEmpty(1, 1));
        }

        [Fact]
        public void TheFunctionIsGameWonShouldReturnTrueRow()
        {
            
            var board = new Board();

            
            board.PlayMove(0, 0, 'X');
            board.PlayMove(0, 1, 'X');
            board.PlayMove(0, 2, 'X');

            bool result = board.IsGameWon('X');

            
            Assert.True(result);
        }


        [Fact]
        public void TheFunctionIsGameWonShouldReturnTrueLine()
        {

            var board = new Board();


            board.PlayMove(0, 0, 'X');
            board.PlayMove(1, 0, 'X');
            board.PlayMove(2, 0, 'X');

            bool result = board.IsGameWon('X');


            Assert.True(result);
        }


        [Fact]
        public void TheFunctionIsGameWonShouldReturnTrueDiagonale()
        {

            var board = new Board();


            board.PlayMove(0, 0, 'X');
            board.PlayMove(1, 1, 'X');
            board.PlayMove(2, 2, 'X');

            bool result = board.IsGameWon('X');


            Assert.True(result);
        }


        [Fact]
        public void TheFunctionIsGameWonShouldReturnTrueOtherDiagonale()
        {

            var board = new Board();


            board.PlayMove(0, 2, 'X');
            board.PlayMove(1, 1, 'X');
            board.PlayMove(2, 0, 'X');

            bool result = board.IsGameWon('X');


            Assert.True(result);
        }

        [Fact]
        public void TheFunctionTestDrawShouldReturnTrue()
        {
            var board = new Board();

            board.PlayMove(0, 0, 'X');
            board.PlayMove(0, 1, 'O');
            board.PlayMove(0, 2 ,'O');

            board.PlayMove(1, 0, 'O');
            board.PlayMove(1, 1, 'X');
            board.PlayMove(1, 2, 'X');

            board.PlayMove(2, 0, 'X');
            board.PlayMove(2, 1, 'X');
            board.PlayMove(2, 2, 'O');

            bool result = board.IsDraw();
            Assert.True(result);

        }
    }
}
