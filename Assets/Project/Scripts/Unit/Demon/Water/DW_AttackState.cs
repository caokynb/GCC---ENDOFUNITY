using System.Collections;
using UnityEngine;
public class DW_AttackState : IState
{
    private WaterDemon waterDemon;
    private Coroutine beginAttack;
    public DW_AttackState(WaterDemon waterDemon)
    {
        this.waterDemon = waterDemon;
    }
    public void Enter()
    {
        waterDemon.attacking=true;
        waterDemon.rb.linearVelocityX=0f;
        if(beginAttack==null) beginAttack = waterDemon.StartCoroutine(StartAttack());
    }
    public void Tick()
    {

    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        waterDemon.attacking=false;
        if (beginAttack != null)
        {
            waterDemon.StopCoroutine(beginAttack);
        }
    }
    public IEnumerator StartAttack()
    {
        waterDemon.anim.SetBool("Attack",true);
        yield return new WaitForSeconds(waterDemon.attackSpeed);
        waterDemon.anim.SetBool("Attack",false);
        beginAttack=null;
    }
}