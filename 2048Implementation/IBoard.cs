
namespace _2048Implementation
{
    public interface IBoard
    {
        /// <summary>
        /// Determines whether this instance can move in the specified direction.
        /// </summary>
        /// <param name="direction">The direction the move would be in.</param>
        /// <returns>
        ///   <c>true</c> if moving in the specified direction is a valid move; otherwise, <c>false</c>.
        /// </returns>
        bool CanMoveInDirection(MoveDirection direction);

        /// <summary>
        /// Gets the cell value at the specified row and column.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>The value of the cell at the specified row and column.</returns>
        int GetCellValue(int row, int column);

        /// <summary>
        /// Make a move in the specified direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        ///   <c>true</c> if cells were moved / merged; otherwise, <c>false</c>.
        bool Move(MoveDirection direction);

        /// <summary>
        /// Populates a random empty cell with a 2 (or possibly a 4?)
        /// </summary>
        void PlaceRandomCell();

        /// <summary>
        /// Sets the cell value at the specified row and value.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="value">The value to place in the specified row and column.</param>
        void SetCellValue(int row, int column, int value);

        /// <summary>
        /// Determines whether the cell at row and column was merged during the last move
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        ///   <c>true</c> if value in the cell at row and column is the result of a merge during the last move; otherwise, <c>false</c>.
        bool WasCellMerged(int row, int column);
    }
}
