using UnityEngine;

public class DW_EventManager : MonoBehaviour
{
    [SerializeField] public WaterDemon waterDemon;
    public void Attack()
    {
        waterDemon.currentTarget.TakeDamage(waterDemon.attack,Element.Water);
    }
    public void Die()
    {
        waterDemon.Death();
    }
}
