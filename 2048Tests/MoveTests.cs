using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;
using _2048Implementation;

namespace _2048Tests
{
    public class MoveTests
    {
        public static IEnumerable<object[]> MoveLeftTestData
        {
            get
            {
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,0,0,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {2,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,2,0,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {4,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,2,2,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {4,4,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4,0,0,2},
                                {0,0,2,0},
                                {0,2,0,0},
                                {2,0,0,0}
                            },
                        new[,]
                            {
                                {4,2,0,0},
                                {2,0,0,0},
                                {2,0,0,0},
                                {2,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4,0,2,2},
                                {0,8,2,8},
                                {2,2,0,0},
                                {2,0,0,32}
                            },
                        new[,]
                            {
                                {4,4,0,0},
                                {8,2,8,0},
                                {4,0,0,0},
                                {2,32,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {2,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            false
                    };
            }
        }
        public static IEnumerable<object[]> MoveRightTestData
        {
            get
            {
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,0,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,2,0,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,0,4},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,2,2,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,4,4},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4,0,0,2},
                                {0,0,2,0},
                                {0,2,0,0},
                                {2,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,4,2},
                                {0,0,0,2},
                                {0,0,0,2},
                                {0,0,0,2}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4,0,2,2},
                                {0,8,2,8},
                                {2,2,0,0},
                                {2,0,0,32}
                            },
                        new[,]
                            {
                                {0,0,4,4},
                                {0,8,2,8},
                                {0,0,0,4},
                                {0,0,2,32}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,0,0,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,0,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            false
                    };
            }
        }
        public static IEnumerable<object[]> MoveUpTestData
        {
            get
            {
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,2}
                            },
                        new[,]
                            {
                                {0,0,0,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,0},
                                {2,0,0,0},
                                {2,0,0,0}
                            },
                        new[,]
                            {
                                {4,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,2,2,2},
                                {2,0,0,0},
                                {2,0,0,0},
                                {2,0,0,0}
                            },
                        new[,]
                            {
                                {4,2,2,2},
                                {4,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4,0,0,2},
                                {0,0,2,0},
                                {0,2,0,0},
                                {2,0,0,0}
                            },
                        new[,]
                            {
                                {4,2,2,2},
                                {2,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4,0,2,2},
                                {0,8,2,8},
                                {2,2,0,0},
                                {2,0,0,32}
                            },
                        new[,]
                            {
                                {4,8,4,2},
                                {4,2,0,8},
                                {0,0,0,32},
                                {0,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,0,0,16},
                                {0,0,0,32},
                                {0,0,0,4},
                                {0,0,0,2}
                            },
                        new[,]
                            {
                                {0,0,0,16},
                                {0,0,0,32},
                                {0,0,0,4},
                                {0,0,0,2}
                            },
                            false
                    };
            }
        }
        public static IEnumerable<object[]> MoveDownTestData
        {
            get
            {
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,0,0,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,2}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,0,0,2},
                                {0,0,0,0},
                                {0,0,0,2},
                                {0,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,4}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,0,0,0},
                                {2,0,0,0},
                                {2,0,0,0},
                                {2,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,0},
                                {4,0,0,0},
                                {4,0,0,0}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,0,0,2},
                                {0,0,2,0},
                                {0,2,0,0},
                                {4,0,0,0}
                            },
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,0},
                                {2,0,0,0},
                                {4,2,2,2}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4,32,2,2},
                                {0,8,2,8},
                                {2,8,0,0},
                                {2,0,0,32}
                            },
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,2},
                                {4,32,0,8},
                                {4,16,4,32}
                            },
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,2},
                                {2,32,0,8},
                                {4,16,4,32}
                            },
                        new[,]
                            {
                                {0,0,0,0},
                                {0,0,0,2},
                                {2,32,0,8},
                                {4,16,4,32}
                            },
                            false
                    };
            }
        }

        [Theory]
        [PropertyData("MoveLeftTestData")]
        public void Move_left_moves_board_correctly(int[,] initial, int[,] expected, bool moved)
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
            var movedActual = board.Move(MoveDirection.Left);

            // assert
            Assert.Equal(moved, movedActual);
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    var actualValue = board.GetCellValue(row, column);
                    var expectedValue = expected[row, column];
                    Assert.Equal(expectedValue, actualValue);
                }
            }
            Assert.Equal(moved, movedActual);
        }

        [Theory]
        [PropertyData("MoveRightTestData")]
        public void Move_right_moves_board_correctly(int[,] initial, int[,] expected, bool moved)
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
            var movedActual = board.Move(MoveDirection.Right);

            // assert
            Assert.Equal(moved, movedActual);
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    var actualValue = board.GetCellValue(row, column);
                    var expectedValue = expected[row, column];
                    Assert.Equal(expectedValue, actualValue);
                }
            }
            Assert.Equal(moved, movedActual);
        }

        [Theory]
        [PropertyData("MoveUpTestData")]
        public void Move_up_moves_board_correctly(int[,] initial, int[,] expected, bool moved)
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
            var movedActual = board.Move(MoveDirection.Up);

            // assert
            Assert.Equal(moved, movedActual);
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    var actualValue = board.GetCellValue(row, column);
                    var expectedValue = expected[row, column];
                    Assert.Equal(expectedValue, actualValue);
                }
            }
            Assert.Equal(moved, movedActual);
        }

        [Theory]
        [PropertyData("MoveDownTestData")]
        public void Move_down_moves_board_correctly(int[,] initial, int[,] expected, bool moved)
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
            var movedActual = board.Move(MoveDirection.Down);

            // assert
            Assert.Equal(moved, movedActual);
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    var actualValue = board.GetCellValue(row, column);
                    var expectedValue = expected[row, column];
                    Assert.Equal(expectedValue, actualValue);
                }
            }
            Assert.Equal(moved, movedActual);
        }
    }
}
