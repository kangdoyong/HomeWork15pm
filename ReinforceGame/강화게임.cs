using System;
using System.Threading.Channels;
using static System.Formats.Asn1.AsnWriter;

public class 강화게임
{ 
    static void Main()
    {
        Input _input = new Input();
        Reinforce reinforce = new Reinforce();
        _input.ItemNameInput();

        while (true)
        {
            _input.Menu();
            string input = Console.ReadLine();

            if (input == "N")
            {
                Console.WriteLine("강화게임이 종료되었습니다.");
                break;
            }
            else if (input == "Y")
            {
                Console.WriteLine();
                reinforce.ReinforceStart();

                if (reinforce.stone == 0)
                {
                    Console.WriteLine("강화석을 모두 소모했습니다.");
                    break;
                }
                else if (reinforce.stone == 5)
                {
                    Console.WriteLine("최대 강화 레벨에 도달했습니다.");
                    break;
                }
            }
        }
    }
}

public class Input
{
    public void ItemNameInput()
    {
        Console.Write("아이템 이름 입력 : ");
        string input = Console.ReadLine();
        Console.WriteLine();
    }

    public void Menu()
    {
        Reinforce reinforce = new Reinforce();

        Console.WriteLine("강화 게임을 진행하시겠습니까?");
        Console.WriteLine("강화진행 (Y) / 강화종료 (N)");
    }
}

public class ReinforceInfo
{
    Random random = new Random();

    public bool TryReinforce(int level)
    {
        int percent = 0;

        if (level == 0)
            percent = 90;
        else if (level == 1)
            percent = 70;
        else if (level == 2)
            percent = 50;
        else if (level == 3)
            percent = 30;
        else if (level == 4)
            percent = 10;
        else return false;

        int randomNumber = random.Next(0, 100) + 1;

        if (randomNumber <= percent)
        {
            Console.Write($"{level}강 -> {level + 1}강");
            Console.WriteLine();
            return true;
        }
        else
        {
            Console.Write($"{level}강 -> {level - 1}강");
            Console.WriteLine();
            return false;
        }
    }
}

public class Reinforce
{
    private int level = 0;
    public int stone = 5;

    public void ReinforceStart()
    {
        ReinforceInfo reinforceInfo = new ReinforceInfo();

        bool result = reinforceInfo.TryReinforce(level);

        if (result)
        {
            Console.WriteLine($"강화 성공! 현재 강화단계는 {level + 1}");
            Console.WriteLine();
            ++level;
        }
        else
        {
            Console.WriteLine($"강화 실패! 현재 강화단계는 {level}");
            Console.WriteLine();
        }

        --stone;
        if (level == 5) Console.WriteLine("최대 강화 레벨입니다.");
        if (level == 0) Console.WriteLine("강화석을 모두 소모했습니다.");
    }
}