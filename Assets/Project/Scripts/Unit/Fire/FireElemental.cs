using Unity.VisualScripting;
using UnityEngine;

public class FireElemental : MonoBehaviour
{
    [SerializeField] private UnitSO unitData;
    private Formula formula;
    public string unitName;
    public Element element;
    public int hp;
    public int attack;
    public int defense;
    public int speed;
    public float attackRange;
    public float attackSpeed;
    public int manaCost;
    void Awake()
    {
        formula = new Formula();
    }
    void GetStat()
    {
        unitName = unitData.unitName;
        element = unitData.element;
        hp = unitData.hp;
        attack = unitData.attack;
        defense = unitData.defense;
        speed = unitData.speed;
        attackRange = unitData.attackRange;
        attackSpeed = unitData.attackSpeed;
        manaCost = unitData.manaCost;
    }
}
