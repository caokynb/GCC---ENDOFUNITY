using UnityEngine;
public class AttackStateFire : IState
{
    private FireElemental fireUnit;
    private ElementalAttackManager attackManager;
    private float timer;
    public AttackStateFire(FireElemental fireUnit)
    {
        this.fireUnit = fireUnit;
        this.attackManager = fireUnit.attackManager;
    }
    public void Enter()
    {
        timer = fireUnit.attackSpeed;
        fireUnit.rb.linearVelocityX=0f;
    }
    public void Tick()
    {
        timer-=Time.deltaTime;
        if(timer <= 0f)
        {
            attackManager.startAttack?.Invoke(0,fireUnit.attack);
            timer=fireUnit.attackSpeed;
        }
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {

    }

}