using UnityEngine;
public class EF_MarchState : IState
{
    private FireElemental fireUnit;
    public EF_MarchState(FireElemental fireUnit)
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