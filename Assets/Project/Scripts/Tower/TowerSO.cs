using UnityEngine;

[CreateAssetMenu(fileName = "TowerSO", menuName = "Scriptable Objects/TowerSO")]
public class TowerSO : ScriptableObject
{
    public int maxHp;
    public float maxMana;
    public float manaRegenRate;
    public int spiritLimit;
}
