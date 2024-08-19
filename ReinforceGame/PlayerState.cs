using System; 

public class PlayerState
{
    // 강화석
    private int _ReinforceRock;

    // 플레이어 상태를 초기화합니다.
    public void InitializePlayerState()
    {
        _ReinforceRock = 5;
    }

    // 강화석 사용 메서드
    public void UseReinforceRock()
    {
        --_ReinforceRock;
    }

    // 강화석 개수 반환 메서드
    public int GetReinforceRockCount()
    {
        return _ReinforceRock;
    }
}
