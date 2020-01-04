using System;

namespace XiangqiProject
{
    class View
    {
        public Controller game = new Controller();
        string[,] displayBoard = new string[11, 10];
        int[] beginPoint;

        public string[,] NormalBoard()
        {
            string[,] displayArray = {
                { "  ", "零","一","二","三","四","五","六","七","八"},
                {"零","┌ ","┬ ","┬ ","×","×","×","┬ ","┬ ", "┐ "},
                {"一","├ ","┼ ","┼ ","×","×","×","┼ ","┼ ","┤ " },
                {"二","├ ","┼ ","┼ ","×","×","×","┼ ","┼ ","┤ "  },
                {"三","├ ","┼ ","┼ ","┼ ","┼ ","┼ ","┼ ","┼ ", "┤ "},
                {"四","├ ","┴ ","┴ ","┴ ","┴ ","┴ ","┴ ","┴ ", "┤ " },
                {"五","├ ","┬ ","┬ ","┬ ","┬ ","┬ ","┬ ","┬ ", "┤ "},
                {"六","├ ","┼ ","┼ ","┼ ","┼ ","┼ ","┼ ","┼ ", "┤ " },
                {"七","├ ","┼ ","┼ ","×","×","×","┼ ","┼ ","┤ " },
                {"八","├ ","┼ ","┼ ","×","×","×","┼ ","┼ ","┤ " },
                {"九","└ ","┴ ","┴ ","×","×","×","┴ ","┴ ", "┘ " },
            };

            return displayArray;
        }

        public void Display()
        {
            displayBoard = NormalBoard();
            for(int i = 0; i <= 10; i++)
            {
                for(int j = 0; j <= 9; j++)
                {
                    if(i == 0 || j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(displayBoard[i, j]);
                    }
                    else if (game.controller.board[i - 1,j - 1].GetName() == "nochess")
                    {
                        if (game.controller.board[i - 1, j - 1].GetCanGo() == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(displayBoard[i, j]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        switch (game.controller.board[i - 1, j - 1].GetColor())
                        {
                            case "red":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;

                            case "black":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                        }
                        if (game.controller.board[i - 1, j - 1].GetCanGo() == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.Write(game.controller.board[i - 1, j - 1].GetName());
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public void GetInformation(Controller game)
        {
            this.game = game;
        }

        public void PlayerChoose()//选择棋子
        {
            string receiveBegin;
            string[] beginPoint = new string[2];
            int[] beginPointInt = new int[2];

            game.EmptyCanGo(game.controller);
            Console.WriteLine("Which pieces do you want to move? Please input its aix(Ex: row,column) : ");
            receiveBegin = Console.ReadLine();
            game.FindBigningPointException(receiveBegin);
            beginPoint = receiveBegin.Split(',');
            beginPointInt[0] = Convert.ToInt32(beginPoint[0]);
            beginPointInt[1] = Convert.ToInt32(beginPoint[1]);

            game.controller.WhereCanPieceGo(beginPointInt[1], beginPointInt[0]);

            this.beginPoint = beginPointInt;
        }

        public void PlayerMove()
        {
            Display();
            int[] endPointInt = new int[2];
            string receiveEnd;
            string[] endPoint = new string[2];
            Console.WriteLine("Where do you want to go? Please input its aix(Ex: row,column) : ");
            receiveEnd = Console.ReadLine();
            game.FindEndingPointException(receiveEnd, this.beginPoint);
            endPoint = receiveEnd.Split(',');
            endPointInt[0] = Convert.ToInt32(endPoint[0]);
            endPointInt[1] = Convert.ToInt32(endPoint[1]);

            game.GeneralDie(endPointInt);
            game.ChooseAndMove(this.beginPoint[0], this.beginPoint[1], endPointInt[0], endPointInt[1]);
            game.EmptyCanGo(game.controller);
        }

        public void AIinput()
        {
            int[] BestMove = game.FindtheBestPoint();
            int[] endPointInt = new int[2];
            Console.WriteLine("");
            Console.WriteLine("Which pieces do you want to move?");
            Console.WriteLine("I choose " + BestMove[0] + "，" + BestMove[1] + ".");

            game.controller.WhereCanPieceGo(BestMove[1], BestMove[0]);

            Console.WriteLine("");
            Display();
            Console.WriteLine("");

            Console.WriteLine("Where do you wan to go?");
            Console.WriteLine("I choose " + BestMove[2] + "，" + BestMove[3] + ".");
            endPointInt[0] = BestMove[3];
            endPointInt[0] = BestMove[2];
            game.GeneralDie(endPointInt);
            game.ChooseAndMove(BestMove[0], BestMove[1], BestMove[2], BestMove[3]);
            game.EmptyCanGo(game.controller);
        }
    }
}
