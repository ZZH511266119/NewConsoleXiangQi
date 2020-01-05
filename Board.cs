using System;
using System.Collections.Generic;
using System.Text;

namespace XiangqiProject
{
    class Board
    {
        public Piece[,] board = new Piece[10, 9];
        public Piece[,] Big = new Piece[14, 13];
        public int column;
        public int row;

        Piece blackRood1 = new rood("black", 0, 0);

        Piece blackHorse1 = new horse("black", 1, 0);

        Piece blackElephant1 = new elephant("black", 2, 0);

        Piece blackGuard1 = new guard("black", 3, 0);

        Piece blackGeneral = new general("black", 4, 0);

        Piece blackGuard2 = new guard("black", 5, 0);

        Piece blackElephant2 = new elephant("black", 6, 0);

        Piece blackHorse2 = new horse("black", 7, 0);

        Piece blackRood2 = new rood("black", 8, 0);

        Piece blackCannon1 = new cannon("black", 1, 2);

        Piece blackCannon2 = new cannon("black", 7, 2);

        Piece blackSoldier1 = new soldier("black", 0, 3);

        Piece blackSoldier2 = new soldier("black", 2, 3);

        Piece blackSoldier3 = new soldier("black", 4, 3);

        Piece blackSoldier4 = new soldier("black", 6, 3);

        Piece blackSoldier5 = new soldier("black", 8, 3);

        Piece redRood1 = new rood("red", 0, 9);

        Piece redHorse1 = new horse("red", 1, 9);

        Piece redElephant1 = new elephant("red", 2, 9);

        Piece redGuard1 = new guard("red", 3, 9);

        Piece redGeneral = new general("red", 4, 9);

        Piece redGuard2 = new guard("red", 5, 9);

        Piece redElephant2 = new elephant("red", 6, 9);

        Piece redHorse2 = new horse("red", 7, 9);

        Piece redRood2 = new rood("red", 8, 9);

        Piece redCannon1 = new cannon("red", 1, 7);

        Piece redCannon2 = new cannon("red", 7, 7);

        Piece redSoldier1 = new soldier("red", 0, 6);

        Piece redSoldier2 = new soldier("red", 2, 6);

        Piece redSoldier3 = new soldier("red", 4, 6);

        Piece redSoldier4 = new soldier("red", 6, 6);

        Piece redSoldier5 = new soldier("red", 8, 6);
        public Board()
        {

        }

