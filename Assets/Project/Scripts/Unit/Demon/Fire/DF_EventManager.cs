using UnityEngine;

public class DF_EventManager : MonoBehaviour
{
    [SerializeField] private FireDemon fireDemon;
    public void Attack()
    {
        fireDemon.currentTarget.TakeDamage(fireDemon.attack,Element.Fire);
    }
    public void Die()
    {
        fireDemon.Death();
    }
}
