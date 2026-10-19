using System.Collections;
using UnityEngine;
public class DF_AttackState : IState
{
    private FireDemon fireDemon;
    private Coroutine beginAttack;
    public DF_AttackState(FireDemon fireDemon)
    {
        this.fireDemon = fireDemon;
    }
    public void Enter()
    {
        fireDemon.rb.linearVelocityX=0f;
        fireDemon.attacking=true;
        if(beginAttack==null) beginAttack = fireDemon.StartCoroutine(StartAttack());
    }
    public void Tick()
    {
        
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        fireDemon.attacking=false;
        if (beginAttack != null)
        {
            fireDemon.StopCoroutine(beginAttack);
        }
    }
    public IEnumerator StartAttack()
    {
        fireDemon.anim.SetBool("Attack",true);
        yield return new WaitForSeconds(fireDemon.attackSpeed);
        fireDemon.anim.SetBool("Attack",false);
        beginAttack=null;
    }

}