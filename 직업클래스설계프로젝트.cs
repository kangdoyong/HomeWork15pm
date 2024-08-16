public class 직업클래스설계프로젝트
{
    static void Main()
    {
        Job[] jobs =
        {
            new Archer("궁수", "활", "10"), new Warrior("전사", "검", "15")
        };

        foreach (Job job in jobs)
        {
            job.Print();
            Console.WriteLine();
        }
    }
}

public class Job
{
    protected string JobName;
    protected string Weapon;

    public virtual void Print()
    {
        Console.WriteLine($"직업명 : {JobName}");
        Console.WriteLine($"사용무기 : {Weapon}");
    }
}


public class Archer : Job
{
    private string Eva;

    public Archer(string jobname, string weapon, string eva)
    {
        JobName = jobname;
        Weapon = weapon;
        Eva = eva;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"회피력 : {Eva}");
    }

}

public class Warrior : Job
{
    private string Def;

    public Warrior(string jobname, string weapon, string def)
    {
        JobName = jobname;
        Weapon = weapon;
        Def = def;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"방어력 : {Def}");
    }
}