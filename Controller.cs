using System;
using System.Collections.Generic;
using System.Text;

namespace XiangqiProject
{
    class Controller
    {
        public Board controller = new Board();
        public Board displayController = new Board();
        public string color = "red";
        public string state = "choose";
        List<int[]> saveRedMove = new List<int[]>();
        List<int[]> saveBlackMove = new List<int[]>();
        List<Piece> redBeEaten = new List<Piece>();
        List<Piece> blackBeEaten = new List<Piece>();
        List<int[]> saveAllMove = new List<int[]>();
        public Board simulateMoveBoard = new Board();
        public Board simulateEnemyMoveBoard = new Board();
        public Board simulateSecondTimeMoveBoard = new Board();

        public void CopyBoard(Board controller1, Board controller2)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    controller2.board[j,i] = controller1.board[j,i];
                }
            }
        }

        public void Initialize()
        {
            controller.InitializeBorad();
        }

        public void GeneralDie(int[] endPointInt)
        {
            if (controller.board[endPointInt[0], endPointInt[1]].GetName() == "将")
            {
                controller.board[endPointInt[0], endPointInt[1]].alive = false;
            }
        }

        public int GameOver()
        {
            int generalNumber = 0;
            for(int i = 0; i <= 9; i++)
            {
                for(int j = 0; j <= 8; j++)
                {
                    if (controller.board[i,j].GetName() == "将")
                    {
                        generalNumber++;
                    }
                }
            }


            return generalNumber;
        }

        public bool WhoWin()
        {
            bool blackWin = false;
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if (controller.board[i, j].GetName() == "将")
                    {
                        if(controller.board[i,j].GetColor() == "black")
                        {
                            blackWin = true;
                        }
                    }
                }
            }



            return blackWin;
        }

        public void EmptyCanGo(Board beEmpty)
        {
            for (int j = 0; j <= 9; j++)
            {
                for (int i = 0; i <= 8; i++)
                {
                    beEmpty.board[j, i].canGo = false;
                }
            }
        }

        public void ChooseAndMove(int beginrow, int begincol, int endrow, int endcol)
        {
            if (color == "red")
            {
                int[] redMove = new int[4];
                redMove[0] = beginrow;
                redMove[1] = begincol;
                redMove[2] = endrow;
                redMove[3] = endcol;
                blackBeEaten.Add(controller.board[endrow, endcol]);
                saveRedMove.Add(redMove);
            }
            if (color == "black")
            {
                int[] blackMove = new int[4];
                blackMove[0] = beginrow;
                blackMove[1] = begincol;
                blackMove[2] = endrow;
                blackMove[3] = endcol;
                redBeEaten.Add(controller.board[endrow, endcol]);
                saveBlackMove.Add(blackMove);
            }
            controller.board[endrow, endcol] = controller.board[beginrow, begincol];
            controller.board[endrow, endcol].row = endrow;
            controller.board[endrow, endcol].column = endcol;
            controller.board[beginrow, begincol] = new nochess(begincol, beginrow);
        }

        public void FindBigningPointException(string receiveBegin)
        {
            string[] beginPoint = new string[2];
            int[] beginPointInt = new int[2];
            int numberOfCanGo = 0;

            if (receiveBegin.Length != 3)
            {
                MyException ex = new MyException();
                throw new MyException("Check you input!", ex);
            }
            else if (receiveBegin[1] != ',') 
            {
                MyException ex = new MyException();
                throw new MyException("Check you input!", ex);
            }
            else
            {
            }
            beginPoint = receiveBegin.Split(',');
            try
            {
                beginPointInt[0] = Convert.ToInt32(beginPoint[0]);
                beginPointInt[1] = Convert.ToInt32(beginPoint[1]);
            }
            catch (FormatException)
            {
                MyException ex = new MyException();
                throw new MyException("Check you input!", ex);
            }
            if (beginPointInt[0] > 9 || beginPointInt[0] < 0 || beginPointInt[1] < 0 || beginPointInt[1] > 8)//看看输入是不是范围以内的值
            {
                MyException ex = new MyException();
                throw new MyException("Check you input!", ex);
            }
            if (controller.board[beginPointInt[0], beginPointInt[1]].GetName() == "nochess")
            {
                MyException ex = new MyException();
                throw new MyException("You input a empty point!", ex);
            }
            if (controller.board[beginPointInt[0], beginPointInt[1]].GetColor() != color)
            {
                MyException ex = new MyException();
                throw new MyException("You are "+color+" player, choose "+color+" piece please!" , ex);
            }

            controller.WhereCanPieceGo(beginPointInt[1], beginPointInt[0]);
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if(controller.board[i,j].GetCanGo() == true)
                    {
                        numberOfCanGo++;
                    }
                }
            }

            if (numberOfCanGo == 0)
            {
                MyException ex = new MyException();
                throw new MyException("These piece cannot move, choose other piece please.", ex);
            }
            EmptyCanGo(controller);
        }

        public void FindEndingPointException(string receiveEnd, int[] beginPoint)
        {
            string[] endPoint = new string[2];
            int[] endPointInt = new int[2];
            if (receiveEnd.Length != 3)
            {
                MyException ex = new MyException();
                throw new MyException("Check you input!", ex);
            }
            else if (receiveEnd[1] != ',')
            {
                MyException ex = new MyException();
                throw new MyException("Check you input!", ex);
            }
            else
            {

            }

            endPoint = receiveEnd.Split(',');
            try
            {
                endPointInt[0] = Convert.ToInt32(endPoint[0]);
                endPointInt[1] = Convert.ToInt32(endPoint[1]);
            }
            catch (FormatException)
            {
                MyException ex = new MyException();
                throw new MyException("Check you input!", ex);
            }

            if (endPointInt[0] > 9 || endPointInt[0] < 0 || endPointInt[1] < 0 || endPointInt[1] > 8)
            {
                MyException ex = new MyException();
                throw new MyException("Check you input!", ex);
            }
            if (endPointInt[0] == beginPoint[0] && endPointInt[1] == beginPoint[1])
            {
                MyException ex = new MyException();
                throw new MyException("You eat yourself.", ex);
            }
            if (controller.board[endPointInt[0], endPointInt[1]].GetColor() == color)
            {
                MyException ex = new MyException();
                throw new MyException("You cannot eat your piece." , ex);
            }
            if (!(controller.board[endPointInt[0],endPointInt[1]].GetCanGo() == true))
            {
                string nameofChessPlayerChoosed = controller.board[beginPoint[0], beginPoint[1]].GetName();
                MyException ex = new MyException();
                throw new MyException("Now you choose " + nameofChessPlayerChoosed + ", but it cannot go that point, check the move method of it.", ex);
            }
        }

        public void RefreshCanGo()
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    controller.board[i, j].canGo = false;
                }

            }
        }

        public void SwitchPlayer()
        {
            switch (color)
            {
                case "black":
                    color = "red";
                    break;

                case "red":
                    color = "black";
                    break;
            }
        }

        public void ChangeState()
        {
            switch (state)
            {
                case "move":
                    state = "choose";
                    break;

                case "choose":
                    state = "move";
                    break;
            }
        }

        public List<TreeNode> EvaluateBoard(string color)
        {
            int parentnumber = 0;
            int countparentid = 1;
            int countid;

            List<TreeNode> Tree = new List<TreeNode>();
            TreeNode grandparent = new TreeNode(0, 0, -1);
            grandparent.SetParentId(-1);
            Tree.Add(grandparent);
            int playerPoint;
            int enemyPoint;
            for (int j = 0; j <= 9; j++)
            {
                for (int i = 0; i <= 8; i++)
                {
                    EmptyCanGo(controller);
                    if (controller.board[j,i].GetColor() == color)//找自己的棋子
                    {
                        for (int row = 0; row <= 9; row++)
                        {
                            for (int col = 0; col <= 8; col++)
                            {
                                controller.WhereCanPieceGo(i,j);
                                if (controller.board[row, col].GetCanGo() == true)
                                {
                                    CopyBoard(controller, simulateMoveBoard);
                                    EmptyCanGo(simulateMoveBoard);
                                    playerPoint = 0;
                                    int[] saveMove = { j,i, row, col };
                                    saveAllMove.Add(saveMove);
                                    parentnumber++;
                                    TreeNode parentnode = new TreeNode(countparentid, grandparent, 1);
                                    grandparent.SetChildren(parentnode);
                                    Tree.Add(parentnode);
                                    playerPoint += GetPoint(simulateMoveBoard.board[row, col].GetName());
                                    bool checkmake1 = Preventcheckmake(simulateMoveBoard);
                                    simulateMoveBoard.MoveChess(Convert.ToString(i), Convert.ToString(j), Convert.ToString(col), Convert.ToString(row));
                                    bool checkmake2 = Preventcheckmake(simulateMoveBoard);
                                    if (checkmake1 == false && checkmake2 == true) playerPoint -= 1000;

                                    playerPoint += ProtectPoint(simulateMoveBoard, simulateMoveBoard.board[row, col]);
                                    playerPoint += AttackPoint(simulateMoveBoard, simulateMoveBoard.board[row, col]);
                                    playerPoint += PreventEat(simulateMoveBoard, simulateMoveBoard.board[row, col]);
                                    countid = countparentid + 1;

                                    for (int row1 = 0; row1 <= 9; row1++)
                                    {
                                        for (int col1 = 0; col1 <= 8; col1++)
                                        {
                                            EmptyCanGo(simulateMoveBoard);
                                            if (simulateMoveBoard.board[row1, col1].GetColor() != color && simulateMoveBoard.board[row1, col1].GetColor() != "nochess")//敌方棋子
                                            {
                                                for (int row3 = 0; row3 <= 9; row3++)
                                                {
                                                    for (int col3 = 0; col3 <= 8; col3++)
                                                    {
                                                        simulateMoveBoard.WhereCanPieceGo(col1, row1);
                                                        if (simulateMoveBoard.board[row3, col3].GetCanGo() == true)
                                                        {
                                                            CopyBoard(simulateMoveBoard, simulateEnemyMoveBoard);
                                                            EmptyCanGo(simulateEnemyMoveBoard);
                                                            enemyPoint = 0;
                                                            enemyPoint += GetPoint(simulateEnemyMoveBoard.board[row3, col3].GetName());
                                                            bool checkmake3 = Preventcheckmake(simulateEnemyMoveBoard);
                                                            simulateEnemyMoveBoard.MoveChess(Convert.ToString(col1), Convert.ToString(row1), Convert.ToString(col3), Convert.ToString(row3));
                                                            bool checkmake4 = Preventcheckmake(simulateEnemyMoveBoard);
                                                            if (checkmake1 == false && checkmake2 == true) playerPoint -= 1000;
                                                            enemyPoint += ProtectPoint(simulateEnemyMoveBoard, simulateEnemyMoveBoard.board[row1, col1]);
                                                            enemyPoint += AttackPoint(simulateEnemyMoveBoard, simulateEnemyMoveBoard.board[row1, col1]);
                                                            enemyPoint += PreventEat(simulateEnemyMoveBoard, simulateEnemyMoveBoard.board[row1, col1]);
                                                            TreeNode childrennode = new TreeNode(countid, playerPoint - enemyPoint, parentnode, 2);

                                                            parentnode.SetChildren(childrennode);
                                                            Tree.Add(childrennode);
                                                            countid = countid + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }
                                    EmptyCanGo(simulateMoveBoard);
                                    countparentid = countid + 1;
                                }

                            }
                        }
                    }
                }
            }
            EmptyCanGo(controller);
            return Tree;
        }

        public int ProtectPoint(Board exampleboard, Piece examplechess)
        {
            int point = 0;
            Board exampleboard1 = new Board();
            for (int j = 0; j <= 9; j++)
            {
                for (int i = 0; i <= 8; i++)
                {
                    if (exampleboard.board[j,i].GetColor() != color && exampleboard.board[j,i].GetColor() != "nochess")
                    {
                        exampleboard.WhereCanPieceGo(i,j);
                        for (int z = 0; z <= 9; z++)
                        {
                            for (int k = 0; k <= 8; k++)
                            {
                                if (exampleboard.board[z,k].GetCanGo() == true && exampleboard.board[z,k].GetName() != "nochess")
                                {
                                    CopyBoard(exampleboard, exampleboard1);
                                    EmptyCanGo(exampleboard1);

                                    if (k == examplechess.column && z == examplechess.row)
                                    {
                                        point -= GetPoint(exampleboard1.board[z,k].GetName());
                                        break;
                                    }
                                    exampleboard1.MoveChess(Convert.ToString(i), Convert.ToString(j), Convert.ToString(k), Convert.ToString(z));
                                    exampleboard1.WhereCanPieceGo(examplechess.column, examplechess.row);

                                    if (exampleboard1.board[z,k].GetCanGo() == true)
                                    {
                                        if (exampleboard1.board[z,k].GetName() == exampleboard.board[j,i].GetName() && exampleboard1.board[z,k].GetColor() == exampleboard.board[j,i].GetColor())
                                        {
                                            if (exampleboard1.board[z,k].beProtected == false)
                                            {
                                                point += Convert.ToInt32(GetPoint(exampleboard1.board[j,i].GetName()));
                                                exampleboard1.board[z,k].beProtected = true;
                                            }
                                        }
                                    }
                                    EmptyCanGo(exampleboard1);
                                }


                            }
                        }
                    }
                    EmptyCanGo(exampleboard);
                }

            }
            EmptyCanGo(exampleboard);
            return point;
        }

        public int AttackPoint(Board exampleboard, Piece examplechess)
        {
            int point = 0;
            exampleboard.WhereCanPieceGo(examplechess.column, examplechess.row);
            for (int j = 0; j <= 9; j++)
            {
                for (int i = 0; i <= 8; i++)
                {
                    if (exampleboard.board[j,i].GetCanGo() == true)
                    {
                        if (exampleboard.board[j,i].GetName() != "nochess" && exampleboard.board[j,i].GetColor() != color)
                        {
                            point += Convert.ToInt32(0.6 * GetPoint(exampleboard.board[j,i].GetName()));
                        }
                    }
                }

            }
            EmptyCanGo(exampleboard);
            return point;
        }
        public int PreventEat(Board exampleboard, Piece examplechess)
        {
            int point = 0;
            for (int j = 0; j <= 9; j++)
            {
                for (int i = 0; i <= 8; i++)
                {
                    if (exampleboard.board[j,i].GetColor() != color && exampleboard.board[j,i].GetColor() != "nochess")
                    {
                        exampleboard.WhereCanPieceGo(i,j);
                        for (int z = 0; z <= 9; z++)
                        {
                            for (int k = 0; k <= 8; k++)
                            {
                                if (exampleboard.board[z,k].GetCanGo() == true && exampleboard.board[z,k].GetName() != "nochess")
                                {
                                    point -= Convert.ToInt32(0.8 * GetPoint(exampleboard.board[z,k].GetName()));
                                }
                            }
                        }
                        EmptyCanGo(exampleboard);
                    }
                }
            }

            EmptyCanGo(exampleboard);
            return point;
        }

        public bool Preventcheckmake(Board exampleboard)
        {
            bool decreasetpoint = false;
            for (int j = 0; j <= 9; j++)
            {
                for (int i = 0; i <= 8; i++)
                {
                    if (exampleboard.board[j,i].GetColor() != color && exampleboard.board[j,i].GetColor() != "nochess")
                    {
                        exampleboard.WhereCanPieceGo(i,j);
                        for (int z = 0; z <= 9; z++)
                        {
                            for (int k = 0; k <= 8; k++)
                            {
                                if (exampleboard.board[z,k].GetColor() == color && exampleboard.board[z,k].GetName() == "将")
                                {
                                    decreasetpoint = true;
                                }

                            }
                        }
                        EmptyCanGo(exampleboard);
                    }
                }
            }
            EmptyCanGo(exampleboard);
            return decreasetpoint;
        }

        public int GetPoint(string chessname)
        {
            int point = 0;
            switch (chessname)
            {
                case "将":
                    point = 1000;
                    break;

                case "兵":
                    point = 150;
                    break;

                case "士":
                    point = 150;
                    break;

                case "象":
                    point = 150;
                    break;

                case "炮":
                    point = 500;
                    break;

                case "马":
                    point = 500;
                    break;

                case "车":
                    point = 600;
                    break;

                case "nochess":
                    point = 0;
                    break;
            }
            return point;
        }

        public static TreeNode findChildren(TreeNode treeNode, List<TreeNode> treeNodes)
        {
            foreach (TreeNode i in treeNodes)
            {
                if (treeNode.GetId() == i.GetParentId())
                {
                    if (treeNode.GetChildren().Count != 0)
                    {
                        treeNode.GetChildren().Add(findChildren(i, treeNodes));
                    }
                }
            }
            return treeNode;
        }

        public static List<TreeNode> findlevel(int level, List<TreeNode> treeNodes)
        {
            List<TreeNode> thisLevelNode = new List<TreeNode>();
            foreach (TreeNode i in treeNodes)
            {
                if (i.Getlevel() == level)
                {
                    thisLevelNode.Add(i);
                }
            }
            return thisLevelNode;
        }

        public int[] FindtheBestPoint()
        {
            int AlphaPoint;
            int count = 0;
            List<int> parentid = new List<int>();

            List<TreeNode> estimate = EvaluateBoard(color);
            List<TreeNode> ThirdLevel = findlevel(2, estimate);
            List<TreeNode> SecondLevel = findlevel(1, estimate);
            List<TreeNode> FirstLevel = findlevel(0, estimate);
            List<TreeNode> FourthLevel = findlevel(3, estimate);

            foreach (TreeNode children in ThirdLevel)//第三层赋值第二层
            {
                foreach (TreeNode parent in SecondLevel)
                {
                    if (children.GetParentId() == parent.GetId())
                    {
                        if (parent.GetData() == -1000000000)
                        {
                            parent.SetData(children.GetData());
                        }

                        else
                        {
                            if (parent.GetData() > children.GetData())
                            {
                                parent.SetData(children.GetData());
                            }
                        }

                        break;
                    }


                }
            }
            foreach (TreeNode parent in SecondLevel)//第二层赋值第一层
            {
                foreach (TreeNode grandparent in FirstLevel)
                {
                    if (parent.GetParentId() == grandparent.GetId())
                    {
                        if (grandparent.GetData() == -1000000000)
                        {
                            grandparent.SetData(parent.GetData());
                        }

                        else
                        {
                            if (grandparent.GetData() < parent.GetData())
                            {
                                grandparent.SetData(parent.GetData());
                            }
                        }

                        break;
                    }


                }
            }

            AlphaPoint = FirstLevel[0].GetData();

            foreach (TreeNode i in SecondLevel)
            {
                if (AlphaPoint != i.GetData())
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            int[] bestpoint = saveAllMove[count];
            saveAllMove.Clear();

            return bestpoint;
        }

        public void Undo()
        {
            if(color == "red")
            {
                int[] blackMove = new int[4];
                blackMove = saveBlackMove[saveBlackMove.ToArray().Length -1 ];
                controller.board[blackMove[0], blackMove[1]] = controller.board[blackMove[2], blackMove[3]];
                controller.board[blackMove[2], blackMove[3]] = redBeEaten[redBeEaten.ToArray().Length -1];
                saveBlackMove.RemoveAt(saveBlackMove.ToArray().Length -1);
                redBeEaten.RemoveAt(redBeEaten.ToArray().Length - 1);
            }
            else if (color == "black")
            {
                int[] redMove = new int[4];
                int a = saveBlackMove.ToArray().Length;
                redMove = saveRedMove[saveRedMove.ToArray().Length - 1];
                controller.board[redMove[0], redMove[1]] = controller.board[redMove[2], redMove[3]];
                controller.board[redMove[2], redMove[3]] = blackBeEaten[blackBeEaten.ToArray().Length - 1];
                saveRedMove.RemoveAt(saveRedMove.ToArray().Length - 1);
                blackBeEaten.RemoveAt(blackBeEaten.ToArray().Length - 1);
            }

        }

        public void Draw()
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if (controller.board[i, j].GetName() == "将")
                    {
                        controller.board[i, j] = new nochess(0, 0);
                    }
                }
            }
        }

        public void Concede()
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if (controller.board[i, j].GetName() == "将" && controller.board[i,j].GetColor() == color)
                    {
                        controller.board[i, j] = new nochess(0, 0);
                    }
                }
            }
        }

    }
}
