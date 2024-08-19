using System;

public class Game
{ 
    private PlayerState _PlayerState;
    private Item _ItemInstance;

    public Game()
    {
        _PlayerState = new PlayerState();
        _ItemInstance = new Item();
    }

    private static void Main() { new Game().EntryPoint(); } 

    private void EntryPoint()
    {
        while(true)
        {
            // 게임 실행
            RunGame();
        }
    }

    private void RunGame()
    {
        // 플레이어 상태 객체 초기화
        _PlayerState.InitializePlayerState();

        // 아이템 이름 입력 문구 출력
        PrintInputItemName();

        // 아이템 이름을 입력받습니다.
        string itemName = InputItemName();

        // 아이템 정보 초기화
        _ItemInstance.InitializeItemInfo(itemName);

        // 강화석이 존재하는 경우 게임 진행
        while (_PlayerState.GetReinforceRockCount() != 0)
        {
            // 아이템 정보 출력
            PrintItemInfo(in _ItemInstance);

            // 플레이어 상태 출력
            PrintPlayerState(in _PlayerState);

            // 강화 메뉴 출력
            PrintSelectReinforceMenu();

            // 강화 메뉴 선택지 입력
            bool startReinforce = InputSelectReinforceMenu();

            // 강화 시작 선택 시
            if (startReinforce)
            {
                // 강화 시도
                bool isSucceeded = _ItemInstance.TryReinforce(_PlayerState);

                // 결과에 따른 강화 수치 조절
                if (isSucceeded) _ItemInstance.UpRank();
                else _ItemInstance.DownRank();
            }

            // 강화 종료 선택 시
            else return;
        }
    }

    // 아이템 이름 입력 문구 출력
    private void PrintInputItemName()
    {
        Console.WriteLine("아이템 이름을 입력하세요.");
        Console.Write("입력 : ");
    }

    // 아이템 이름을 입력받습니다.
    private string InputItemName()
    {
        return Console.ReadLine();
    }

    // 플레이어 상태 출력
    private void PrintPlayerState(in PlayerState playerState)
    {
        Console.WriteLine();
        Console.WriteLine($"남은 강화석 : {playerState.GetReinforceRockCount()}");
    }

    // 아이템 정보 출력
    private void PrintItemInfo(in Item itemInstance)
    {
        (string itemName, int itemRank) = itemInstance.GetItemInfo();

        Console.Clear();
        Console.WriteLine($"아이템 이름 : {itemName}");
        Console.WriteLine($"강화 수치 : {itemRank}강");

        if (!itemInstance.IsMaxRank())
        {
            Console.WriteLine($"강화 성공 확률 : [{itemInstance.GetReinforcePercentage()}%]"); 
        }
    }

    private void PrintSelectReinforceMenu()
    {
        Console.WriteLine();
        Console.WriteLine("강화를 진행하시겠습니까?");
        Console.WriteLine("(Y : 강화 진행 / N  : 강화 종료)");
        Console.Write("입력 : ");
    }
    
    private bool InputSelectReinforceMenu()
    {
        return Console.ReadLine() == "Y";
    }
}
