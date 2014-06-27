
namespace _2048Implementation
{
    public class Game
    {
        private readonly IBoard _Board;
        private readonly IBoardWriter _BoardWriter;

        public Game(IBoard board, IBoardWriter boardWriter)
        {
            _Board = board;
            _BoardWriter = boardWriter;
        }

        public void Start()
        {
            _Board.PlaceRandomCell();
            _Board.PlaceRandomCell();
            _BoardWriter.WriteBoard(_Board);
        }

        public GameState MakeMove(MoveDirection direction)
        {
            _BoardWriter.Clear();

            if (!_Board.CanMoveInDirection(direction))
            {
                _BoardWriter.WriteBoard(_Board);
                _BoardWriter.WriteMessage("No available moves in that direction.");
            }
            else
            {
                _Board.Move(direction);
                _Board.PlaceRandomCell();
                _BoardWriter.WriteBoard(_Board);
            }

            var gameState = CheckGameState();

            if (gameState == GameState.Won)
            {
                _BoardWriter.WriteMessage("You won! Or there was a severe programming error.");
            }
            else if (gameState == GameState.Lost)
            {
                _BoardWriter.WriteMessage("No more moves! Game over man! Game over!");
            }

            return gameState;
        }

        private GameState CheckGameState()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (_Board.GetCellValue(row, column) == 2048)
                    {
                        return GameState.Won;
                    }
                }
            }

            if (!_Board.CanMoveInDirection(MoveDirection.Down)
                && !_Board.CanMoveInDirection(MoveDirection.Up)
                && !_Board.CanMoveInDirection(MoveDirection.Right)
                && !_Board.CanMoveInDirection(MoveDirection.Left))
            {
                return GameState.Lost;
            }

            return GameState.InProgress;
        }
    }
}
