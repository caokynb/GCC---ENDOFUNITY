using UnityEngine;

public class EW_EventManager : MonoBehaviour
{
    [SerializeField] public WaterElemental waterUnit;
    public void Attack()
    {
        waterUnit.currentTarget.TakeDamage(waterUnit.attack,Element.Water);
    }
    public void Die()
    {
        waterUnit.Death();
    }
}
