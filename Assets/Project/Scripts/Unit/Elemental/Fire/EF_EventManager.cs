using UnityEngine;

public class EF_EventManager : MonoBehaviour
{
    [SerializeField] public FireElemental fireUnit;
    public void Attack()
    {
        fireUnit.currentTarget.TakeDamage(fireUnit.attack);
    }
}
