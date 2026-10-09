using UnityEngine;
public class AttackStateFireDemon : IState
{
    private FireDemon fireDemon;
    private DemonAttackManager attackManager;
    private float timer;
    public AttackStateFireDemon(FireDemon fireDemon)
    {
        this.fireDemon = fireDemon;
        this.attackManager = fireDemon.attackManager;
    }
    public void Enter()
    {
        timer = fireDemon.attackSpeed;
        fireDemon.rb.linearVelocityX=0f;
    }
    public void Tick()
    {
        timer-=Time.deltaTime;
        if(timer <= 0f)
        {
            attackManager.startAttack?.Invoke(0,fireDemon.attack);
            timer=fireDemon.attackSpeed;
        }
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {

    }

}