using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace _2048Implementation
{
    public class Board : IBoard, IEnumerable
    {
        #region Private Variables and Constructor
        private readonly Cell[][] _Board;
        private readonly Random _Random;
        private readonly int[] _WorkArray;
        private const int _NumRows = 4;
        private const int _NumColumns = 4;
        private const int _Empty = 0; // An alias to represent an empty Cell.

        public Board()
        {
            // Allocate board space
            _Board = new Cell[_NumRows][];
            for (int row = 0; row < _NumRows; row++)
                _Board[row] = new Cell[_NumColumns];

            // Initialize board space
            for (int row = 0; row < _NumRows; row++)
                for (int col = 0; col < _NumColumns; col++)
                    _Board[row][col] = new Cell(_Empty, row, col);

            _Random = new Random();

            _WorkArray = new int[Math.Max(_NumRows, _NumColumns)];
        }
        #endregion

        #region Private Properties and Methods
        // thisBoard is just an alias for 'this'. It reads a little better.
        private Board thisBoard
        {
            get { return this; }
        }

        private int cellCount
        {
            get
            {
                int count = 0;
                foreach (Cell cell in thisBoard)
                    if (!cell.Empty)
                        count++;

                return count;
            }
        }

        private IEnumerable<List<Cell>> Columns
        {
            get
            {
                for (int col = 0; col < _NumColumns; col++)
                    yield return Column(col);
            }
        }

        private IEnumerable<List<Cell>> Rows
        {
            get
            {
                for (int row = 0; row < _NumRows; row++)
                    yield return Row(row);
            }
        }

        private List<Cell> Column(int columnIndex)
        {
            List<Cell> column = new List<Cell>(_NumRows);

            for (int row = 0; row < _NumRows; row++)
                column.Add(_Board[row][columnIndex]);

            return column;
        }

        private List<Cell> Row(int rowIndex)
        {
            return _Board[rowIndex].ToList();
        }

        // CanShift assumes that the cells are in order of the current MoveDirection
        private bool CanShift(Cell[] line)
        {
            // Check for an empty cell a non-empty cell can move into.
            bool foundNumber = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (foundNumber && line[i].Empty)
                    return true;

                if (!line[i].Empty)
                    foundNumber = true;
            }

            // Check for non-empty adjacent cells with same value
            for (int i = 0; i < line.Length - 1; i++)
                if (!line[i].Empty)
                    if (line[i].Value == line[i + 1].Value)
                        return true;

            return false;
        }

        // Shift assumes that the cells are in the reverse order of the current MoveDirection
        private bool Shift(Cell[] line)
        {
            bool movedOrMerged = false;
            int w = 0; // An iterator for the workArray

            ClearWorkArray();

            // Puts cell values from line in the appropriate index in workArray
            for (int i = 0; i < line.Length; i++)
            {
                if (!line[i].Empty)
                {
                    if (_WorkArray[w] == _Empty)
                    {
                        _WorkArray[w] = line[i].Value;
                    }
                    else if (_WorkArray[w] == line[i].Value)
                    {
                        _WorkArray[w] *= 2;
                        line[w++].Merged = true;
                    }
                    else
                    {
                        _WorkArray[++w] = line[i].Value;
                    }
                }
            }

            // Determine if any cells merged or moved while copying the work array
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Value != _WorkArray[i])
                    movedOrMerged = true;
                line[i].Value = _WorkArray[i];
            }

            return movedOrMerged;
        }
        
        private void ClearMergedField()
        {
            foreach (Cell cell in thisBoard)
                cell.Merged = false;
        }

        private void ClearWorkArray()
        {
            for (int w = 0; w < _WorkArray.Length; w++)
                _WorkArray[w] = _Empty;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Determines whether this instance can move in the specified direction.
        /// </summary>
        /// <param name="direction">The direction the move would be in.</param>
        /// <returns>
        ///   <c>true</c> if moving in the specified direction is a valid move; otherwise, <c>false</c>.
        /// </returns>
        public bool CanMoveInDirection(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    foreach (var column in Columns)
                        if (CanShift(column.OrderByDescending(cell => cell.Row).ToArray()))
                            return true;
                    break;
                case MoveDirection.Down:
                    foreach (var column in Columns)
                        if (CanShift(column.OrderBy(cell => cell.Row).ToArray()))
                            return true;
                    break;
                case MoveDirection.Left:
                    foreach (var row in Rows)
                        if (CanShift(row.OrderByDescending(cell => cell.Col).ToArray()))
                            return true;
                    break;
                case MoveDirection.Right:
                    foreach (var row in Rows)
                        if (CanShift(row.OrderBy(cell => cell.Col).ToArray()))
                            return true;
                    break;
            }

            return false;
        }

        /// <summary>
        /// Gets the cell value at the specified row and column.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        /// The value of the cell at the specified row and column.
        /// </returns>
        public int GetCellValue(int row, int column)
        {
            return _Board[row][column].Value;
        }

        /// <summary>
        /// Make a move in the specified direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        /// <c>true</c> if cells were moved / merged; otherwise, <c>false</c>.
        public bool Move(MoveDirection direction)
        {
            ClearMergedField();

            bool movedOrMerged = false;

            switch (direction)
            {
                case MoveDirection.Up:
                    foreach (var column in Columns)
                        if (Shift(column.OrderBy(cell => cell.Row).ToArray()))
                            movedOrMerged = true;
                    break;
                case MoveDirection.Down:
                    foreach (var column in Columns)
                        if (Shift(column.OrderByDescending(cell => cell.Row).ToArray()))
                            movedOrMerged = true;
                    break;
                case MoveDirection.Left:
                    foreach (var row in Rows)
                        if (Shift(row.OrderBy(cell => cell.Col).ToArray()))
                            movedOrMerged = true;
                    break;
                case MoveDirection.Right:
                    foreach (var row in Rows)
                        if (Shift(row.OrderByDescending(cell => cell.Col).ToArray()))
                            movedOrMerged = true;
                    break;
            }

            return movedOrMerged;
        }

        /// <summary>
        /// Populates a random empty cell with a 2 (or possibly a 4?)
        /// </summary>
        public void PlaceRandomCell()
        {
            int numEmpty = _NumRows * _NumColumns - cellCount;
            int rand = _Random.Next(0, numEmpty);

            int index = 0;
            foreach (Cell cell in thisBoard)
                if (cell.Empty)
                {
                    if (index == rand)
                    {
                        cell.Value = 2;
                        return;
                    }
                    else
                        index++;
                }
        }

        /// <summary>
        /// Sets the cell value at the specified row and value.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="value">The value to place in the specified row and column.</param>
        public void SetCellValue(int row, int column, int value)
        {
            if (row < 0)
                throw new ArgumentException("Row cannot be less than 0\r\nParameter name: row");
            if (_NumRows <= row)
                throw new ArgumentException("Row cannot be greater than 3\r\nParameter name: row");
            if (column < 0)
                throw new ArgumentException("Column cannot be less than 0\r\nParameter name: column");
            if (_NumColumns <= column)
                throw new ArgumentException("Column cannot be greater than 3\r\nParameter name: column");

            bool isPowerOf2 = false;
            for (int p = 1; p <= 11; p++)
                if (value == Math.Pow(2, p))
                    isPowerOf2 = true;

            if (!isPowerOf2 && value != 0)
                throw new ArgumentException("Cell value must be 0 or a power of 2 between 2 and 2048 (inclusive)\r\nParameter name: value");

            _Board[row][column].Value = value;
        }

        /// <summary>
        /// Determines whether the cell at row and column was merged during the last move
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        /// <c>true</c> if value in the cell at row and column is the result of a merge during the last move; otherwise, <c>false</c>.
        public bool WasCellMerged(int row, int column)
        {
            return _Board[row][column].Merged;
        }

        // The GetEnumerator method of the IEnumerable interface.
        // This makes it possible to iterate over the cells of a Board
        // Its inclusion was unnecessary, but fun.
        public IEnumerator GetEnumerator()
        {
            for (int row = 0; row < _NumRows; row++)
                for (int col = 0; col < _NumColumns; col++)
                    yield return _Board[row][col];
        }
        #endregion
    }
}
