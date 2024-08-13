using System;
using System.Security.Cryptography.X509Certificates;

public class 점수결과출력프로젝트2
{ 
    public static void Main()
    {
        int[] scores = new int[3];

        Console.WriteLine("첫 번째 과목의 점수를 입력하세요.");
        Console.Write("입력 : ");
        scores[0] = int.Parse(Console.ReadLine());
        Console.WriteLine("두 번째 과목의 점수를 입력하세요.");
        Console.Write("입력 : ");
        scores[1] = int.Parse(Console.ReadLine());
        Console.WriteLine("세 번째 과목의 점수를 입력하세요.");
        Console.Write("입력 : ");
        scores[2] = int.Parse(Console.ReadLine());

        var (minscore, maxscore) = GetminmaxScore(scores);
        double average = GetaverageScore(scores);

        Console.WriteLine($"결과");
        Console.WriteLine($"최하 점수 : {minscore}");
        Console.WriteLine($"최고 점수 : {maxscore}");
        Console.WriteLine($"평균 점수 : {average}");

    }

    public static (int minscore, int maxscore) GetminmaxScore(int[] scores)
    {
        int minscore = scores[0];
        int maxcore = scores[0];

        foreach (int score in scores)
        {
            if (score < minscore)
                minscore = score;
            else if (score > maxcore)
                maxcore = score;
        }
        return(minscore, maxcore);
    }

    public static double GetaverageScore(int[] scores)
    {
        double average = (double)(scores[0] + scores[1] + scores[2]) / scores.Length;
        return average;
    }
}
