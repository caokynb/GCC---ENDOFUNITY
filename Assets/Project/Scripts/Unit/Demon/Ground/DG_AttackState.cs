using System.Collections;
using UnityEngine;
public class DG_AttackState : IState
{
    private GroundDemon groundDemon;
    private Coroutine beginAttack;
    public DG_AttackState(GroundDemon groundDemon)
    {
        this.groundDemon = groundDemon;
    }
    public void Enter()
    {
        groundDemon.attacking=true;
        groundDemon.rb.linearVelocityX=0f;
        if(beginAttack==null) beginAttack = groundDemon.StartCoroutine(StartAttack());
    }
    public void Tick()
    {

    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        groundDemon.attacking=false;
    }
    public IEnumerator StartAttack()
    {
        groundDemon.anim.SetBool("Attack",true);
        yield return new WaitForSeconds(groundDemon.attackSpeed);
        groundDemon.anim.SetBool("Attack",false);
        beginAttack=null;
    }
}