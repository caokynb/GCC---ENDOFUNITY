using System.Collections;
using UnityEngine;
public class EF_AttackState : IState
{
    private FireElemental fireUnit;
    private Coroutine beginAttack;
    public EF_AttackState(FireElemental fireUnit)
    {
        this.fireUnit = fireUnit;
    }
    public void Enter()
    {
        fireUnit.rb.linearVelocityX=0f;
        if(beginAttack==null) beginAttack = fireUnit.StartCoroutine(StartAttack());
    }
    public void Tick()
    {
        if(fireUnit.currentTarget == null) fireUnit.stateMachine.ChangeState(fireUnit.marchState);
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        
    }
    public IEnumerator StartAttack()
    {
        fireUnit.anim.SetBool("Attack",true);
        yield return new WaitForSeconds(fireUnit.attackSpeed);
        fireUnit.anim.SetBool("Attack",false);
        beginAttack=null;
    }
}