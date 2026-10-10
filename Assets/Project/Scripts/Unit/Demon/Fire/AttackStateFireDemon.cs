using System.Collections;
using UnityEngine;
public class AttackStateFireDemon : IState
{
    private FireDemon fireDemon;
    private Coroutine beginAttack;
    public AttackStateFireDemon(FireDemon fireDemon)
    {
        this.fireDemon = fireDemon;
    }
    public void Enter()
    {
        fireDemon.rb.linearVelocityX=0f;
        if(beginAttack==null) beginAttack = fireDemon.StartCoroutine(StartAttack());
    }
    public void Tick()
    {
        if(fireDemon.currentTarget == null) fireDemon.stateMachine.ChangeState(fireDemon.marchState);
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        
    }
    public IEnumerator StartAttack()
    {
        fireDemon.currentTarget.TakeDamage(fireDemon.attack);
        yield return new WaitForSeconds(fireDemon.attackSpeed);
        beginAttack=null;
    }

}