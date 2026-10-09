using UnityEngine;
public class MarchStateFire : IState
{
    private FireElemental fireUnit;
    public MarchStateFire(FireElemental fireUnit)
    {
        this.fireUnit = fireUnit;
    }
    public void Enter()
    {

    }
    public void Tick()
    {
        fireUnit.rb.linearVelocityX=fireUnit.speed;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        fireUnit.rb.linearVelocityX=0f;
    }

}