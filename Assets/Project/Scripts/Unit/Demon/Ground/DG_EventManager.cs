using UnityEngine;

public class DG_EventManager : MonoBehaviour
{
    [SerializeField] public GroundDemon groundDemon;
    public void Attack()
    {
        groundDemon.currentTarget.TakeDamage(groundDemon.attack,Element.Wood);
    }
    public void Die()
    {
        groundDemon.Death();
    }
}
