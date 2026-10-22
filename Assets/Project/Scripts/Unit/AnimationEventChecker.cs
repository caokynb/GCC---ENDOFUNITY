using UnityEngine;

public class AnimationEventChecker : MonoBehaviour
{
    private UnitBase unit;
    void Awake()
    {
        unit=GetComponentInParent<UnitBase>();
    }
    public void Attack()
    {
        unit.currentTarget.TakeDamage(unit.attack,unit.element);
    }

    public void Die()
    {
        unit.Death();
    }
}
