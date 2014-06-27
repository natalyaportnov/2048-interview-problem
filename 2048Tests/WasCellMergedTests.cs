using System.Collections.Generic;
using _2048Implementation;
using Xunit;
using Xunit.Extensions;

namespace _2048Tests
{
    public class WasCellMergedTests
    {
        public static IEnumerable<object[]> LeftTestData
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
                            0,
                            0,
                            false
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
                            0,
                            0,
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,2,4,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            0,
                            0,
                            true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2,2,4,2},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}
                            },
                            0,
                            1,
                            false
                    };
            }
        }
        public static IEnumerable<object[]> RightTestData
        {
            get
            {
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        0,
                        3,
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
                        0,
                        3,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {2, 2, 2, 2},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0},
                                {0, 0, 0, 0}
                            },
                        0,
                        2,
                        true
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4, 0, 2, 2},
                                {0, 0, 2, 0},
                                {0, 2, 0, 0},
                                {2, 0, 0, 0}
                            },
                        0,
                        2,
                        false
                    };
                yield return new object[]
                    {
                        new[,]
                            {
                                {4, 4, 2, 2},
                                {0, 0, 2, 0},
                                {0, 2, 0, 0},
                                {2, 0, 0, 0}
                            },
                        0,
                        2,
                        true
                    };
            }
        }
        public static IEnumerable<object[]> UpTestData
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
                            0,
                            3,
                            false
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
                            0,
                            0,
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
                            1,
                            0,
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
                            1,
                            0,
                            false
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
                            0,
                            2,
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
                            3,
                            0,
                            false
                    };
            }
        }
        public static IEnumerable<object[]> DownTestData
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
                        3,
                        3,
                        false
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
                        3,
                        3,
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
                        3,
                        0,
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
                        3,
                        0,
                        false
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
                        2,
                        0,
                        false
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
                        3,
                        2,
                        false
                    };
            }
        }

        [Theory]
        [PropertyData("LeftTestData")]
        public void Move_left_merges_cells_correctly(int[,] initial, int rowToTest, int columnToTest, bool expected)
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
            board.Move(MoveDirection.Left);

            // assert
            Assert.Equal(expected, board.WasCellMerged(rowToTest, columnToTest));
        }

        [Theory]
        [PropertyData("RightTestData")]
        public void Move_right_merges_cells_correctly(int[,] initial, int rowToTest, int columnToTest, bool expected)
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
            board.Move(MoveDirection.Right);

            // assert
            Assert.Equal(expected, board.WasCellMerged(rowToTest, columnToTest));
        }

        [Theory]
        [PropertyData("UpTestData")]
        public void Move_up_merges_cells_correctly(int[,] initial, int rowToTest, int columnToTest, bool expected)
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
            board.Move(MoveDirection.Up);

            // assert
            Assert.Equal(expected, board.WasCellMerged(rowToTest, columnToTest));
        }

        [Theory]
        [PropertyData("DownTestData")]
        public void Move_down_merges_cells_correctly(int[,] initial, int rowToTest, int columnToTest, bool expected)
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
            board.Move(MoveDirection.Down);

            // assert
            Assert.Equal(expected, board.WasCellMerged(rowToTest, columnToTest));
        }
    }
}
