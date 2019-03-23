[System.Serializable]
public class DungeLikeCurrentGameData
{

    public DungeLikeCurrentGameData()
    {
        PlayerHealth = 0;
        PlayerMana = 0;
        PlayerAttack = 0;
        Level = 0;
        Gold = 0;
    }

    public DungeLikeCurrentGameData(
        int health,
        int mana,
        int attack,
        int level,
        int gold)
    {
        PlayerHealth = health;
        PlayerMana = mana;
        PlayerAttack = attack;
        Level = level;
        Gold = gold;
    }

    public int PlayerHealth;
    public int PlayerMana;
    public int PlayerAttack;
    public int Level;
    public int Gold;
}

