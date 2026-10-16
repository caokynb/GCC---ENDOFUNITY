using System.Collections;
using UnityEngine;
public class EG_AttackState : IState
{
    private GroundElemental groundUnit;
    private Coroutine beginAttack;
    public EG_AttackState(GroundElemental groundUnit)
    {
        this.groundUnit = groundUnit;
    }
    public void Enter()
    {
        groundUnit.attacking=true;
        groundUnit.rb.linearVelocityX=0f;
        if(beginAttack==null) beginAttack = groundUnit.StartCoroutine(StartAttack());
    }
    public void Tick()
    {

    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        groundUnit.attacking=false;
    }
    public IEnumerator StartAttack()
    {
        groundUnit.anim.SetBool("Attack",true);
        yield return new WaitForSeconds(groundUnit.attackSpeed);
        groundUnit.anim.SetBool("Attack",false);
        beginAttack=null;
    }
}