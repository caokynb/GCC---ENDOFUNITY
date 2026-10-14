using System.Collections.Generic;
public class PlayerData
{
    public int maxHp;
    public float maxMana;
    public float manaRegenRate;
    public int spiritLimit;
    public List<int> upgrades = new List<int>{0,0,0};
    public PlayerData()
    {
        maxHp = 100;
        maxMana = 100f;
        manaRegenRate = 0.5f;
        spiritLimit = 3;
        upgrades = new List<int> { 0, 0, 0 };
    }
}
