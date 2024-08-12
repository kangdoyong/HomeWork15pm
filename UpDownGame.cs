public class UpDownGame
{
    static void Main()
    {
        Random random = new Random();

        int chance = 5;
        int randomNumber = random.Next(0, 100) + 1;

        Console.WriteLine("UpDownGame");
        Console.WriteLine("1부터 100사이 중 숫자 맞추기(기회 5번)");

        for (int i = 1; i <= chance; ++i)
        {
            Console.Write("숫자 입력 : ");
            int number = int.Parse(Console.ReadLine());

            if (number < randomNumber) Console.WriteLine("UP!");
            else if (number > randomNumber) Console.WriteLine("DOWN!");
            else if (i == chance)
            {
                Console.WriteLine();
                Console.WriteLine($"실패! 정답은 {randomNumber}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("정답!");
                Console.WriteLine($"정답은 {randomNumber}, 남은기회는 {chance - i}");
                return;
            }
        }

    }
}
