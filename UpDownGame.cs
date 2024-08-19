using System;

//public class UpDownGame
//{
//    static void Main()
//    {
//        Random random = new Random();

//        int chance = 10;
//        int randomNumber = random.Next(0, 100) + 1;

//        Console.WriteLine("UpDownGame");
//        Console.WriteLine("1부터 100사이 중 숫자 맞추기(기회 5번)");

//        for (int i = 1; i <= chance; ++i)
//        {
//            Console.Write("숫자 입력 : ");
//            int number = int.Parse(Console.ReadLine());

//            if (number < randomNumber) Console.WriteLine("UP!");
//            else if (number > randomNumber) Console.WriteLine("DOWN!");
//            else if (i == chance)
//            {
//                Console.WriteLine();
//                Console.WriteLine($"실패! 정답은 {randomNumber}");
//            }
//            else
//            {
//                Console.WriteLine();
//                Console.WriteLine("정답!");
//                Console.WriteLine($"정답은 {randomNumber}, 남은기회는 {chance - i}");
//            }
//        }

//    }
//}

public class PlayerState()
{
    public const int MAX_CHANCE = 5;

    public int Chance;

    public void InitializePlayerState()
    {
        Chance = MAX_CHANCE;
    }

    public void DownChance(int result)
    {
        if (result != 0)
        {
            --Chance;
        }
    }

    public bool IsPlayerDead()
    {
        return Chance == 0;
    }
}

public class Game
{
    public int ComputerNumber;
    public bool IsRun;

    public void ResetGame()
    {
        ComputerNumber = new Random().Next(0, 100) + 1;
        IsRun = true;
    }

    public void PrintInputPlayerNumber()
    {
        Console.WriteLine("숫자를 입력하세요. (1 ~ 100 사이의 값을 입력하세요.)");
        Console.Write("입력 : ");
    }

    public int InputPlayerNumber()
    {
        int playerNumber = default;

        bool succeded = false;

        while (!succeded)
        {
            string playerInput = Console.ReadLine();

            succeded = int.TryParse(playerInput, out playerNumber);

            // 플레이어가 입력한 숫자가 1 이상 100 이하인지 확인합니다.
        }
        return playerNumber;
    }

    public void PrintResult(int result)
    {
        switch (result)
        {
            case -1:
                Console.WriteLine("Down!");
                break;

            case 0:
                Console.WriteLine("정답!");
                break;

            case 1:
                Console.WriteLine("Up!");
                break;
        }
    }

    public int CheckCorrect(int playerNumber)
    {
        if (ComputerNumber == playerNumber) return 0;

        else if (ComputerNumber > playerNumber) return 1;

        else if (ComputerNumber < playerNumber) return -1;

        return 0;
    }

    public void PrintGameFinished()
    {
        Console.WriteLine("게임이 종료되었습니다.");
    }

    public void FinishGame()
    {
        IsRun = false;
    }

    public void PrintSelectReset()
    {
        Console.WriteLine("게임을 다시 진행하시겠습니까?");
        Console.WriteLine("(Y : 재시작 / N : 게임 끝내기)");
        Console.Write("입력 : ");
    }

    public int SeletReset()
    {
        string playerInput = Console.ReadLine();
        return (playerInput == "Y") ? 1 : 0;
    }
}

public class 업다운게임
{
    static void Main()
    {
        Game gameInstance = new Game();
        PlayerState playerState = new PlayerState();

        while (gameInstance.IsRun)
        {
            gameInstance.ResetGame();
            playerState.InitializePlayerState();

            while (true)
            {
                gameInstance.PrintInputPlayerNumber();
                int playerNumber = gameInstance.InputPlayerNumber();
                int result = gameInstance.CheckCorrect(playerNumber);
                gameInstance.PrintResult(result);
                playerState.DownChance(result);

                if (playerState.IsPlayerDead())
                {
                    gameInstance.PrintGameFinished();
                    gameInstance.FinishGame();
                }
                else if (result == 0)
                {
                    gameInstance.FinishGame();
                }
            }
            gameInstance.PrintSelectReset();
            int resetCheck = gameInstance.SeletReset();

            if (resetCheck == 0) break;
        }
    }
}