        public void InitializeBorad()
        {
            board[0, 0] = blackRood1;

            board[0, 1] = blackHorse1;

            board[0, 2] = blackElephant1;

            board[0, 3] = blackGuard1;

            board[0, 4] = blackGeneral;

            board[0, 5] = blackGuard2;

            board[0, 6] = blackElephant2;

            board[0, 7] = blackHorse2;

            board[0, 8] = blackRood2;

            board[2, 1] = blackCannon1;

            board[2, 7] = blackCannon2;

            board[3, 0] = blackSoldier1;

            board[3, 2] = blackSoldier2;

            board[3, 4] = blackSoldier3;

            board[3, 6] = blackSoldier4;

            board[3, 8] = blackSoldier5;

            board[9, 0] = redRood1;

            board[9, 1] = redHorse1;

            board[9, 2] = redElephant1;

            board[9, 3] = redGuard1;

            board[9, 4] = redGeneral;

            board[9, 5] = redGuard2;

            board[9, 6] = redElephant2;

            board[9, 7] = redHorse2;

            board[9, 8] = redRood2;

            board[7, 1] = redCannon1;

            board[7, 7] = redCannon2;

            board[6, 0] = redSoldier1;

            board[6, 2] = redSoldier2;

            board[6, 4] = redSoldier3;

            board[6, 6] = redSoldier4;

            board[6, 8] = redSoldier5;

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (board[j, i] == null)
                    {
                        board[j, i] = new nochess(i, j);
                    }
                }
            }

        }

        public string GetChessName(int column, int row)
        {

            return board[column, row].GetName();
        }

        public string GetChessColor(int column, int row)
        {
            return board[column, row].GetColor();
        }

        public void CopyCanGo()
        {
            for (int i = 2; i <= 11; i++)
            {
                for (int j = 2; j <= 10; j++)
                {
                    board[i - 2, j - 2].canGo = Big[i, j].canGo;
                }

            }
            for (int i = 0; i <= 13; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    Big[i, j] = new nochess(i, j);
                }

            }
        }

        public void CreateBigBoard()
        {
            for (int i = 0; i <= 13; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    Big[i, j] = new nochess(i, j);
                }

            }
            for (int i = 2; i <= 11; i++)
            {
                for (int j = 2; j <= 10; j++)
                {
                    Big[i, j] = board[i - 2, j - 2];
                }

            }


        }

        public void WhereCanPieceGo(int chessColumn, int chessRow)
        {
            switch (board[chessRow, chessColumn].GetName())
            {
                case "兵":
                    CreateBigBoard();
                    column = chessColumn + 2;
                    row = chessRow + 2;
                    switch (board[chessRow, chessColumn].GetColor())
                    {
                        case "red":
                            if (chessRow >= 5)
                            {
                                if (Big[row - 1, column].GetColor() != "red")
                                {
                                    Big[row - 1, column].ChangeCanGo();
                                }
                            }
                            else if (chessRow <= 4)
                            {
                                if (Big[row, column + 1].GetColor() != "red")
                                {
                                    Big[row, column + 1].ChangeCanGo();
                                }
                                if (Big[row, column - 1].GetColor() != "red")
                                {
                                    Big[row, column - 1].ChangeCanGo();
                                }
                                if (Big[row - 1, column].GetColor() != "red")
                                {
                                    Big[row - 1, column].ChangeCanGo();
                                }
                            }
                            CopyCanGo();
                            break;

                        case "black":
                            if (chessRow <= 4)
                            {
                                Big[row + 1, column].ChangeCanGo();
                            }
                            else if (chessRow >= 5)
                            {
                                if (Big[row, column + 1].GetColor() != "black")
                                {
                                    Big[row, column + 1].ChangeCanGo();
                                }
                                if (Big[row, column - 1].GetColor() != "black")
                                {
                                    Big[row, column - 1].ChangeCanGo();
                                }
                                if (Big[row + 1, column].GetColor() != "black")
                                {
                                    Big[row + 1, column].ChangeCanGo();
                                }
                            }
                            CopyCanGo();
                            break;
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                case "炮":

                    for (int i = chessRow - 1; i >= 0; i--)
                    {
                        //如果起始点的下一个位置没有棋子，则显示可走
                        if (board[i, chessColumn].GetName().Equals("nochess"))
                        {
                            board[i, chessColumn].ChangeCanGo();
                        }
                        //如果下一个位置有棋子X
                        else
                        {
                            //那么，从这个棋子X开始，往棋子X之后继续遍历
                            for (int i1 = i - 1; i1 >= 0; i1--)
                            {
                                //如果棋子X之后一个位置有棋子，且为对方的棋子，则显示可走，然后到此为止，即退出当前循环，也要退出最外层的循环
                                if ((!board[i1, chessColumn].GetName().Equals("nochess")) && (!board[i1, chessColumn].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[i1, chessColumn].ChangeCanGo();
                                    i = -1;
                                    break;

                                }
                                //如果棋子X之后一个位置有棋子，但是是我方棋子，此时，也到此位置，退出当前循环和最外层循环
                                else if ((!board[i1, chessColumn].GetName().Equals("nochess")) && (board[i1, chessColumn].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    i = -1;
                                    break;
                                }
                                //如果棋子X之后一个位置没棋子，此时，也到此位置，退出当前循环和最外层循环
                                else if (board[i1, chessColumn].GetName().Equals("nochess"))
                                {
                                }
                                //如果棋子X之后一个位置没有棋子，则继续进行此循环，看看棋子X之后的一个位置是否有棋子。。。。。。
                            }
                        }
                    }
                    for (int i = chessRow + 1; i <= 9; i++)
                    {
                        if (board[i, chessColumn].GetName().Equals("nochess"))
                        {
                            board[i, chessColumn].ChangeCanGo();
                        }
                        else
                        {
                            for (int i1 = i + 1; i1 <= 9; i1++)
                            {
                                if ((!board[i1, chessColumn].GetName().Equals("nochess")) && (!board[i1, chessColumn].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[i1, chessColumn].ChangeCanGo();

                                    i = 10;
                                    break;
                                }
                                else if ((!board[i1, chessColumn].GetName().Equals("nochess")) && (board[i1, chessColumn].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    i = 10;
                                    break;
                                }
                                else if (board[i1, chessColumn].GetName().Equals("nochess"))
                                {
                                    i = 10;
                                }
                            }
                        }
                    }
                    for (int j = chessColumn - 1; j >= 0; j--)
                    {
                        if (board[chessRow, j].GetName().Equals("nochess"))
                        {
                            board[chessRow, j].ChangeCanGo();
                        }
                        else
                        {
                            for (int j1 = j - 1; j1 >= 0; j1--)
                            {
                                if ((!board[chessRow, j1].GetName().Equals("nochess")) && (!board[chessRow, j1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow, j1].ChangeCanGo();
                                    j = -1;
                                    break;
                                }
                                else if ((!board[chessRow, j1].GetName().Equals("nochess")) && (board[chessRow, j1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    j = -1;
                                    break;
                                }
                                else if (board[chessRow, j1].GetName().Equals("nochess"))
                                {
                                    j = -1;
                                }
                            }
                        }
                    }
                    for (int j = chessColumn + 1; j <= 8; j++)
                    {
                        if (board[chessRow, j].GetName().Equals("nochess"))
                        {
                            board[chessRow, j].ChangeCanGo();
                        }
                        else
                        {
                            for (int j1 = j + 1; j1 <= 8; j1++)
                            {
                                if ((!board[chessRow, j1].GetName().Equals("nochess")) && (!board[chessRow, j1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow, j1].ChangeCanGo();
                                    j = 9;
                                    break;
                                }
                                else if ((!board[chessRow, j1].GetName().Equals("nochess")) && (board[chessRow, j1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    j = 9;
                                    break;
                                }
                                else if (board[chessRow, j1].GetName().Equals("nochess"))
                                {
                                    j = 9;
                                }
                            }
                        }
                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "车": //（0，0）==》（0，1）
                    for (int i = chessRow - 1; i >= 0; i--)
                    {
                        if (board[i, chessColumn].GetName().Equals("nochess"))
                        {
                            board[i, chessColumn].ChangeCanGo();
                        }
                        else if (board[i, chessColumn].GetColor().Equals(board[chessRow, chessColumn].GetColor()))
                        {
                            break;
                        }
                        else if ((!board[i, chessColumn].GetName().Equals("nochess")) && (!board[i, chessColumn].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                        {
                            board[i, chessColumn].ChangeCanGo();
                            break;
                        }


                    }


                    for (int i = chessRow + 1; i <= 9; i++)
                    {
                        if (board[i, chessColumn].GetName().Equals("nochess"))
                        {
                            board[i, chessColumn].ChangeCanGo();
                        }
                        else if ((board[i, chessColumn].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                        {
                            break;
                        }
                        else if ((!board[i, chessColumn].GetName().Equals("nochess")) && (!board[i, chessColumn].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                        {
                            board[i, chessColumn].ChangeCanGo();
                            break;
                        }

                    }

                    for (int j = chessColumn - 1; j >= 0; j--)
                    {
                        if (board[chessRow, j].GetName().Equals("nochess"))
                        {
                            board[chessRow, j].ChangeCanGo();
                        }
                        else if ((board[chessRow, j].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                        {
                            break;
                        }
                        else if ((!board[chessRow, j].GetName().Equals("nochess")) && (!board[chessRow, j].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                        {
                            board[chessRow, j].ChangeCanGo();

                            break;

                        }
                    }


                    for (int j = chessColumn + 1; j <= 8; j++)
                    {
                        if (board[chessRow, j].GetName().Equals("nochess"))
                        {
                            board[chessRow, j].ChangeCanGo();
                        }
                        else if ((board[chessRow, j].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                        {
                            break;
                        }
                        else if ((!board[chessRow, j].GetName().Equals("nochess")) && (!board[chessRow, j].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                        {
                            board[chessRow, j].ChangeCanGo();
                            break;
                        }

                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------

                case "象":
                    CreateBigBoard();
                    column = chessColumn + 2;
                    row = chessRow + 2;
                    switch (board[chessRow, chessColumn].GetColor())
                    {
                        case "black":
                            if (chessRow <= 4)
                            {

                                if (chessRow == 4)
                                {
                                    if ((Big[row - 2, column + 2].GetName() == "nochess"))
                                    {
                                        if (Big[row - 1, column + 1].GetName() == "nochess")
                                        { Big[row - 2, column + 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row - 2, column + 2].GetName() != "nochess" &&
                                    Big[row - 2, column + 2].GetColor() == "red")
                                    {
                                        if (Big[row - 1, column + 1].GetName() == "nochess")
                                        { Big[row - 2, column + 2].ChangeCanGo(); }
                                    }
                                    if ((Big[row - 2, column - 2].GetName() == "nochess"))
                                    {
                                        if (Big[row - 1, column - 1].GetName() == "nochess")
                                        { Big[row - 2, column - 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row - 2, column - 2].GetName() != "nochess" &&
                                    Big[row - 2, column - 2].GetColor() == "red")
                                    {
                                        if (Big[row - 1, column - 1].GetName() == "nochess")
                                        { Big[row - 2, column - 2].ChangeCanGo(); }
                                    }
                                }
                                else
                                {
                                    if ((Big[row - 2, column + 2].GetName() == "nochess"))
                                    {
                                        if (Big[row - 1, column + 1].GetName() == "nochess")
                                        { Big[row - 2, column + 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row - 2, column + 2].GetName() != "nochess" && Big[row + 2, column + 2].GetColor() == "red")
                                    {
                                        if (Big[row - 1, column + 1].GetName() == "nochess")
                                        { Big[row - 2, column + 2].ChangeCanGo(); }
                                    }
                                    if ((Big[row - 2, column - 2].GetName() == "nochess"))
                                    {
                                        if (Big[row - 1, column - 1].GetName() == "nochess")
                                        { Big[row - 2, column - 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row - 2, column - 2].GetName() != "nochess" &&
                                    Big[row - 2, column - 2].GetColor() == " red")
                                    {
                                        if (Big[row - 1, column - 1].GetName() == "nochess")
                                        { Big[row - 2, column - 2].ChangeCanGo(); }
                                    }
                                    if ((Big[row + 2, column + 2].GetName() == "nochess"))
                                    {
                                        if (Big[row + 1, column + 1].GetName() == "nochess")
                                        {
                                            Big[row + 2, column + 2].ChangeCanGo();
                                        }
                                    }
                                    else if (Big[row + 2, column + 2].GetName() != "nochess" &&
                                   Big[row + 2, column + 2].GetColor() == "red")
                                    {
                                        if (Big[row + 1, column + 1].GetName() == "nochess")
                                        { Big[row + 2, column + 2].ChangeCanGo(); }
                                    }
                                    if ((Big[row + 2, column - 2].GetName() == "nochess"))
                                    {
                                        if (Big[row + 1, column - 1].GetName() == "nochess")
                                        { Big[row + 2, column - 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row + 2, column - 2].GetName() != "nochess" &&
                                    Big[row + 2, column - 2].GetColor() == "red")
                                    {
                                        if (Big[row + 1, column - 1].GetName() == "nochess ")
                                        { Big[row + 2, column - 2].ChangeCanGo(); }
                                    }
                                }
                            }
                            CopyCanGo();
                            break;


                        case "red":
                            if (chessRow >= 5)
                            {

                                if (chessRow == 5)
                                {
                                    if ((Big[row + 2, column - 2].GetName() == "nochess"))
                                    {
                                        if (Big[row + 1, column - 1].GetName() == "nochess")
                                        { Big[row + 2, column - 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row + 2, column - 2].GetName() != "nochess" &&
                                    Big[row + 2, column - 2].GetColor() == "black")
                                    {
                                        if (Big[row + 1, column - 1].GetName() == "nochess")
                                        { Big[row + 2, column - 2].ChangeCanGo(); }
                                    }
                                    if ((Big[row + 2, column + 2].GetName() == "nochess"))
                                    {
                                        if (Big[row + 1, column + 1].GetName() == "nochess")
                                        { Big[row + 2, column + 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row + 2, column + 2].GetName() != "nochess" &&
                                    Big[row + 2, column + 2].GetColor() == "black")
                                    {
                                        if (Big[row + 1, column + 1].GetName() == "nochess")
                                        { Big[row + 2, column + 2].ChangeCanGo(); }
                                    }
                                }
                                else
                                {
                                    if ((Big[row - 2, column + 2].GetName() == "nochess"))
                                    {
                                        if (Big[row - 1, column + 1].GetName() == "nochess")
                                        { Big[row - 2, column + 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row - 2, column + 2].GetName() != "nochess" &&
                                   Big[row - 2, column + 2].GetColor() == "black")
                                    {
                                        if (Big[row - 1, column + 1].GetName() == "nochess")
                                        { Big[row - 2, column + 2].ChangeCanGo(); }
                                    }
                                    if ((Big[row + 2, column + 2].GetName() == "nochess"))
                                    {
                                        if (Big[row + 1, column + 1].GetName() == "nochess")
                                        { Big[row + 2, column + 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row + 2, column + 2].GetName() != "nochess" &&
                                    Big[row + 2, column + 2].GetColor() == "black")
                                    {
                                        if (Big[row + 1, column + 1].GetName() == "nochess")
                                        { Big[row + 2, column + 2].ChangeCanGo(); }
                                    }
                                    if ((Big[row + 2, column - 2].GetName() == "nochess"))
                                    {
                                        if (Big[row + 1, column - 1].GetName() == "nochess")
                                        { Big[row + 2, column - 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row + 2, column - 2].GetName() != "nochess" &&
                                    Big[row + 2, column - 2].GetColor() == "black")
                                    {
                                        if (Big[row + 1, column - 1].GetName() == "nochess")
                                        { Big[row + 2, column - 2].ChangeCanGo(); }
                                    }
                                    if ((Big[row - 2, column - 2].GetName() == "nochess"))
                                    {
                                        if (Big[row - 1, column - 1].GetName() == "nochess")
                                        { Big[row - 2, column - 2].ChangeCanGo(); }
                                    }
                                    else if (Big[row - 2, column - 2].GetName() != "nochess" &&
                                    Big[row - 2, column - 2].GetColor() == "black")
                                    {
                                        if (Big[row - 1, column - 1].GetName() == "nochess")
                                        { Big[row - 2, column - 2].ChangeCanGo(); }
                                    }
                                }
                            }
                            CopyCanGo();
                            break;
                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "将":
                    switch (board[chessRow, chessColumn].GetColor())
                    {
                        case "red":
                            if (chessRow - 1 >= 7)
                            {
                                if (board[chessRow - 1, chessColumn].GetName() == "nochess" || board[chessRow - 1, chessColumn].GetColor() != board[chessRow, chessColumn].GetColor())
                                {
                                    board[chessRow - 1, chessColumn].ChangeCanGo();
                                }
                            }
                            if (chessRow + 1 <= 9)
                            {
                                if (board[chessRow + 1, chessColumn].GetName() == "nochess" || board[chessRow + 1, chessColumn].GetColor() != board[chessRow, chessColumn].GetColor())
                                {
                                    board[chessRow + 1, chessColumn].ChangeCanGo();
                                }
                            }
                            if (chessColumn - 1 >= 3)
                            {
                                if (board[chessRow, chessColumn - 1].GetName() == "nochess" || board[chessRow, chessColumn - 1].GetColor() != board[chessRow, chessColumn].GetColor())
                                {
                                    board[chessRow, chessColumn - 1].ChangeCanGo();
                                }
                            }
                            if (chessColumn + 1 <= 5)
                            {
                                if (board[chessRow, chessColumn + 1].GetName() == "nochess" || board[chessRow, chessColumn + 1].GetColor() != board[chessRow, chessColumn].GetColor())
                                {
                                    board[chessRow, chessColumn + 1].ChangeCanGo();
                                }
                            }
                            //飞将
                            if (chessColumn == blackGeneral.column)
                            {
                                int middlePiece = 0;
                                for (int i = chessRow - 1; i > blackGeneral.row; i--)
                                {
                                    if (board[i, chessColumn].GetName() != "nochess")
                                    {
                                        middlePiece = middlePiece + 1;
                                    }

                                }
                                if (middlePiece == 0)
                                {
                                    board[blackGeneral.row, blackGeneral.column].ChangeCanGo();
                                }
                            }
                            break;

                        case "black":
                            if (chessRow - 1 >= 0)
                            {
                                if (board[chessRow - 1, chessColumn].GetName() == "nochess" || board[chessRow - 1, chessColumn].GetColor() != board[chessRow, chessColumn].GetColor())
                                {
                                    board[chessRow - 1, chessColumn].ChangeCanGo();
                                }
                            }
                            if (chessRow + 1 <= 2)
                            {
                                if (board[chessRow + 1, chessColumn].GetName() == "nochess" || board[chessRow + 1, chessColumn].GetColor() != board[chessRow, chessColumn].GetColor())
                                {
                                    board[chessRow + 1, chessColumn].ChangeCanGo();
                                }
                            }
                            if (chessColumn - 1 >= 3)
                            {
                                if (board[chessRow, chessColumn - 1].GetName() == "nochess" || board[chessRow, chessColumn - 1].GetColor() != board[chessRow, chessColumn].GetColor())
                                {
                                    board[chessRow, chessColumn - 1].ChangeCanGo();
                                }
                            }
                            if (chessColumn + 1 <= 5)
                            {
                                if (board[chessRow, chessColumn + 1].GetName() == "nochess" || board[chessRow, chessColumn + 1].GetColor() != board[chessRow, chessColumn].GetColor())
                                {
                                    board[chessRow, chessColumn + 1].ChangeCanGo();
                                }
                            }
                            //飞将
                            if (chessColumn == redGeneral.column)
                            {
                                int middlePiece = 0;
                                for (int i = chessRow + 1; i < redGeneral.row; i++)
                                {
                                    if (board[i, chessColumn].GetName() != "nochess")
                                    {
                                        middlePiece = middlePiece + 1;
                                    }

                                }
                                if (middlePiece == 0)
                                {
                                    board[redGeneral.row, redGeneral.column].ChangeCanGo();
                                }
                            }
                            break;
                    }
                    break;
                //----------------------------------------------------------------------------------------------------------------------------------------------
                case "士":
                    switch (board[chessRow, chessColumn].GetColor())
                    {
                        case "red":
                            if (chessRow - 1 >= 7 && chessColumn + 1 <= 5)
                            {
                                if (board[chessRow - 1, chessColumn + 1].GetName().Equals("nochess"))
                                {
                                    board[chessRow - 1, chessColumn + 1].ChangeCanGo();
                                }
                                else if (!(board[chessRow - 1, chessColumn + 1].GetName().Equals("nochess") || board[chessRow - 1, chessColumn + 1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow - 1, chessColumn + 1].ChangeCanGo();
                                }
                            }

                            if (chessRow - 1 >= 7 && chessColumn - 1 >= 3)
                            {
                                if (board[chessRow - 1, chessColumn - 1].GetName().Equals("nochess"))
                                {
                                    board[chessRow - 1, chessColumn - 1].ChangeCanGo();
                                }
                                else if (!(board[chessRow - 1, chessColumn - 1].GetName().Equals("nochess") || board[chessRow - 1, chessColumn - 1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow - 1, chessColumn - 1].ChangeCanGo();
                                }
                            }

                            if (chessRow + 1 <= 9 && chessColumn - 1 >= 3)
                            {
                                if (board[chessRow + 1, chessColumn - 1].GetName().Equals("nochess"))
                                {
                                    board[chessRow + 1, chessColumn - 1].ChangeCanGo();
                                }
                                else if (!(board[chessRow + 1, chessColumn - 1].GetName().Equals("nochess") || board[chessRow + 1, chessColumn - 1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow + 1, chessColumn - 1].ChangeCanGo();
                                }
                            }

                            if (chessRow + 1 <= 9 && chessColumn + 1 <= 5)
                            {
                                if (board[chessRow + 1, chessColumn + 1].GetName().Equals("nochess"))
                                {
                                    board[chessRow + 1, chessColumn + 1].ChangeCanGo();
                                }
                                else if (!(board[chessRow + 1, chessColumn + 1].GetName().Equals("nochess") || board[chessRow + 1, chessColumn + 1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow + 1, chessColumn + 1].ChangeCanGo();
                                }
                            }

                            break;
                        case "black":
                            if (chessRow - 1 >= 0 && chessColumn + 1 <= 5)
                            {
                                if (board[chessRow - 1, chessColumn + 1].GetName().Equals("nochess"))
                                {
                                    board[chessRow - 1, chessColumn + 1].ChangeCanGo();
                                }
                                else if (!(board[chessRow - 1, chessColumn + 1].GetName().Equals("nochess") || board[chessRow - 1, chessColumn + 1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow - 1, chessColumn + 1].ChangeCanGo();
                                }
                            }

                            if (chessRow - 1 >= 0 && chessColumn - 1 >= 3)
                            {
                                if (board[chessRow - 1, chessColumn - 1].GetName().Equals("nochess"))
                                {
                                    board[chessRow - 1, chessColumn - 1].ChangeCanGo();
                                }
                                else if (!(board[chessRow - 1, chessColumn - 1].GetName().Equals("nochess") || board[chessRow - 1, chessColumn - 1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow - 1, chessColumn - 1].ChangeCanGo();
                                }
                            }

                            if (chessRow + 1 <= 2 && chessColumn - 1 >= 3)
                            {
                                if (board[chessRow + 1, chessColumn - 1].GetName().Equals("nochess"))
                                {
                                    board[chessRow + 1, chessColumn - 1].ChangeCanGo();
                                }
                                else if (!(board[chessRow + 1, chessColumn - 1].GetName().Equals("nochess") || board[chessRow + 1, chessColumn - 1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow + 1, chessColumn - 1].ChangeCanGo();
                                }
                            }

                            if (chessRow + 1 <= 2 && chessColumn + 1 <= 5)
                            {
                                if (board[chessRow + 1, chessColumn + 1].GetName().Equals("nochess"))
                                {
                                    board[chessRow + 1, chessColumn + 1].ChangeCanGo();
                                }
                                else if (!(board[chessRow + 1, chessColumn + 1].GetName().Equals("nochess") || board[chessRow + 1, chessColumn + 1].GetColor().Equals(board[chessRow, chessColumn].GetColor())))
                                {
                                    board[chessRow + 1, chessColumn + 1].ChangeCanGo();
                                }
                            }
                            break;
                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------

                case "马":
                    CreateBigBoard();
                    column = chessColumn + 2;
                    row = chessRow + 2;
                    if (Big[row + 1, column].GetName() == "nochess")
                    {
                        if (Big[row, column].GetColor() != Big[row + 2, column + 1].GetColor())
                        {
                            Big[row + 2, column + 1].ChangeCanGo();
                        }
                        if (Big[row, column].GetColor() != Big[row + 2, column - 1].GetColor())
                        {
                            Big[row + 2, column - 1].ChangeCanGo();
                        }
                    }

                    if (Big[row - 1, column].GetName() == "nochess")
                    {
                        if (Big[row, column].GetColor() != Big[row - 2, column + 1].GetColor())
                        {
                            Big[row - 2, column + 1].ChangeCanGo();
                        }
                        if (Big[row, column].GetColor() != Big[row - 2, column - 1].GetColor())
                        {
                            Big[row - 2, column - 1].ChangeCanGo();
                        }
                    }

                    if (Big[row, column - 1].GetName() == "nochess")
                    {
                        if (Big[row, column].GetColor() != Big[row - 1, column - 2].GetColor())
                        {
                            Big[row - 1, column - 2].ChangeCanGo();
                        }
                        if (Big[row, column].GetColor() != Big[row + 1, column - 2].GetColor())
                        {
                            Big[row + 1, column - 2].ChangeCanGo();
                        }
                    }

                    if (Big[row, column + 1].GetName() == "nochess")
                    {
                        if (Big[row, column].GetColor() != Big[row + 1, column + 2].GetColor())
                        {
                            Big[row + 1, column + 2].ChangeCanGo();
                        }
                        if (Big[row, column].GetColor() != Big[row - 1, column + 2].GetColor())
                        {
                            Big[row - 1, column + 2].ChangeCanGo();
                        }
                    }

                    break;
            }
        }

        public void MoveChess(string strBegincolum, string strBeginrow, string strEndcolum, string strEndrow)
        {
            int begincolum = int.Parse(strBegincolum);
            int beginrow = int.Parse(strBeginrow);
            int endcolum = int.Parse(strEndcolum);
            int endrow = int.Parse(strEndrow);
            board[endrow, endcolum] = board[beginrow, begincolum];
            board[endrow, endcolum].row = endrow;
            board[endrow, endcolum].column = endcolum;
            board[beginrow, begincolum] = new nochess(begincolum, beginrow);
        }
    }
}
