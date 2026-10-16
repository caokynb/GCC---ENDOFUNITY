using UnityEngine;
public class EG_MarchState : IState
{
    private GroundElemental groundUnit;
    public EG_MarchState(GroundElemental groundUnit)
    {
        this.groundUnit = groundUnit;
    }
    public void Enter()
    {

    }
    public void Tick()
    {
        groundUnit.rb.linearVelocityX=groundUnit.speed;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        groundUnit.rb.linearVelocityX=0f;
    }

}