using UnityEngine;

public class EG_EventManager : MonoBehaviour
{
    [SerializeField] public GroundElemental groundUnit;
    public void Attack()
    {
        groundUnit.currentTarget.TakeDamage(groundUnit.attack,Element.Wood);
    }
    public void Die()
    {
        groundUnit.Death();
    }
}
