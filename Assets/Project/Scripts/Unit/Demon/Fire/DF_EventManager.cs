using UnityEngine;

public class DF_EventManager : MonoBehaviour
{
    [SerializeField] private FireDemon fireDemon;
    public void Attack()
    {
        fireDemon.currentTarget.TakeDamage(fireDemon.attack);
    }
}
