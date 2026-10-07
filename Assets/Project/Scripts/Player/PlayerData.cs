using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int maxHp = 100;
    public float maxMana = 100f;
    public float manaRegenRate = 5f;
    public int spiritLimit = 5;
    public List<int> upgrades = new List<int>{0,0,0};
}
