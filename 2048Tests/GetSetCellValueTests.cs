using System;
using _2048Implementation;
using Xunit;
using Xunit.Extensions;

namespace _2048Tests
{
    public class GetSetCellValueTests
    {
        [Theory]
        [InlineData(0, 0, 2)]
        [InlineData(0, 1, 4)]
        [InlineData(0, 2, 8)]
        [InlineData(0, 3, 16)]

        [InlineData(1, 0, 32)]
        [InlineData(1, 1, 64)]
        [InlineData(1, 2, 128)]
        [InlineData(1, 3, 256)]

        [InlineData(2, 0, 512)]
        [InlineData(2, 1, 1024)]
        [InlineData(2, 2, 2048)]
        [InlineData(2, 3, 1024)]

        [InlineData(3, 0, 512)]
        [InlineData(3, 1, 256)]
        [InlineData(3, 2, 128)]
        [InlineData(3, 3, 64)]
        public void GetCellValue_returns_the_same_value_provided_to_SetCellValue(int row, int column, int expected)
        {
            // arrange
            var board = new Board();

            // act
            board.SetCellValue(row, column, expected);
            var actual = board.GetCellValue(row, column);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetCellValue_throws_exception_for_row_less_than_0()
        {
            // arrange
            var board = new Board();

            // act
            var ex = Assert.Throws<ArgumentException>(() => board.SetCellValue(-1, 0, 2));

            // assert
            Assert.Equal("Row cannot be less than 0\r\nParameter name: row", ex.Message);
        }

        [Fact]
        public void SetCellValue_throws_exception_for_row_greater_than_3()
        {
            // arrange
            var board = new Board();

            // act
            var ex = Assert.Throws<ArgumentException>(() => board.SetCellValue(4, 0, 2));

            // assert
            Assert.Equal("Row cannot be greater than 3\r\nParameter name: row", ex.Message);
        }

        [Fact]
        public void SetCellValue_throws_exception_for_column_less_than_0()
        {
            // arrange
            var board = new Board();

            // act
            var ex = Assert.Throws<ArgumentException>(() => board.SetCellValue(0, -1, 2));

            // assert
            Assert.Equal("Column cannot be less than 0\r\nParameter name: column", ex.Message);
        }

        [Fact]
        public void SetCellValue_throws_exception_for_column_greater_than_3()
        {
            // arrange
            var board = new Board();

            // act
            var ex = Assert.Throws<ArgumentException>(() => board.SetCellValue(0, 4, 2));

            // assert
            Assert.Equal("Column cannot be greater than 3\r\nParameter name: column", ex.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void SetCellValue_throws_exception_for_value_that_is_not_zero_or_a_power_of_2(int value)
        {
            // arrange
            var board = new Board();

            // act
            var ex = Assert.Throws<ArgumentException>(() => board.SetCellValue(0, 3, value));

            // assert
            Assert.Equal("Cell value must be 0 or a power of 2 between 2 and 2048 (inclusive)\r\nParameter name: value", ex.Message);
        }
    }
}
