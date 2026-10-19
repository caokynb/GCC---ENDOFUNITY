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
        fireUnit.attacking=true;
        fireUnit.rb.linearVelocityX=0f;
        if(beginAttack==null) beginAttack = fireUnit.StartCoroutine(StartAttack());
    }
    public void Tick()
    {

    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        fireUnit.attacking=false;
        if (beginAttack != null)
        {
            fireUnit.StopCoroutine(beginAttack);
        }
    }
    public IEnumerator StartAttack()
    {
        fireUnit.anim.SetBool("Attack",true);
        yield return new WaitForSeconds(fireUnit.attackSpeed);
        fireUnit.anim.SetBool("Attack",false);
        beginAttack=null;
    }
}