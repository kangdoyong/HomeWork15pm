using System;
using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Channels;

class ReinforceGame
{ 
    static void Main()
    {
        Name name = new Name();
        name.ItemName();

        ReinforceStart start = new ReinforceStart();

        while (true)
        {
            Console.WriteLine("강화시작 / 강화종료 중 하나를 입력");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input == "강화시작")
            {
                start.reinforceStart();
            }
            else if (input == "강화종료")
                break;
            else
            {
                Console.WriteLine("잘못된 입력값입니다. 다시 입력해주세요.");
            }
        }
        Console.WriteLine("강화게임 종료");
    }
}

class Name
{
    public void ItemName()
    {
        Console.Write("아이템 이름 입력 : ");
        string itemname = Console.ReadLine();
        Console.WriteLine();
    }
}

class Reinforce
{
    Random random = new Random();

    public bool ReinforceTry(int level)
    {
        int percentage;

        if (level == 0)
            percentage = 90;
        else if (level == 1)
            percentage = 70;
        else if (level == 2)
            percentage = 50;
        else if (level == 3)
            percentage = 30;
        else if (level == 4)
            percentage = 10;
        else
        {
            Console.WriteLine("더 이상 강화를 진행할 수 없습니다.");
            return false;
        }

        int randomnumber = random.Next(0, 100) + 1;

        if (randomnumber <= percentage)
        {
            Console.Write($"{level}강 -> {level + 1}강");
            Console.WriteLine("강화 성공!");
            return true;
        }
        else
        {
            Console.Write($"{level}강 -> {level + 1}강");
            Console.WriteLine("강화 실패!");
            return false;
        }

    }
}

class ReinforceStart
{
    private int Level = 0;
    private int stone = 5;
    Reinforce reinforce = new();
    Name name = new();

    public void reinforceStart()
    {
        --stone;
        if (Level == 5)
        {
            Console.WriteLine("최대 강화 단계입니다.");
            return;
        }
        if (stone == 0)
        {
            Console.WriteLine("강화석이 모두 소모되었습니다.");
            return;
        }

        bool result = reinforce.ReinforceTry(Level);
        if (result)
        {
            Console.WriteLine($"강화성공! 현재 강화단계는 {Level + 1}");
            ++Level;
        }
        else
        {
            Console.WriteLine($"강화실패! 현재 강화단계는 {Level}");
        }
    }

}