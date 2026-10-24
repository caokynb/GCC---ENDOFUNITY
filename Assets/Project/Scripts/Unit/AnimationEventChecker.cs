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
        if(unit.currentTarget!=null) unit.currentTarget.TakeDamage(unit.attack,unit.element);
    }

    public void Die()
    {
        unit.Death();
    }
}
