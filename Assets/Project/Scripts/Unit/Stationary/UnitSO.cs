using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitSO", menuName = "Scriptable Objects/UnitSO")]
public class UnitSO : ScriptableObject
{
    public string unitName;
    public Element element;
    public int hp;
    public int attack;
    public int defense;
    public float speed;
    public float attackRange;
    public float attackSpeed;
    public int manaCost;
}
public enum Element
{
    Fire = 0,
    Water = 1,
    Wood = 2
}
