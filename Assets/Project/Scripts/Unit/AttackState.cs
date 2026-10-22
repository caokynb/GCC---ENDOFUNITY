using System.Collections;
using UnityEngine;
public class AttackState : IState
{
    private UnitBase unit;
    private Coroutine beginAttack;
    public AttackState(UnitBase unit)
    {
        this.unit = unit;
    }
    public void Enter()
    {
        unit.attacking=true;
        unit.rb.linearVelocityX=0f;
        if(beginAttack==null) beginAttack = unit.StartCoroutine(StartAttack());
    }
    public void Tick()
    {

    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        unit.attacking=false;
        unit.anim.SetBool("Attack",false);
        if (beginAttack != null)
        {
            unit.StopCoroutine(beginAttack);
            beginAttack=null;
        }
    }
    public IEnumerator StartAttack()
    {
        while(unit.attacking){
            unit.anim.SetBool("Attack",true);
            yield return new WaitForSeconds(unit.attackSpeed);
            unit.anim.SetBool("Attack",false);
            yield return null;
        }
    }
}