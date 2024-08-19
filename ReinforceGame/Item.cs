using System;

public class Item
{
    // 랜덤 객체
    private Random _Random = new Random();

    // 아이템 이름
    private string _ItemName;

    // 아이템 강화 수치
    private int _Rank;
    
    // 아이템 정보를 초기화합니다.
    public void InitializeItemInfo(string itemName)
    {
        _ItemName = itemName;
        _Rank = 0;
    }

    // 아이템 정보를 반환합니다.
    public (string itemName, int rank) GetItemInfo()
    {
        return (_ItemName, _Rank);
    }

    // 강화 성공 확률 반환
    public int GetReinforcePercentage()
    {
        return 90 - (_Rank * 20);
    }

    // 최대 강화 수치임을 확인합니다.
    public bool IsMaxRank()
    {
        return _Rank == 5;
    }

    // 강화를 시도합니다.
    public bool TryReinforce(PlayerState playerState)
    {
        if (playerState.GetReinforceRockCount() == 0) return false;

        // 강화석 소모
        playerState.UseReinforceRock();

        // 난수 생성
        int randomNumber = _Random.Next(0, 100) + 1;

        // 강화 성공 여부를 반환
        return (randomNumber <= GetReinforcePercentage());
    }

    // 강화 수치 증가
    public void UpRank()
    {
        ++_Rank;
    }

    // 강화 수치 하락
    public void DownRank()
    {
        --_Rank;

        _Rank = Math.Max(_Rank, 0);
    }
}
