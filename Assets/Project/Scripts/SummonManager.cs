using UnityEngine;

public class SummonManager : MonoBehaviour
{
    public static SummonManager Instance { get; private set; }
    [SerializeField] private PlayerTower player;
    private void Awake()
    {
        Instance = this;
    }
    public void Slot1()
    {
        Summon(player, player.SummonInit(1));
    }
    public void Slot2()
    {
        Summon(player, player.SummonInit(2));
    }
    public void Slot3()
    {
        Summon(player, player.SummonInit(3));
    }
    public bool Summon(TowerBase owner, UnitBase unit)
    {
        if (!owner.SpendMana(unit.Data.manaCost)) return false;
        UnitBase spawnedUnit = Instantiate(unit, owner.SpawnPosition, Quaternion.identity);
        owner.AddUnit(spawnedUnit);
        return true;
    }
}
