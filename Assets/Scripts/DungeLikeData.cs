[System.Serializable]
public class DungeLikeStatisticData
{
    public DungeLikeStatisticData()
    {
        TotalMonsterKilled = 0;
        CurrentMonsterKilled = 0;
        DeathCount = 0;
        HighestLevelReached = 0;
        CurrentLevelReached = 0;
        TotalGold = 0;
        CellsOpened = 0;
    }

    public DungeLikeStatisticData(
        int totalKills,
        int currentKills,
        int deaths,
        int levels,
        int currentLevelReached,
        int gold,
        int cellsOpend)
    {
        TotalMonsterKilled = totalKills;
        CurrentMonsterKilled = currentKills;
        DeathCount = deaths;
        HighestLevelReached = levels;
        CurrentLevelReached = currentLevelReached;
        TotalGold = gold;
        CellsOpened = cellsOpend;
    }

    // Statistic Data
    public int TotalMonsterKilled;
    public int CurrentMonsterKilled;
    public int DeathCount;
    public int HighestLevelReached;
    public int CurrentLevelReached;
    public int TotalGold;
    public int CellsOpened;
}
