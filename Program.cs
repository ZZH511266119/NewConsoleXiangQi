using System;

namespace XiangqiProject
{
    class Program
    {
        static void Main(string[] args)
        {

            View view = new View();
            view.game.Initialize();
            view.Introduction();
            while (view.game.GameOver() == 2)
            {
                try
                {
                    switch (view.game.state)//
                    {
                        case "choose":
                            view.Display();
                            view.Option();
                            view.game.ChangeState();
                            break;

                        case "move":
                            view.PlayerMove();
                            view.game.ChangeState();
                            view.game.SwitchPlayer();
                            break;
                            
                    }//

                    /**
                    if(view.game.color == "red")
                    {
                        switch (view.game.state)
                        {
                            case "choose":
                                view.Display();
                                view.PlayerChoose();
                                view.game.ChangeState();
                                break;

                            case "move":
                                view.PlayerMove();
                                view.game.ChangeState();
                                view.game.SwitchPlayer();
                                view.Display();
                                break;

                        }
                    }
                    else
                    {
                        view.AIinput();
                        view.game.SwitchPlayer();
                    }
                     **/
                }
                catch (MyException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please input agian!");
                    Console.WriteLine("");
                }
            }

            if(view.game.GameOver() == 1)
            {
                if (view.game.WhoWin())
                {
                    Console.WriteLine("Gameover! Black player win!");
                }
                else
                {
                    Console.WriteLine("Gameover! Red player win!");
                }
            }

            else
            {
                Console.WriteLine("Draw!");
            }

        }
    }
}
