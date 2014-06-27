using System.Collections.Generic;
using _2048Implementation;
using Xunit;
using Xunit.Extensions;

namespace _2048Tests
{
    public class CanMoveInDirectionTests
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[]
                    {
                        new[,]
                            {
                                {0, 0, 0, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Left,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0, 0, 0, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Right,
                        false
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0, 0, 0, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Down,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0, 0, 0, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Up,
                        false
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0, 2, 0, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Up,
                        false
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0, 2, 0, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Right,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0, 2, 0, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Left,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0, 2, 0, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Down,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Down,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Up,
                        false
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Left,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        MoveDirection.Right,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {2, 4, 8, 2}
                            },
                        MoveDirection.Right,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {2, 4, 8, 2}
                            },
                        MoveDirection.Left,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {2, 4, 8, 2}
                            },
                        MoveDirection.Down,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {2, 4, 8, 2}
                            },
                        MoveDirection.Up,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 16, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {2, 4, 8, 2}
                            },
                        MoveDirection.Right,
                        false
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 16, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {2, 4, 8, 2}
                            },
                        MoveDirection.Left,
                        false
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 16, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {2, 4, 8, 2}
                            },
                        MoveDirection.Up,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 16, 4, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {2, 4, 8, 2}
                            },
                        MoveDirection.Down,
                        true
                    };
            }
        }

        [Theory]
        [PropertyData("TestData")]
        public void CanMoveInDirection_returns_correct_result(int[,] initial, MoveDirection direction, bool expected)
        {
            // arrange
            var board = new Board();
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    board.SetCellValue(row, column, initial[row, column]);
                }
            }

            // act
            var actual = board.CanMoveInDirection(direction);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
