public class UpDownGame
{
    static void Main()
    {
        Random random = new Random();

        int chance = 5;
        int randomNumber = random.Next(1, 100);

        Console.Write("숫자 입력 : ");
        int number = int.Parse(Console.ReadLine());

        if (number < randomNumber) Console.WriteLine("UP!");
        else if (number == randomNumber)
        {
            Console.WriteLine($"정답!");
            Console.WriteLine($"남은 기회 : {}");
            Console.WriteLine($"정답 : {}");
        }
        else Console.WriteLine("DOWN!");


        switch (number)
        {
            case ():
                Console.WriteLine("UP!");
                break;
        }
    }
}
