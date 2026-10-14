using System.Collections;
using UnityEngine;
public class EW_AttackState : IState
{
    private WaterElemental waterUnit;
    private Coroutine beginAttack;
    public EW_AttackState(WaterElemental waterUnit)
    {
        this.waterUnit = waterUnit;
    }
    public void Enter()
    {
        waterUnit.attacking=true;
        waterUnit.rb.linearVelocityX=0f;
        if(beginAttack==null) beginAttack = waterUnit.StartCoroutine(StartAttack());
    }
    public void Tick()
    {

    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        waterUnit.attacking=false;
    }
    public IEnumerator StartAttack()
    {
        waterUnit.anim.SetBool("Attack",true);
        yield return new WaitForSeconds(waterUnit.attackSpeed);
        waterUnit.anim.SetBool("Attack",false);
        beginAttack=null;
    }
}