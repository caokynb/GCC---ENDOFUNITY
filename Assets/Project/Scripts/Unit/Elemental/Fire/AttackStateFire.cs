using System.Collections;
using UnityEngine;
public class AttackStateFire : IState
{
    private FireElemental fireUnit;
    private Coroutine beginAttack;
    public AttackStateFire(FireElemental fireUnit)
    {
        this.fireUnit = fireUnit;
    }
    public void Enter()
    {
        fireUnit.rb.linearVelocityX=0f;
        beginAttack = fireUnit.StartCoroutine(StartAttack());
    }
    public void Tick()
    {
        if(fireUnit.currentTarget == null) fireUnit.currentTarget.TakeDamage(fireUnit.attack);
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        fireUnit.StopCoroutine(StartAttack());
    }
    public IEnumerator StartAttack()
    {
        fireUnit.currentTarget.TakeDamage(fireUnit.attack);
        yield return new WaitForSeconds(fireUnit.attackSpeed);
    }
}